using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeiXin.Models;
using WeiXin.Helper;
using System.Xml;
using WebAPP.ClassLib;
using System.Configuration;
using Newtonsoft.Json;
using DBHelper;
using System.Web.Script.Serialization;
using WeiXin.WexinAPI;
using System.Data.SqlClient;
using Weixin.Mp.Sdk.Util;

namespace WebAPP.WebApp.WXPay
{
    public partial class ReadRedPack : System.Web.UI.Page
    {
        //public string q = string.Empty;
        public string openId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["q"] == null || Request.QueryString["q"].ToString() == "") { 
                    
                }
                else if (Request.QueryString["q"].ToString() != ConfigurationManager.AppSettings["CurrentRead"].ToString()) { }

                else
                {
                    CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                    openId = aa.GetUserOpenId(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(), "阅读关注");
                    //openId = userinfo["openid"].ToString();
                    //this.txtopenid.Value = openid;

                    var client = new System.Net.WebClient();
                    client.Encoding = System.Text.Encoding.UTF8;

                    var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", API_Token.AccessToken, openId);
                    var data = client.DownloadString(url);
                    var serializer = new JavaScriptSerializer();
                    Dictionary<string, object> u = serializer.Deserialize<Dictionary<string, object>>(data);


                    if (u["subscribe"].ToString() != "1")
                    {
                        Response.Write("<div align='center'><font size='24'>平台用户福利，长按下方二维码成为平台用户</font></div><div align='center'><img src='/img/2code.jpg' width='600px' height='600px'></div>");
                        Response.End();
                    }
                    else if (u["city"].ToString() != "大连")
                    {
                        Response.Write("<div align='center'><font size='24'>非大连地区用户无法领取</font></div><div align='center'><img src='/img/2code.jpg' width='600px' height='600px'></div>");
                        Response.End();
                    }
                    else
                    {
                        DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());

                        string packname = "阅读第" + Request.QueryString["q"].ToString() + "期";

                        if (dbHelper.ExecuteDataTable("", "select * from T_RedPack where openid = @openid and RedPackName = @packname", new SqlParameter[]{
                            new SqlParameter("@openid",openId), new SqlParameter("@packname",packname)
                        }).Rows.Count > 0
                            )
                        {
                            dbHelper.Dispose();
                            Response.Write("<div align='center'><font size='24'>您已抢过红包！</font></div><div align='center'></div>");
                            Response.End();

                        }
                        else if (int.Parse(dbHelper.ExecuteDataTable("", "select count(*) from T_RedPack where RedPackName = @packname", new SqlParameter[] { new SqlParameter("@packname", packname) }).Rows[0][0].ToString()) >= Convert.ToInt32(ConfigurationManager.AppSettings["CurrentReadCount"].ToString()))
                        {
                            dbHelper.Dispose();
                            Response.Write("<div align='center'><font size='24'>本期红包已抢完，敬请期待下期！</font></div><div align='center'></div>");
                            Response.End();

                        }
                        else
                        {
                            int a;
                            string log = SentRedPack(openId, out a);
                            dbHelper.ExecuteNonQuery("insert into [T_RedPack] ([OpenID] ,[CreateTime],[Amount],[RedPackName]) values (@openid,GETDATE(),@amount,@packname)", new SqlParameter[]{
                                new SqlParameter("@openid",openId),new SqlParameter("@amount",a),new SqlParameter("@packname",packname)
                            });

                            dbHelper.ExecuteNonQuery("insert into T_RedPack_Log (openid,logMessage) values (@openid,@message)", new SqlParameter[] { new SqlParameter("@openid", openId), new SqlParameter("@message", log) });

                            dbHelper.Dispose();
                            Response.Write("<div align='center'><font size='24'>恭喜你获得红包一个，金额随机，恭喜发财！</font></div><div align='center'></div>");
                            Response.End();
                        }
                        Response.Write(openId);
                        Response.End();
                    }
                }
            }
        }

        private string  SentRedPack(string op,out int a) {

            Logger.WriteTxtLog("OOOO:" + op);

            Response.ContentType = "text/plain";
            PayWeiXin model = new PayWeiXin();
            PayForWeiXinHelp PayHelp = new PayForWeiXinHelp();
            string result = string.Empty;
            //传入OpenId
            string openId = op;//Request.Form["openId"].ToString();
            //传入红包金额(单位分)
            //string amount = "100";//Request.Form["amount"] == null ? "" : Request.Form["amount"].ToString();
            Random ran = new Random();
            int amount = ran.Next(100, 110);
            a = amount;
            //接叐收红包的用户 用户在wxappid下的openid 
            model.re_openid = openId;//"oFIYdszuDXVqVCtwZ-yIcbIS262k";
            //付款金额，单位分 
            model.total_amount = amount;
            //最小红包金额，单位分 
            model.min_value = amount;
            //最大红包金额，单位分 
            model.max_value = amount;
            //调用方法
            string postData = PayHelp.DoDataForPayWeiXin(model);
            try
            {
                result = PayHelp.PayForWeiXin(postData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            string jsonResult = JsonConvert.SerializeXmlNode(doc);
            Response.ContentType = "application/json";
            return jsonResult;
        }
    }
}
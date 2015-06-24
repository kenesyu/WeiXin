using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAPP.ClassLib;
using System.Configuration;
using DBHelper;
using System.Data;
using WeiXin.Helper;
using Weixin.Mp.Sdk.Util;
using System.Xml;
using Newtonsoft.Json;

namespace WebAPP.WebApp
{
    public partial class SubscribeRedPack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Logger.WriteTxtLog("aa");

                CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString());
                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());

                //ViewState.Add("openid", userinfo["openid"].ToString());
                string openid = userinfo["openid"].ToString();
                string city = userinfo["city"].ToString();


                this.imgProfile.Src = userinfo["headimgurl"].ToString();
                this.lblNickname.Text = userinfo["nickname"].ToString();
                this.lblCity.Text = userinfo["city"].ToString();
                string chkSex = userinfo["sex"].ToString();
                if (chkSex == "1") { chkSex = "男"; }
                else if (chkSex == "2") { chkSex = "女"; }
                else { chkSex = "保密"; }
                this.lblSex.Text = chkSex;

                Logger.WriteTxtLog("bb");

                DataTable dt = dbHelper.ExecuteDataTable("select * from T_RedPack where openid = '" + openid + "' and RedPackName = '关注'");
                if (dt.Rows.Count == 0)
                {
                    if (city == "大连")
                    {

                        WeiXin.Models.PayWeiXin model = new WeiXin.Models.PayWeiXin();
                        PayForWeiXinHelp PayHelp = new PayForWeiXinHelp();
                        string result = string.Empty;

                        Random ran = new Random();
                        int amount = ran.Next(100, 110);

                        model.re_openid = openid;//"oFIYdszuDXVqVCtwZ-yIcbIS262k";
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
                            Logger.WriteTxtLog(ex.Message);
                        }
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(result);
                        string jsonResult = JsonConvert.SerializeXmlNode(doc);
                        dbHelper.ExecuteNonQuery("insert into T_RedPack (OpenID,CreateTime,Amount,RedPackName,Details) values ('" + openid + "',GETDATE(),'" + amount + "','关注','恭喜您得到现金红包一个，邀请您的朋友一起来试试手气！')");
                        this.lblmessage.Text = "恭喜您得到现金红包一个，邀请您的朋友一起来试试手气！";
                    }
                    else
                    {
                        dbHelper.ExecuteNonQuery("insert into T_RedPack (OpenID,CreateTime,Amount,RedPackName,Details) values ('" + openid + "',GETDATE(),0,'关注','对不起该活动暂时只对大连地区的小伙伴们开放 您的地区为[" + city + "]！')");
                        this.lblmessage.Text = "对不起该活动暂时只对大连地区的小伙伴们开放 您的地区为[" + city + "]！";
                    }
                }
                else
                {
                    this.lblmessage.Text = dt.Rows[0]["details"].ToString();
                }

                this.repList.DataSource = dbHelper.ExecuteDataTable("select top 10 * from T_RedPack a inner join T_UserInfo  b on  a.openid = b.openid where amount > 0 order by amount desc"); ;
                this.repList.DataBind();

                dbHelper.Dispose();
            }
            catch (SystemException ex)
            {
                Logger.WriteTxtLog(ex.Message.ToString());
                throw ex;
            }
        }

        public string st(string s, int l)
        {
            if (s.Length > l)
            {
                return s.Substring(0, l);
            }
            return s;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAPP.ClassLib;
using System.Configuration;
using System.Web.Script.Serialization;
using DBHelper;
using WeiXin.WexinAPI;

namespace WebAPP.RLWD
{
    public partial class tp : System.Web.UI.Page
    {
        public string openId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"]!= null && Request.QueryString["id"].ToString() != "")
                    {
                        CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                        Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(), "阅读关注");
                        openId = userinfo["openid"].ToString();
                        //this.txtopenid.Value = openid;

                        var client = new System.Net.WebClient();
                        client.Encoding = System.Text.Encoding.UTF8;

                        var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", API_Token.AccessToken, openId);
                        var data = client.DownloadString(url);
                        var serializer = new JavaScriptSerializer();
                        Dictionary<string, object> u = serializer.Deserialize<Dictionary<string, object>>(data);


                        if (u["subscribe"].ToString() != "1")
                        {
                            Response.Write("<div align='center'><font size='24'>关注后方可进行投票</font></div><div align='center'><img src='/img/2code.jpg' width='600px' height='600px'></div>");
                            Response.End();
                        }
                        else
                        {
                            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());

                            if (dbHelper.ExecuteDataTable("select * from T_RLWD_TP where openid = '"+openId+"'").Rows.Count == 0) {
                                dbHelper.ExecuteNonQuery("insert into T_RLWD_TP (openid,ToID) values ('" + openId + "'," + Convert.ToInt32(Request.QueryString["id"].ToString()) + ")");
                                dbHelper.ExecuteNonQuery("update T_RLWD set CountNum = (CountNum + 1) where id = '" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "'");
                                Response.Write("<script>alert('投票成功')</script>");
                                Response.Redirect("index.aspx");
                            }
                            else {
                                Response.Write("<div align='center'><font size='24'>你已经投过票了</font></div>");
                                Response.End();
                            }
                            dbHelper.Dispose();
                            Response.End();
                        }
                    }
                }
            }
        }
    }
}
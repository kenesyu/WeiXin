using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPP.ClassLib;
using System.Web.Script.Serialization;
using WeiXin.WexinAPI;

namespace WebAPP.WebApp.DR
{
    public partial class DR_Personal : System.Web.UI.Page
    {
        public string openid = string.Empty;
        public string toopenid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"].ToString() != "")
                {
                    try
                    {
                        CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                        Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(), "DR_BM");
                        if (userinfo != null)
                        {
                            openid = userinfo["openid"].ToString();
                        }

                        var client = new System.Net.WebClient();
                        client.Encoding = System.Text.Encoding.UTF8;

                        var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", API_Token.AccessToken, openid);
                        var data = client.DownloadString(url);
                        var serializer = new JavaScriptSerializer();
                        Dictionary<string, object> u = serializer.Deserialize<Dictionary<string, object>>(data);


                        //if (u == null) {
                            //Response.Write(u);
                            //Response.End();
                        //}

                        if (!u.ContainsKey("subscribe"))
                        {
                            Response.Write("<div align='center'><font size='24'>您拒绝了授权无法访问该页面</div>");
                            Response.End();
                        }
                        else if (u["subscribe"].ToString() != "1")
                        {
                            Response.Write("<div align='center'><font size='24'>请先关注，长按下方二维码进行关注</font></div><div align='center'><img src='/img/2code.jpg' width='600px' height='600px'></div>");
                            Response.End();
                        }
                        else
                        {

                        }

                        toopenid = Request.QueryString["op"].ToString();
                        GetDetails(Request.QueryString["op"].ToString());
                    }
                    catch(SystemException ex) {
                        throw ex;
                    }
                }
            }
        }


        private void GetDetails(string openid) {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "SELECT * from V_DR where openid = @openid", new SqlParameter[] { new SqlParameter("@openid", openid) });
            if (dt.Rows.Count > 0)
            {
                this.img.Src = dt.Rows[0]["headimgurl"].ToString();
                this.txtName.Text = dt.Rows[0]["Name"].ToString() + " — " + dt.Rows[0]["xname"].ToString();
                this.txtNo.Text = "参赛序号【" + dt.Rows[0]["ID"].ToString() + "】";
                this.txtResult.Text = "成绩【" + dt.Rows[0]["Result"].ToString() + "】";
                this.txtCountNum.Text = "人气指数【" + dt.Rows[0]["CountNum"].ToString() + "】";
            }
            else
            {
                Response.End();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Configuration;
using System.Data;
using WebAPP.ClassLib;
using WeiXin.WexinAPI;
using System.Web.Script.Serialization;

namespace WebAPP.WebApp.DR
{
    public partial class DR_BM : System.Web.UI.Page
    {
        public string openid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString());
                openid = userinfo["openid"].ToString();

                
                var client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", API_Token.AccessToken, openid);
                var data = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();
                Dictionary<string, object> u = serializer.Deserialize<Dictionary<string, object>>(data);


                if (u["subscribe"].ToString() != "1")
                {
                    Response.Write("<div align='center'><font size='24'>请先关注，长按下方二维码进行关注</font></div><div align='center'><img src='/img/2code.jpg' width='600px' height='600px'></div>");
                    Response.End();
                }
                else
                {




                }
                Bind();
            }
        }

        private void Bind()
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("select * from DR_X order by [Name]");
            this.selX.Items.Clear();
            this.selX.Items.Add(new ListItem("---请选择---", ""));
            foreach (DataRow dr in dt.Rows) {
                this.selX.Items.Add(new ListItem(dr["Name"].ToString(),dr["ID"].ToString()));
            }
            dbHelper.Dispose();
        }
    }
}
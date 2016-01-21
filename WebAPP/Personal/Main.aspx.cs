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

namespace WebAPP.Personal
{
    public partial class Main : System.Web.UI.Page
    {
        public string openid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                openid = aa.GetUserOpenId(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(), "Personal_Main");
                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
                DataTable dt = dbHelper.ExecuteDataTable("select * from T_UserInfo where openid = '" + openid + "'");
                if (dt.Rows.Count == 0)
                {
                    Response.Redirect("RegisterUser.aspx");
                }
                else
                {
                    //Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(), "Personal_Main");
                    this.Img_Header.Src = dt.Rows[0]["headimgurl"].ToString();// userinfo["headimgurl"].ToString();
                    this.lb_Nickname.Text = dt.Rows[0]["nickname"].ToString();
                    //openid = userinfo["openid"].ToString();
                }
            }
        }
    }
}
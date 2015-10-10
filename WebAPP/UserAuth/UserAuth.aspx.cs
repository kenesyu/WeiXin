using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using WebAPP.ClassLib;

namespace WebAPP.UserAuth
{
    public partial class UserAuth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {


                CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(),"UserAuth");
                //Response.Write(userinfo["openid"].ToString());

                this.imgProfile.Src = userinfo["headimgurl"].ToString();
                this.lblNickname.Text = userinfo["nickname"].ToString();
                this.lblCity.Text = userinfo["city"].ToString();
                string chkSex = userinfo["sex"].ToString();
                if (chkSex == "1") { chkSex = "男"; }
                else if (chkSex == "2") { chkSex = "女"; }
                else { chkSex = "保密"; }
                this.lblSex.Text = chkSex;
            }
        }
    }
}
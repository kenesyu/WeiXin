using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WebAPP.ClassLib;

namespace WebAPP.Personal
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(), "Personal_Main");
                Response.Redirect("Main.aspx");
            }
        }
    }
}
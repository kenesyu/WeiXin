using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeiXin
{
    public partial class IPAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           string userIP=Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
           if (userIP==null || userIP=="")
           {
                userIP=Request.ServerVariables["REMOTE_ADDR"];
           }
            Response.Write(userIP);
        }
    }
}
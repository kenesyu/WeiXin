using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebAPP.WebApp
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string osPat = "mozilla|m3gate|winwap|openwave|Windows NT|Windows 3.1|95|Blackcomb|98|ME|X Window|Longhorn|ubuntu|AIX|Linux|AmigaOS|BEOS|HP-UX|OpenBSD|FreeBSD|NetBSD|OS/2|OSF1|SUN";
                string uAgent = Request.ServerVariables["HTTP_USER_AGENT"];
                Regex reg = new Regex(osPat);
                if (reg.IsMatch(uAgent))
                {
                    Response.Write("电脑访问");
                }
                else
                {
                    Response.Write("手机访问");
                }
                Response.Write("<br/>" + uAgent);
            }
        }
    }
}
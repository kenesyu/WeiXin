using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiXin
{
    /// <summary>
    /// checkdev 的摘要说明
    /// </summary>
    public class checkdev : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            InterfaceTest();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public void InterfaceTest()
        {
            string token = "yuze";
            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            string echoString = HttpContext.Current.Request.QueryString["echoStr"];
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            if (!string.IsNullOrEmpty(echoString))
            {
                HttpContext.Current.Response.Write(echoString);
                HttpContext.Current.Response.End();
            }
        }
    }
}
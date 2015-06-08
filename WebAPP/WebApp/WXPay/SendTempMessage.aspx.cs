using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using WeiXin.WexinAPI;
using System.Web.Script.Serialization;

namespace WebAPP.WebApp.WXPay
{
    public partial class SendTempMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //Dictionary<string, object> dic = new Dictionary<string, object>();
            //Dictionary<string, object> dic1 = new Dictionary<string, object>();
            //Dictionary<string, object> dic2 = new Dictionary<string, object>();
            //dic.Add("touser", "ovTALuEgDT2sxXOcGwJ_rBgipgtY");
            //dic.Add("template_id", "eEgsxOYGIrYkXJVpQCFn2tH0LZQgzo8mBpKLlpTYHWU");
            ////dic.Add("url", "http://weixin.qq.com/download");   details
            //dic.Add("topcolor", "#FF0000");

            //dic2.Add("value", "xxxxxx");
            //dic2.Add("color", "#173177");
            //dic1.Add("first", dic2);
            //dic.Add("data", dic1);
            //string jsonstr = jss.Serialize(dic);

            string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + API_Token.AccessToken;
            string postData = "{"
               + " \"touser\":\"ovTALuCc4FM4sY4f2lhYSadlkq34\","
               + " \"template_id\":\"eEgsxOYGIrYkXJVpQCFn2tH0LZQgzo8mBpKLlpTYHWU\","
               + " \"topcolor\":\"#FF0000\","
               + " \"data\":{"
               + "     \"first\":{\"value\":\"您的信用卡在我店消费2145.00元\",\"color\":\"#173177\"},"
               + "     \"keyword1\":{\"value\":\"201504220001\",\"color\":\"#173177\"},"
               + "     \"keyword2\":{\"value\":\"" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "\",\"color\":\"#173177\"},"
               + "     \"keyword3\":{\"value\":\"00001\",\"color\":\"#173177\"},"
               + "     \"keyword4\":{\"value\":\"信用卡刷卡\",\"color\":\"#173177\"},"
               + "     \"keyword5\":{\"value\":\"2000\",\"color\":\"#173177\"},"
               + "     \"remark\":{\"value\":\"如有疑问请致电13478474050咨询\",\"color\":\"#173177\"}"
               + "}}";
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            Encoding encoding = Encoding.UTF8;
            HttpWebResponse response = null;
            HttpWebRequest request = WebRequest.Create(posturl) as HttpWebRequest;

            byte[] data = encoding.GetBytes(postData);

            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = data.Length;
            //request.ClientCertificates.Add(cert);
            outstream = request.GetRequestStream();
            outstream.Write(data, 0, data.Length);
            outstream.Close();
            //发送请求并获取相应回应数据  
            response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求  
            instream = response.GetResponseStream();
            sr = new StreamReader(instream, encoding);
            //返回结果网页（html）代码  
            string content = sr.ReadToEnd();
            string err = string.Empty;
            //return content;
        }
    }
}
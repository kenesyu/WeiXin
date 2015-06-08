using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Text;
using WeiXin.WexinAPI;

namespace WebAPP.BussinessService
{
    /// <summary>
    /// CustomerService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class CustomerService : System.Web.Services.WebService
    {

        [WebMethod]
        public string ConnectService(string openid, string message)
        {
            string msg = string.Empty;
            string posturl = " https://api.weixin.qq.com/customservice/kfsession/create?access_token=" + API_Token.AccessToken;
            string postData = "{"
                + " \"kf_account\":\"001@dlydjsw\","
                + " \"openid\":\"" + openid + "\","
                + " \"text\":\"" + message + "\""
                + " }";
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

            string content = sr.ReadToEnd();
            string err = string.Empty;

            msg = "已经为您转接人工客服请稍后";
            return msg;
        }
    }
}

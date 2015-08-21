using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Text;
using WeiXin.WexinAPI;
using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Request;
using System.Configuration;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk.Domain;
using DBHelper;
using System.Data.SqlClient;
using System.Data;

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
            #region ==== 转客服 ====
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
            //MessageHandler.TransferToAutoCustomer("gh_a21a5cfa913f", openid);
            #endregion            

            //#region ==== 模版消息 ====
            //posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + API_Token.AccessToken;
            //postData = "{"
            //   + " \"touser\":\""+openid+"\","
            //   + " \"template_id\":\"7XI7fdqdl-BR05RUGv7giH9ahCRzL2nxLP3IGBQvg4U\","
            //   + " \"topcolor\":\"#FF0000\","
            //   + " \"data\":{"
            //   + "     \"first\":{\"value\":\"我们接到了您的请求，客服会尽快与您取得联系！\\n\",\"color\":\"#173177\"},"
            //   + "     \"keyword1\":{\"value\":\"大连运动健身网\\n\",\"color\":\"#173177\"},"
            //   + "     \"keyword2\":{\"value\":\"" + message + "\\n\",\"color\":\"#173177\"},"
            //   + "     \"keyword3\":{\"value\":\"微信公众账号 客服\\n\",\"color\":\"#173177\"},"
            //   //+ "     \"keyword4\":{\"value\":\"信用卡刷卡\",\"color\":\"#173177\"},"
            //   //+ "     \"keyword5\":{\"value\":\"2000\",\"color\":\"#173177\"},"
            //   + "     \"remark\":{\"value\":\"\\n感谢您的参与！我们每周都会推出各种运动活动，每个活动的名额有限，先到先得，活动详情请参阅我们推送的历史消息\",\"color\":\"#173177\"}"
            //   + "}}";
            //outstream = null;
            //instream = null;
            //sr = null;
            //encoding = Encoding.UTF8;
            //response = null;
            //request = WebRequest.Create(posturl) as HttpWebRequest;

            //data = encoding.GetBytes(postData);

            //cookieContainer = new CookieContainer();
            //request.CookieContainer = cookieContainer;
            //request.AllowAutoRedirect = true;
            //request.Method = "POST";
            //request.ContentType = "text/xml";
            //request.ContentLength = data.Length;
            ////request.ClientCertificates.Add(cert);
            //outstream = request.GetRequestStream();
            //outstream.Write(data, 0, data.Length);
            //outstream.Close();
            ////发送请求并获取相应回应数据  
            //response = request.GetResponse() as HttpWebResponse;
            ////直到request.GetResponse()程序才开始向目标网页发送Post请求  
            //instream = response.GetResponseStream();
            //sr = new StreamReader(instream, encoding);
            ////返回结果网页（html）代码  
            //content = sr.ReadToEnd();
            //err = string.Empty;
            //#endregion

            msg = "报名成功";
            return msg;
        }

        [WebMethod]
        public string SentKey(string openid, string code,string productid,string name,string tel)
        {

            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            dbHelper.ExecuteNonQuery("insert into  T_Product_Pay (ProductID,openid,createTime,tradecode,[name],tel) values (@productid,@openid,GETDATE(),@code,@name,@tel)", new SqlParameter[]{
                new SqlParameter("@productid",productid),
                new SqlParameter("@openid",openid),
                new SqlParameter("@code",code),
                new SqlParameter("@name",name),
                new SqlParameter("@tel",tel)
            });

            DataTable dtPro = dbHelper.ExecuteDataTable("select * from T_Products where ProductID = " + productid);

            dbHelper.Dispose();


            #region ==== 模版消息 ====
            string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + API_Token.AccessToken;
            string postData = "{"
               + " \"touser\":\"" + openid + "\","
               + " \"template_id\":\"9V7bumCKMNhyqagcbkI_lpBwoDLYji39ol1rBh1g6Ko\","
               + " \"topcolor\":\"#FF0000\","
               + " \"data\":{"
               + "     \"first\":{\"value\":\"您好你的交易号为【" + code + "】\\n\",\"color\":\"#173177\"},"
               + "     \"orderMoneySum\":{\"value\":\"" + dtPro.Rows[0]["ProductPrice"].ToString() + "元\\n\",\"color\":\"#173177\"},"
               + "     \"orderProductName\":{\"value\":\"" + dtPro.Rows[0]["ProductName"].ToString() + "\\n\",\"color\":\"#173177\"},"
               //+ "     \"keyword3\":{\"value\":\"微信公众账号 客服\\n\",\"color\":\"#173177\"},"
                //+ "     \"keyword4\":{\"value\":\"信用卡刷卡\",\"color\":\"#173177\"},"
                //+ "     \"keyword5\":{\"value\":\"2000\",\"color\":\"#173177\"},"
               + "     \"Remark\":{\"value\":\"\\n感谢您的参与！本次活动联系方式：13941134765 \",\"color\":\"#173177\"}"
               + "}}";
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            Encoding encoding = Encoding.UTF8;
            HttpWebResponse response = null;
            HttpWebRequest request = WebRequest.Create(posturl) as HttpWebRequest;

            byte[]  data = encoding.GetBytes(postData);

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
            return "true";
            #endregion


            #region
            //IMpClient mpClient = new MpClient();
            //AccessTokenGetRequest request = new AccessTokenGetRequest()
            //{
            //    AppIdInfo = new AppIdInfo() { AppID = ConfigurationManager.AppSettings["AppID"].ToString(), AppSecret = ConfigurationManager.AppSettings["AppSecret"].ToString() }
            //};
            //AccessTokenGetResponse response = mpClient.Execute(request);
            //if (response.IsError)
            //{
            //    Console.WriteLine("获取令牌环失败..");
            //    return "false";
            //}
            //var response2 = MessageHandler.SendTextCustomMessage(response.AccessToken.AccessToken, openid, "您好你的交易号为【" + code + "】,凭此交易码即可低值消费，如有疑问可联线在线客服或致电客服电话0411-82780807");
            //if (response2.IsError)
            //{
            //    return "false";
            //}
            //else
            //{
            //    return "true";
            //}
            #endregion
        }
    }
}

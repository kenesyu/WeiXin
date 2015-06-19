using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.IO;
using Weixin.Mp.Sdk.Util;

namespace WebAPP.ClassLib
{
    public class CheckRegisterAndRegister 
    {
        public Dictionary<string, object> RegisterPushInfo(string appid, string secret, string backurl)
        {
            var code = HttpContext.Current.Request.QueryString["Code"] ;
            if (string.IsNullOrEmpty(code))
            {
                var url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri=" + System.Web.HttpUtility.UrlEncode(backurl) + "&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect", appid);
                HttpContext.Current.Response.Redirect(url);
                return null;
                Logger.WriteTxtLog("NoCode");
            }
            else
            {
                //Response.Write("您已绑定");
                Logger.WriteTxtLog("GOOD");
                var client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", appid, secret, code);
                var data = client.DownloadString(url);


                //using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("/log.txt"), true))
                //{
                //    sw.WriteLine("------------- " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " ----------------");
                //    sw.WriteLine("url:" + url);
                //    sw.WriteLine("date:" + data);
                //}

                var serializer = new JavaScriptSerializer();
                var obj = serializer.Deserialize<Dictionary<string, string>>(data);
                string accessToken;
                if (!obj.TryGetValue("access_token", out accessToken))
                    return null;

                var opentid = obj["openid"];
                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", accessToken, opentid);
                data = client.DownloadString(url);
                var userInfo = serializer.Deserialize<Dictionary<string, object>>(data);





                try
                {
                    DBHelper.DataBaseHelper dbHelper = new DBHelper.DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());

                    dbHelper.ExecuteNonQuery("Proc_UserRegistOrUpdate", new SqlParameter[]{  
                        new SqlParameter("@openid",userInfo["openid"]),
                        new SqlParameter("@nickname",userInfo["nickname"]),
                        new SqlParameter("@sex",userInfo["sex"]),
                        new SqlParameter("@language",userInfo["language"]),
                        new SqlParameter("@city",userInfo["city"]),
                        new SqlParameter("@province",userInfo["province"]),
                        new SqlParameter("@country",userInfo["country"]),
                        new SqlParameter("@headimgurl",userInfo["headimgurl"]),

                    }, true);
                    Logger.WriteTxtLog("OK");
                }
                catch (Exception ex)
                {
                    Logger.WriteTxtLog(ex.Message);
                    //throw ex;
                }

                return userInfo;
            }
        }

    }
}
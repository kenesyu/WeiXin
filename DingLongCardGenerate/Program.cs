using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
using DBHelper;
using System.Data;
using System.IO;
using System.Net;
using WeiXin.WexinAPI;

namespace DingLongCardGenerate
{
    class Program
    {
        public static void Main(string[] args)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            //int[] card = GetRandomArray(900, 1000, 9999);
            //int[] password = GetRandomArray(900, 1000, 9999);
            //for (int i = 0; i < 100; i++)
            //{
            //    dbHelper.ExecuteNonQuery("insert into T_DingLongCard (card,password) values ('" + card[i] + "','" + password[i] + "')");
            //}
            //dbHelper.Dispose();
            DataTable dt = dbHelper.ExecuteDataTable("select * from T_HD_Extend where hdid = 3 and isSent = 0");

            foreach (DataRow dr in dt.Rows)
            {
                DataTable dtCard = dbHelper.ExecuteDataTable("select top 1 * from T_DingLongCard where isactive = 0 order by id asc");
                #region ==== 模版消息 ====
                string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + API_Token.AccessToken;
                string openid = dr["openid"].ToString();
                string message = "健身体验次卡";
                string postData = "{"
                   + " \"touser\":\"" + openid + "\","
                   + " \"template_id\":\"7XI7fdqdl-BR05RUGv7giH9ahCRzL2nxLP3IGBQvg4U\","
                   + " \"topcolor\":\"#FF0000\","
                   + " \"data\":{"
                   + "     \"first\":{\"value\":\"鼎龙健身(和平店)次卡申请放发通知！\\n\",\"color\":\"#173177\"},"
                   + "     \"keyword1\":{\"value\":\"" + dr["uname"].ToString() + "\\n\",\"color\":\"#173177\"},"
                   + "     \"keyword2\":{\"value\":\"" + message + "\\n\",\"color\":\"#173177\"},"
                   + "     \"keyword3\":{\"value\":\"微信公众账号 客服\\n\",\"color\":\"#173177\"},"
                    //+ "     \"keyword4\":{\"value\":\"信用卡刷卡\",\"color\":\"#173177\"},"
                    //+ "     \"keyword5\":{\"value\":\"2000\",\"color\":\"#173177\"},"
                   + "     \"remark\":{\"value\":\"\\n您的体验卡号为[" + dtCard.Rows[0]["card"].ToString() + "]验证码[" + dtCard.Rows[0]["password"].ToString() + "] \\n有效期7月11日-7月17日 \\n到店出示此消息即可\",\"color\":\"#173177\"}"
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
                dbHelper.ExecuteNonQuery("update T_HD_Extend set IsSent = 1,SentID = '" + dtCard.Rows[0]["ID"].ToString() + "' where ID =" + dr["id"].ToString());
                dbHelper.ExecuteNonQuery("update T_DingLongCard set IsActive = 1,sentdate = getdate()  where ID =" + dtCard.Rows[0]["ID"].ToString());
                #endregion
            }
            dbHelper.Dispose();
        }

        public static int[] GetRandomArray(int Number, int minNum, int maxNum)
        {
            int j;
            int[] b = new int[Number];
            Random r = new Random();
            for (j = 0; j < Number; j++)
            {
                int i = r.Next(minNum, maxNum + 1);
                int num = 0;
                for (int k = 0; k < j; k++)
                {
                    if (b[k] == i)
                    {
                        num = num + 1;
                    }
                }
                if (num == 0)
                {
                    b[j] = i;
                }
                else
                {
                    j = j - 1;
                }
            }
            return b;
        }
    }
}

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
    /// AdmService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class AdmService : System.Web.Services.WebService
    {

        [WebMethod]
        public string SaveCurrentHD(string Data)
        {
            string[] DataList = Data.Split('|');
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            dbHelper.ExecuteNonQuery("truncate table T_HD_Current");
            foreach (string s in DataList) {
                string[] ss = s.Split('~');
                if (ss.Length == 6) {
                    dbHelper.ExecuteNonQuery("INSERT INTO [T_HD_Current] ([IndexOrder],[Title],[Descriptions],[Url],[PicUrl]) VALUES (@IndexOrder,@Title,@Descriptions,@Url,@PicUrl)",
                        new SqlParameter[]{
                            new SqlParameter("@IndexOrder",ss[4]),
                            new SqlParameter("@Title",ss[0]),
                            new SqlParameter("@Descriptions",ss[1]),
                            new SqlParameter("@Url",ss[3]),
                            new SqlParameter("@PicUrl",ss[2])
                        }
                        );
                }
            }
            dbHelper.Dispose();
            return "保存成功";
        }

        [WebMethod]
        public string SaveSubscribeMsg(string Data) {
            string[] DataList = Data.Split('|');
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            dbHelper.ExecuteNonQuery("truncate table T_Subscribe_Msg");
            foreach (string s in DataList)
            {
                string[] ss = s.Split('~');
                if (ss.Length == 6)
                {
                    dbHelper.ExecuteNonQuery("INSERT INTO [T_Subscribe_Msg] ([IndexOrder],[Title],[Descriptions],[Url],[PicUrl]) VALUES (@IndexOrder,@Title,@Descriptions,@Url,@PicUrl)",
                        new SqlParameter[]{
                            new SqlParameter("@IndexOrder",ss[4]),
                            new SqlParameter("@Title",ss[0]),
                            new SqlParameter("@Descriptions",ss[1]),
                            new SqlParameter("@Url",ss[3]),
                            new SqlParameter("@PicUrl",ss[2])
                        }
                        );
                }
            }
            dbHelper.Dispose();
            return "保存成功";
        }
    }
}

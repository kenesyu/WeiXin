using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DBHelper;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebAPP.ClassLib;

namespace WebAPP.WebApp.DR.service
{
    /// <summary>
    /// drservice 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class drservice : System.Web.Services.WebService
    {
        [WebMethod]
        public string search(string strKey, int Page, int PageSize,string order)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = new DataTable();


            #region ==== PageSize ====
            int minRow = (Page - 1) * PageSize;
            int maxRow = Page * PageSize;
            #endregion

            #region ==== Sql ====
            int MaxPage = 0;
            try
            {
                if (strKey.Trim() != "")
                {
                    dt = dbHelper.ExecuteDataTable("", "select * from V_DR where right('0000'+id,4) = @Key or name like '%" + strKey.Replace("'", "''") + "%' order by " + order , new SqlParameter[] { new SqlParameter("@Key", strKey) });
                    MaxPage = 1;
                }
                else
                {
                    string sql = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY " + order + ") AS rowNum, * FROM V_DR) AS t "
                    + " WHERE rowNum > " + minRow + " AND rowNum <= " + maxRow;

                    dt = dbHelper.ExecuteDataTable("", sql);
                    double Total = Convert.ToDouble(dbHelper.ExecuteDataTable("select count(*) from V_DR").Rows[0][0].ToString());
                    MaxPage = Convert.ToInt32(Math.Ceiling((double)Total / (double)PageSize));
                }
            }
            catch { }
            finally
            {
                dbHelper.Dispose();
            }

            #endregion

            StringBuilder jsonBuilder = new StringBuilder();

            jsonBuilder.AppendLine("{");

            jsonBuilder.AppendLine(" \"TotalPage\": \"" + MaxPage + "\",");
            jsonBuilder.AppendLine(" \"CurrentPage\": \"" + Page + "\",");


            jsonBuilder.AppendLine(" \"Contents\":  [");
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                jsonBuilder.AppendLine(" { ");
                string strclass = "wt-good-item-n mb20";
                if (i % 3 != 0) { strclass += " mr19"; }

                jsonBuilder.AppendLine(" \"class\" : \"" + strclass + "\"");

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.AppendLine(",\"" + dt.Columns[j].ColumnName.ToString() + "\" : \"" + dt.Rows[i - 1][j].ToString() + "\"");
                }

                jsonBuilder.AppendLine(" } ");

                if (i != dt.Rows.Count)
                {
                    jsonBuilder.Append(",");
                }
            }

            jsonBuilder.AppendLine("]");

            jsonBuilder.AppendLine("}");
            return jsonBuilder.ToString();
        }

        [WebMethod]
        public string supportme(string openid ,string toopenid) 
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "select * from DR_TouPiao where openid = @openid and toopenid = @toopenid", new SqlParameter[]{
                new SqlParameter("@openid",openid), new SqlParameter("toopenid",toopenid)
            });

            if (dt.Rows.Count > 0)
            {
                dbHelper.Dispose();
                return "您已经支持过该选手了，请不要重复投票";
            }
            else
            {
                dbHelper.ExecuteNonQuery("insert into DR_TouPiao (openid,toopenid,createtime) values (@openid,@toopenid,GETDATE())", new SqlParameter[]{
                    new SqlParameter("@openid",openid), new SqlParameter("toopenid",toopenid)
                });

                dbHelper.ExecuteNonQuery("update DR_BM set CountNum = isnull(CountNum,0) + 1 where openid = @toopenid", new SqlParameter[] { new SqlParameter("@toopenid", toopenid) });
                return "投票成功感谢您的支持";
            }
        }

        [WebMethod]
        public string GetInput(string id) {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "select * from v_dr where id = @id", new SqlParameter[] { new SqlParameter("@id", id) });
            dbHelper.Dispose();



            StringBuilder jsonBuilder = new StringBuilder();

            jsonBuilder.AppendLine("{");

            //jsonBuilder.AppendLine(" \"TotalPage\": \"" + MaxPage + "\",");
            //jsonBuilder.AppendLine(" \"CurrentPage\": \"" + Page + "\",");


            jsonBuilder.AppendLine(" \"Contents\":  [");
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                jsonBuilder.AppendLine(" { ");
                string strclass = "wt-good-item-n mb20";
                if (i % 3 != 0) { strclass += " mr19"; }

                jsonBuilder.AppendLine(" \"class\" : \"" + strclass + "\"");

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.AppendLine(",\"" + dt.Columns[j].ColumnName.ToString() + "\" : \"" + dt.Rows[i - 1][j].ToString() + "\"");
                }

                jsonBuilder.AppendLine(" } ");

                if (i != dt.Rows.Count)
                {
                    jsonBuilder.Append(",");
                }
            }

            jsonBuilder.AppendLine("]");

            jsonBuilder.AppendLine("}");
            return jsonBuilder.ToString();
        }

        [WebMethod]
        public string SaveResult(string id,string Result)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            string[] ResultList = Result.Split(':');
            if (ResultList.Length == 3)
            {
                int h = Convert.ToInt32(ResultList[0]) * 60 * 60;
                int m = Convert.ToInt32(ResultList[1]) * 60;
                int s = Convert.ToInt32(ResultList[2]);

                dbHelper.ExecuteNonQuery("update DR_BM set Result = @Result where id = @id", new SqlParameter[] { new SqlParameter("@id", id), new SqlParameter("@Result", h + m + s) });


                dbHelper.Dispose();
                return "录入成功";
            }
            else {
                return "时间格式错误"; ;
            }
        }

        [WebMethod]
        public string Login(string pass) {
            if (pass == "admin1234")
            {
                return "1";
            }
            else {
                return "";
            }
        }
    }
}

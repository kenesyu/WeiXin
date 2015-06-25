using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using DBHelper;

namespace WebAPP.Handler
{
    public class UploadMulti : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
                string refid = context.Request.Form["coachid"].ToString();
                string uploadPath = context.Server.MapPath(context.Request.ApplicationPath + "/img/coachpic/");
                string retID = string.Empty;
                for (int j = 0; j < context.Request.Files.Count; j++)
                {
                    HttpPostedFile uploadFile = context.Request.Files[j];
                    // if there was a file uploded

                    if (uploadFile.ContentLength > 0)
                    {
                        string extName = uploadFile.FileName.Substring(uploadFile.FileName.LastIndexOf('.'));
                        string newName = DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.Ticks.ToString() + extName.ToString();

                        //string sqlInsert = "insert into T_Attachments ([FileOrgName],[FileNewName],[UploadDate],[TempID]) values ('" + uploadFile.FileName + "','" + newName + "',GETDATE(),'" + HttpContext.Current.Request.Cookies["TempID"].Value.ToString() + "'";
                        //dbHelper.ExecuteScalar(sqlInsert);
                        retID = dbHelper.ExecuteScalar("insert into [T_CoachPhoto] ([CoachID],[Pic]) values (@CoachID,@Pic);select @@identity",
                            new System.Data.SqlClient.SqlParameter[]{
                                new SqlParameter("@CoachID",refid),
                                new SqlParameter("@Pic",newName),
                            }
                            ).ToString();
                        uploadFile.SaveAs(Path.Combine(uploadPath, newName));
                    }
                }
                HttpContext.Current.Response.Write(retID.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
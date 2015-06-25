using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using DBHelper;

namespace WebAPP.Handler
{
    public class UploadAvatar : IHttpHandler
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
                string retName = string.Empty;

                string uploadPath = context.Server.MapPath(context.Request.ApplicationPath + "/img/avatar/");
                for (int j = 0; j < context.Request.Files.Count; j++)
                {
                    HttpPostedFile uploadFile = context.Request.Files[j];
                    // if there was a file uploded
                    
                    if (uploadFile.ContentLength > 0)
                    {
                        string extName = uploadFile.FileName.Substring(uploadFile.FileName.LastIndexOf('.'));
                        string newName = DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.Ticks.ToString() + extName.ToString();
                        retName = newName;
                        //string newName = DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.Ticks.ToString() + extName.ToString();
                        uploadFile.SaveAs(Path.Combine(uploadPath, newName));
                        //StorageHelper.UploadToStorge("uploadfiles", uploadFile.InputStream, newName);
                    }
                }
                HttpContext.Current.Response.Write(retName.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
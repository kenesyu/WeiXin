using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Configuration;
using System.Data;

namespace WebAPP.Adm
{
    public partial class gzh_gzts : System.Web.UI.Page
    {
        public string retHtml = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Login"] == null || Session["Login"].ToString() == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Bind();
                }
            }
        }

        private void Bind() {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("select * from T_Subscribe_Msg order by indexOrder");
            foreach (DataRow dr in dt.Rows)
            {
               retHtml +="<tr isdata='true'>";
               retHtml +="    <td width=\"20%\"><input type=\"text\" class=\"dfinput\" style=\"width:95%\" value=\""+dr["Title"].ToString()+"\" /></td>";
               retHtml +="    <td width=\"20%\"><input type=\"text\" class=\"dfinput\" style=\"width:95%\" value=\""+dr["Descriptions"].ToString()+"\" /></td>";
               retHtml +="    <td width=\"20%\"><input type=\"text\" class=\"dfinput\" style=\"width:95%\" value=\""+dr["PicUrl"].ToString()+"\" /></td>";
               retHtml +="    <td width=\"20%\"><input type=\"text\" class=\"dfinput\" style=\"width:95%\" value=\""+dr["Url"].ToString()+"\" /></td>";
               retHtml +="    <td><input type=\"text\" class=\"dfinput\" value=\""+dr["IndexOrder"].ToString()+"\"/></td>";
               retHtml += "   <td><input type=\"button\" class=\"btn\" value=\"移除\" onclick='removetr(this);' /></td>";
               retHtml += "</tr> ";
            }
        }
    }
}
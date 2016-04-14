using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebAPP.Adm
{
    public partial class TP_Create : System.Web.UI.Page
    {
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
                    if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                    {
                        BindData(Request.QueryString["id"].ToString());
                    }
                }
            }
        }

        private void BindData(string id)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("","select * from T_TP where id = @id", new SqlParameter[]{
                new SqlParameter("@id",id)
            });
            if (dt.Rows.Count > 0) {
                this.txtid.Value = dt.Rows[0]["id"].ToString();
                this.txtName.Value = dt.Rows[0]["TPName"].ToString();
                this.txtStartTime.Value = dt.Rows[0]["StartTime"].ToString();
                this.txtEndTime.Value = dt.Rows[0]["EndTime"].ToString();
            }
            dbHelper.Dispose();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            if (this.txtid.Value == "0")
            {
                dbHelper.ExecuteNonQuery("INSERT INTO [T_TP] ([TPName],[StartTime],[EndTime]) VALUES (@TPName,@StartTime,@EndTime)", new SqlParameter[]{
                    new SqlParameter("@TPName", this.txtName.Value),
                    new SqlParameter("@StartTime",this.txtStartTime.Value),
                    new SqlParameter("@EndTime",this.txtEndTime.Value)
                });
            }
            else
            {
                dbHelper.ExecuteNonQuery("UPDATE T_TP SET TPName = @TPName,@StartTime = @StartTime,EndTime = @EndTime WHERE id=@id", new SqlParameter[]{
                    new SqlParameter("@TPName", this.txtName.Value),
                    new SqlParameter("@StartTime",this.txtStartTime.Value),
                    new SqlParameter("@EndTime",this.txtEndTime.Value),
                    new SqlParameter("@id",this.txtid.Value)
                });

            }
            dbHelper.Dispose();
            Response.Redirect("TP_List.aspx");
        }
    }
}
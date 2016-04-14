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
    public partial class TP_Person : System.Web.UI.Page
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
                        this.txtTPID.Value = Request.QueryString["id"].ToString();
                        BindData(1);
                    }
                }
            }
        }

        private void BindData(int Page)
        {
            int PageSize = 10;
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            string strWhere = " TPID = " + this.txtTPID.Value;
            SqlParameter[] splist = new SqlParameter[]{
                new SqlParameter("@TableName","T_TP_Person"),
                new SqlParameter("@ReFieldsStr","*"),
                new SqlParameter("@OrderString","PersonNo asc"),
                new SqlParameter("@WhereString",strWhere),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@PageIndex",Page),
                new SqlParameter("@TotalRecord",ParameterDirection.Output)
            };

            splist[6].Direction = ParameterDirection.Output;
            DataTable dt = dbHelper.ExecuteDataTable("dtList", "Proc_ShowList", splist, true);

            this.repList.DataSource = dt;
            this.repList.DataBind();

            dbHelper.Dispose();

            this.AspNetPager1.RecordCount = Convert.ToInt32(splist[6].Value.ToString()); //(int)(dbHelper.ExecuteScalar("select count(*) from T_Coachs"));
            this.AspNetPager1.PageSize = PageSize;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            dbHelper.ExecuteNonQuery("insert into T_TP_Person (TPID,PersonNo,PersonName,CountNum,Pic) values (@TPID,@PersonNo,@PersonName,@CountNum,@Pic)",
                 new SqlParameter[]{
                    new SqlParameter("@TPID",this.txtTPID.Value),
                    new SqlParameter("@PersonNo",this.txtNo.Value),
                    new SqlParameter("@PersonName",this.txtName.Value),
                    new SqlParameter("@CountNum","0"),
                    new SqlParameter("@Pic",this.txtAvatar.Value)
                 }
                );
            dbHelper.Dispose();
            Response.Redirect("TP_Person.aspx?id=" + this.txtTPID.Value);
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            BindData(e.NewPageIndex);
        }

        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string cmdArg = e.CommandArgument.ToString();
            string cmdName = e.CommandName.ToString();
            if (cmdName == "Del")
            {
                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
                dbHelper.ExecuteNonQuery("Delete from T_TP_Person where id =@id",
                     new SqlParameter[]{
                    new SqlParameter("@id",cmdArg)
                 }
                 );
                dbHelper.Dispose();
                Response.Redirect("TP_Person.aspx?id=" + this.txtTPID.Value);
            }
        }
    }
}
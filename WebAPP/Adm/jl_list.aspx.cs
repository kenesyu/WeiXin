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
    public partial class jl_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindData(1);
            }
        }

        private void BindData(int Page)
        {
            int PageSize = 10;
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            string strWhere = string.Empty;
            if (this.txtName.Value.Trim() != "") {
                strWhere += " coachname = '" + this.txtName.Value.ToString() + "'";
            }

            SqlParameter[] splist = new SqlParameter[]{
                new SqlParameter("@TableName","T_Coachs"),
                new SqlParameter("@ReFieldsStr","*"),
                new SqlParameter("@OrderString","ID desc"),
                new SqlParameter("@WhereString",strWhere),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@PageIndex",Page),
                new SqlParameter("@TotalRecord",ParameterDirection.Output)
            };

            splist[6].Direction = ParameterDirection.Output;
            DataTable dt = dbHelper.ExecuteDataTable("dtList", "Proc_ShowList", splist,true);

            this.repList.DataSource = dt;
            this.repList.DataBind();

            this.AspNetPager1.RecordCount = Convert.ToInt32(splist[6].Value.ToString()); //(int)(dbHelper.ExecuteScalar("select count(*) from T_Coachs"));
            this.AspNetPager1.PageSize = PageSize;
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            BindData(e.NewPageIndex);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(1);
        }
    }
}
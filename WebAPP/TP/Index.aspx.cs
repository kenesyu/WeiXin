using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Configuration;
using System.Data;

namespace WebAPP.TP
{
    public partial class Index : System.Web.UI.Page
    {
        public string strTitle = string.Empty;
        public string strDisplay = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string tpid = string.Empty;
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                tpid = Request.QueryString["id"].ToString();
            }
            else {
                Response.End();
            }



            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("SELECT ROW_NUMBER() OVER(ORDER BY CountNum Desc) AS rowNum, * FROM T_TP_Person where TPID = '" + tpid + "'  ");
            if (searchKey.Value.Trim() != "")
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = " PersonNo = '" + searchKey.Value.Trim().ToString() + "'";
                this.repList.DataSource = dv.Table;
                this.repList.DataBind();
            }
            else
            {
                this.repList.DataSource = dt;
                this.repList.DataBind();
            }

            DataTable dtTP = dbHelper.ExecuteDataTable("select * from T_TP where id=" + tpid);
            strTitle = dtTP.Rows[0]["TPName"].ToString();
            DateTime now = DateTime.Now;

            if (Convert.ToDateTime(dtTP.Rows[0]["StartTime"]) < now && Convert.ToDateTime(dtTP.Rows[0]["EndTime"]) > now)
            {
                this.strDisplay = "";
            }
            else {
                this.strDisplay = "display:none";
            }



            dbHelper.Dispose();

        }
    }
}
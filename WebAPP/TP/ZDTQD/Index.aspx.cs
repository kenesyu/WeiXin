using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Configuration;
using System.Data;

namespace WebAPP.TP.ZDTQD
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());

            DataTable dt = dbHelper.ExecuteDataTable("SELECT ROW_NUMBER() OVER(ORDER BY CountNum Desc) AS rowNum, [Name],CountNum,right('000'+cast(id as varchar),3) as id FROM T_ZDTQD ");

            if (searchKey.Value.Trim() != "")
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = " id = '" + searchKey.Value.Trim().ToString() + "'";
                this.repList.DataSource = dv.Table;
                this.repList.DataBind();
            }
            else
            {
                this.repList.DataSource = dt;
                this.repList.DataBind();
            }
            dbHelper.Dispose();

        }
    }
}
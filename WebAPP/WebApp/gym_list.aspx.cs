using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Data;
using System.Configuration;

namespace WebAPP.WebApp
{
    public partial class gym_list : System.Web.UI.Page
    {
        string serRegion = string.Empty;
        string serSport = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["r"] != null && Request.QueryString["r"].ToString() != "")
                {
                    serRegion = Request.QueryString["r"].ToString();
                }

                if (Request.QueryString["s"] != null && Request.QueryString["s"].ToString() != "")
                {
                    serSport = Request.QueryString["s"].ToString();
                }
                BindData();
            }
        }


        private void BindData()
        {

            string strWhere = string.Empty;
            if (serRegion != "" && serRegion != "undefined") { strWhere += " and RegionID ='" + serRegion + "'"; }
            if (serSport != "" && serSport != "undefined") { strWhere += " and TypeID = '" + serSport + "'"; }


            DataBaseHelper dbhelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());


            this.repMenuRegion.DataSource = dbhelper.ExecuteDataTable("select * from T_Region");
            this.repMenuSports.DataSource = dbhelper.ExecuteDataTable("select * from T_GYM_Type");

            this.repMenuSports.DataBind();
            this.repMenuRegion.DataBind();

            DataTable dt = dbhelper.ExecuteDataTable("select * from V_GYMs where OverdueDate >= GETDATE() " + strWhere);
            this.BindList.DataSource = dt;
            this.BindList.DataBind();
        }

    }
}
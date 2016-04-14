using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WebAPP.Adm
{
    public partial class hd_create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    Bind(Request.QueryString["id"].ToString());
                }
            }
        }

        private void Bind(string id)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("","select * from T_Products where ProductID=@id", new SqlParameter[]{
                new SqlParameter("@id",id)
            });

            if (dt.Rows.Count > 0)
            {
                this.txtid.Value = id;
                this.txthdName.Value = dt.Rows[0]["ProductName"].ToString();
                this.txtNewPrice.Value = dt.Rows[0]["NewPrice"].ToString();
                this.txtOldPrice.Value = dt.Rows[0]["OldPrice"].ToString();
                this.txtQuantity.Value = dt.Rows[0]["Quantity"].ToString();
                this.txtEndTime.Value = dt.Rows[0]["EndTime"].ToString();
                this.txtDetails.Value = dt.Rows[0]["Details"].ToString();
                this.txtHDTime.Value = dt.Rows[0]["HDTime"].ToString();
            }
            dbHelper.Dispose();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            if (this.txtid.Value == "")
            {
                string sql = "INSERT INTO T_Products (ProductName,NewPrice,OldPrice,Quantity,InventoryNum,EndTime,Details,HDTime) "
                        + " values (@ProductName,@NewPrice,@OldPrice,@Quantity,@InventoryNum,@EndTime,@Details,@HDTime)";

                dbHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                    new SqlParameter("@ProductName",this.txthdName.Value),
                    new SqlParameter("@NewPrice",this.txtNewPrice.Value),
                    new SqlParameter("@OldPrice",this.txtOldPrice.Value),
                    new SqlParameter("@Quantity",this.txtQuantity.Value),
                    new SqlParameter("@InventoryNum",this.txtQuantity.Value),
                    new SqlParameter("@EndTime",this.txtEndTime.Value),
                    new SqlParameter("@Details",this.txtDetails.Value),
                    new SqlParameter("@HDTime",this.txtHDTime.Value)
                });
            }
            else {
                string sql = "UPDATE T_Products set ProductName = @ProductName,NewPrice=@NewPrice,OldPrice=@OldPrice,Quantity=@Quantity,InventoryNum=@InventoryNum,EndTime=@EndTime,Details=@Details,HDTime=@HDTime where ProductID=@ProductID";
                dbHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                    new SqlParameter("@ProductName",this.txthdName.Value),
                    new SqlParameter("@NewPrice",this.txtNewPrice.Value),
                    new SqlParameter("@OldPrice",this.txtOldPrice.Value),
                    new SqlParameter("@Quantity",this.txtQuantity.Value),
                    new SqlParameter("@InventoryNum",this.txtQuantity.Value),
                    new SqlParameter("@EndTime",this.txtEndTime.Value),
                    new SqlParameter("@Details",this.txtDetails.Value),
                    new SqlParameter("@ProductID",this.txtid.Value),
                    new SqlParameter("@HDTime",this.txtHDTime.Value)
                });
            }
            dbHelper.Dispose();
        }
    }
}
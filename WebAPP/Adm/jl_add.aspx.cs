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
    public partial class jl_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                InitControl();
            }
        }

        private void InitControl() {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dtSport = dbHelper.ExecuteDataTable("select * from T_Sports");
            foreach (DataRow dr in dtSport.Rows) {
                this.selSoports.Items.Add(new ListItem(dr["SportName"].ToString(), dr["SportID"].ToString()));
            }

            DataTable dtArea = dbHelper.ExecuteDataTable("select * from T_Region");

            foreach (DataRow dr in dtArea.Rows)
            {
                this.CheckBoxList1.Items.Add(new ListItem(dr["RegionName"].ToString(), dr["RegionID"].ToString()));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtcoachid.Value == "" || this.txtcoachid.Value == "0")
            {
                string insertSql = "INSERT INTO [WeixinWeb].[dbo].[T_Coachs] "
                                + "([CoachName],[Sex],[Avatar],[Signature],[SportID],[Age],[Info],[Tel],[WeiXin],[Views],[openid],[OverdueDate],[JoinDate]) "
                                + " VALUES "
                                + "(@CoachName,@Sex,@Avatar,@Signature,@SportID, @Age, @Info,@Tel,@WeiXin, 100,openid, @OverdueDate,GETDATE())";
            }
            else
            {
                //update 
            }
        }
    }
}
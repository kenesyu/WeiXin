using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Data;
using System.Configuration;
using WebAPP.ClassLib;

namespace WebAPP.WebApp
{
    public partial class gym_details : System.Web.UI.Page
    {
        public string GYMName = string.Empty;
        public string ViewCount;
        public string GymID = string.Empty;
        public string IssSubscribe = string.Empty;
        public string IsShop = string.Empty;
        public string openid = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["gymid"] != null && Request.QueryString["gymid"].ToString() != "")
                {
                    BindData(Request.QueryString["gymid"].ToString());
                    //CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                    //Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString());
                    //openid = userinfo["openid"].ToString();
                }
            }
        }

        private void BindData(string ID)
        {
            DataBaseHelper dbhelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dtInfo = dbhelper.ExecuteDataTable("select * from V_GYMs where GYMID =" + ID);
            DataTable dtPicList = dbhelper.ExecuteDataTable("select * from T_GYM_Photo where GYMID =" + ID);
            this.repPicList.DataSource = dtPicList;
            this.repPicList.DataBind();

            if (dtInfo.Rows.Count > 0)
            {
                GymID = ID;
                GYMName = dtInfo.Rows[0]["GYMName"].ToString();
                this.lblAddress.Text = dtInfo.Rows[0]["Address"].ToString();
                this.lblTel.Text = dtInfo.Rows[0]["Tel"].ToString();
                this.lblType.Text = dtInfo.Rows[0]["TypeName"].ToString();
                this.lblRegion.Text = dtInfo.Rows[0]["RegionName"].ToString();
                this.lblDetails.Text = dtInfo.Rows[0]["Details"].ToString();
                this.lblNewsLine.Text = dtInfo.Rows[0]["NewsLine"].ToString();
                IssSubscribe = dtInfo.Rows[0]["IssSubscribe"].ToString();
                IsShop = dtInfo.Rows[0]["IsShop"].ToString();
            //    CoachName = dtInfo.Rows[0]["CoachName"].ToString();
            //    lblName.Text = dtInfo.Rows[0]["CoachName"].ToString();
            //    lblSex.Text = dtInfo.Rows[0]["Sex"].ToString();
            //    lblAge.Text = dtInfo.Rows[0]["Age"].ToString();
            //    lblRegion.Text = dtInfo.Rows[0]["RegionName"].ToString();
            //    lblWeiXin = dtInfo.Rows[0]["WeiXin"].ToString();
            //    lblTel = dtInfo.Rows[0]["Tel"].ToString();
            //    //lblTel.Text = dtInfo.Rows[0]["Tel"].ToString();
            //    //lblTel.
                ViewCount = dtInfo.Rows[0]["Views"].ToString();
            //    lblSportName.Text = dtInfo.Rows[0]["SportName"].ToString();
            //    lblInfo.Text = dtInfo.Rows[0]["Info"].ToString();
                dbhelper.ExecuteNonQuery("update T_GYM set Views = (isnull(Views,0) + 1) where  GYMID =" + ID);
            }

            ////this.BindList.DataSource = dt;
            ////this.BindList.DataBind();
        }
    }
}
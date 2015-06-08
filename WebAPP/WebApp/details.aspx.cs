using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Data;
using System.Configuration;
using WeiXin.WexinAPI;
using System.IO;
using System.Text;
using System.Net;
using WebAPP.ClassLib;
using System.Collections;

namespace WebAPP.WebApp
{
    public partial class details : System.Web.UI.Page
    {
        public string lblTel = "";
        public string lblWeiXin = "";
        public string CoachName = "";
        public string ViewCount = "";
        public string openid = string.Empty;
        public string sportname = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
                {
                    BindData(Request.QueryString["ID"].ToString());
                    CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                    Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString());
                    //ViewState.Add("openid", userinfo["openid"].ToString());
                    openid = userinfo["openid"].ToString();
                }
            }
        }

        private void BindData(string ID)
        {
            DataBaseHelper dbhelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dtInfo = dbhelper.ExecuteDataTable("select * from V_Coachs where id =" + ID);
            DataTable dtPicList = dbhelper.ExecuteDataTable("select * from T_CoachPhoto where CoachID =" + ID);
            this.repPicList.DataSource = dtPicList;
            this.repPicList.DataBind();

            if (dtInfo.Rows.Count > 0)
            {
                CoachName = dtInfo.Rows[0]["CoachName"].ToString();
                lblName.Text = dtInfo.Rows[0]["CoachName"].ToString();
                lblSex.Text = dtInfo.Rows[0]["Sex"].ToString();
                lblAge.Text = dtInfo.Rows[0]["Age"].ToString();
                lblRegion.Text = dtInfo.Rows[0]["RegionName"].ToString();
                lblWeiXin = dtInfo.Rows[0]["WeiXin"].ToString();
                lblTel = dtInfo.Rows[0]["Tel"].ToString();
                //lblTel.Text = dtInfo.Rows[0]["Tel"].ToString();
                //lblTel.
                ViewCount = dtInfo.Rows[0]["Views"].ToString();
                lblSportName.Text = dtInfo.Rows[0]["SportName"].ToString();
                sportname = dtInfo.Rows[0]["SportName"].ToString();
                lblInfo.Text = dtInfo.Rows[0]["Info"].ToString();
                //ViewState.Add("message", "我对" + dtInfo.Rows[0]["SportName"].ToString() + "教练[" + dtInfo.Rows[0]["CoachName"].ToString() + "]感兴趣想要咨询");
                dbhelper.ExecuteNonQuery("update T_Coachs set Views = (isnull(Views,0) + 1) where  ID =" + ID);
            }
            dbhelper.Dispose();
            //this.BindList.DataSource = dt;
            //this.BindList.DataBind();
        }
    }
}
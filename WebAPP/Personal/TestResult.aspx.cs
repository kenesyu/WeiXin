using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAPP.ClassLib;
using System.Configuration;
using System.Data;
using DBHelper;
using System.Data.SqlClient;
namespace WebAPP.Personal
{
    public partial class TestResult : System.Web.UI.Page
    {
        public string openid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {
                if (Request.QueryString["op"] == null || Request.QueryString["op"].ToString() == "")
                {
                    CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                    openid = aa.GetUserOpenId(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(), "TestResult");
                }
                else
                {
                    openid = Request.QueryString["op"].ToString();
                }

                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
                DataTable dt = dbHelper.ExecuteDataTable("", "select a.*,b.nickname,b.headimgurl from T_Question_Answer a inner join t_userinfo b on a.openid = b.openid where a.openid=@openid order by a.id desc", new SqlParameter[]{
                    new SqlParameter("@openid",openid)
                });


                DataTable dtCheckTable = dbHelper.ExecuteDataTable("select * from T_Question_DropData");
                DataTable dtResult = dbHelper.ExecuteDataTable("select * from T_Question_Result");


                if (dt.Rows.Count > 0) {
                    this.lblName.Text = dt.Rows[0]["Nickname"].ToString();
                    this.imgheader.Src = dt.Rows[0]["headimgurl"].ToString();
                    this.lblstAge.Text = dt.Rows[0]["Age"].ToString();

                    #region ==== BMI ====
                    string BMI = (Convert.ToDouble(dt.Rows[0]["weight"].ToString()) / (Convert.ToDouble(dt.Rows[0]["height"].ToString()) * Convert.ToDouble(dt.Rows[0]["height"].ToString())) * 10000).ToString("0.0");
                    DataRow[] dr = dtResult.Select("queryKey='BMI' and maxValue >= '" + BMI + "' and minValue <= '" + BMI + "'");
                    if (dr.Length > 0) {
                        this.lblBMI.Text = "<p>" + string.Format(dr[0]["Result"].ToString(), BMI) + "</p><p>" + dr[0]["RefSource"].ToString() + "</p>";
                    }
                    #endregion

                    #region ==== WHR ====
                    string WHR = (Convert.ToDouble(dt.Rows[0]["yw"].ToString()) / Convert.ToDouble(dt.Rows[0]["tw"].ToString())).ToString("0.0");
                    dr = dtResult.Select("queryKey='WHR' and filter = '" + dt.Rows[0]["sex"].ToString() + "' and maxValue >= '" + WHR + "' and minValue <= '" + WHR + "'");
                    if (dr.Length > 0)
                    {
                        this.lblWHR.Text = "<p>" + string.Format(dr[0]["Result"].ToString(), WHR) + "</p><p>" + dr[0]["RefSource"].ToString() + "</p>";
                    }
                    #endregion

                    #region ==== 心率 ====
                    string XL = dt.Rows[0]["xl"].ToString();
                    string ZDXL = (220 - Convert.ToDouble(XL)).ToString("0");
                    string BXL = ((220 - Convert.ToDouble(dt.Rows[0]["Age"].ToString()) - Convert.ToDouble(XL)) * 0.6).ToString("0")
                        + "-"
                        + ((220 - Convert.ToDouble(dt.Rows[0]["Age"].ToString()) - Convert.ToDouble(XL)) * 0.75).ToString("0");

                    dr = dtResult.Select("queryKey='XL' and maxValue >='"+XL+"' and minValue <='"+XL+"'");
                    DataRow[] drZDXL = dtResult.Select("queryKey='ZDXL'");
                    DataRow[] drBXL = dtResult.Select("queryKey='BXL'");

                    if (dr.Length > 0)
                    {
                        string aa =  "<p>" + string.Format(dr[0]["Result"].ToString(), XL) + "</p><p>" + dr[0]["RefSource"].ToString() + "</p>";
                        aa += "</br>";
                        aa += "<p>" + string.Format(drZDXL[0]["Result"].ToString(), ZDXL) + "</p><p>" + drZDXL[0]["RefSource"].ToString() + "</p>";
                        aa += "</br>";
                        aa += "<p>" + string.Format(drBXL[0]["Result"].ToString(), BXL) + "</p><p>" + drBXL[0]["RefSource"].ToString() + "</p>";
                        this.lblXL.Text = aa;

                    }
                    #endregion

                    #region ==== 心肺功能 ====
                    string BQSY = dt.Rows[0]["bqsy"].ToString();
                    dr = dtResult.Select("queryKey='BQSY' and ResultKey = '" + BQSY + "'");
                    if (dr.Length > 0)
                    {
                        this.lblBQSY.Text = "<p>" + dr[0]["Result"].ToString() + "</p><p>" + dr[0]["RefSource"].ToString() + "</p>";
                    }
                    #endregion

                    #region ==== 平衡能力 ====
                    string PHNL = dt.Rows[0]["phnl"].ToString();
                    dr = dtResult.Select("queryKey='PHNL' and ResultKey = '" + PHNL + "'");
                    if (dr.Length > 0)
                    {
                        this.lblPHNL.Text = "<p>" + dr[0]["Result"].ToString() + "</p><p>" + dr[0]["RefSource"].ToString() + "</p>";
                    }
                    #endregion

                    #region ==== 吸烟指数 ====
                    string XYZS = dt.Rows[0]["xyzs"].ToString();
                    dr = dtResult.Select("queryKey='XYZS' and ResultKey = '" + XYZS + "'");
                    if (dr.Length > 0)
                    {
                        this.lblXYZS.Text = "<p>" + dr[0]["Result"].ToString() + "</p><p>" + dr[0]["RefSource"].ToString() + "</p>";
                    }
                    #endregion

                    #region ==== 运动习惯 ====
                    string YDXG = dt.Rows[0]["ydxg"].ToString();
                    dr = dtResult.Select("queryKey='YDXG' and ResultKey = '" + YDXG + "'");
                    if (dr.Length > 0)
                    {
                        this.lblYDXG.Text = "<p>" + dr[0]["Result"].ToString() + "</p><p>" + dr[0]["RefSource"].ToString() + "</p>";
                    }
                    #endregion

                    #region ==== 亚健康指数 ====
                    string YJKZZ = dt.Rows[0]["yjkzz"].ToString();
                    dr = dtResult.Select("queryKey='YJKZZ' and ResultKey = '" + YJKZZ + "'");
                    if (dr.Length > 0)
                    {
                        this.lblYJKZZ.Text = "<p>" + dr[0]["Result"].ToString() + "</p><p>" + dr[0]["RefSource"].ToString() + "</p>";
                    }
                    #endregion

                }
                dbHelper.Dispose();
            }
        }
    }
}
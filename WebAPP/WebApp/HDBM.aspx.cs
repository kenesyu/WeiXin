using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAPP.ClassLib;
using System.Configuration;
using DBHelper;
using System.Data;
using System.Data.SqlClient;
namespace WebAPP.WebApp
{
    
    public partial class HDBM : System.Web.UI.Page
    {
        public string openid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(), "HDBM");
                openid = userinfo["openid"].ToString();
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
                    DataTable dt = dbHelper.ExecuteDataTable("", "select * from T_HD where id= @id and isopen = 1", new SqlParameter[] { new SqlParameter("@id", Request.QueryString["id"].ToString()) });
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dta = dbHelper.ExecuteDataTable("","select * from T_HD_Extend where openid = @openid and HDID = @id", new SqlParameter[]{
                            new SqlParameter("@openid",openid),
                            new SqlParameter("@id",Request.QueryString["id"].ToString())
                        });
                        this.txthdid.Value = dt.Rows[0]["id"].ToString();
                        this.txtHDName.Value = dt.Rows[0]["HDName"].ToString();
                        this.txtopenid.Value = openid;
                        this.txtNeedPay.Value = dt.Rows[0]["NeedPay"].ToString();
                        if (dta.Rows.Count > 0 && dt.Rows[0]["NeedPay"].ToString() != "1")
                        {
                            Response.Write("<font size='24px'>您已经报过名了，请把机会让给其它的小伙伴吧</font>");
                            Response.End();
                        }
                        else if (dta.Rows.Count > 0 && dt.Rows[0]["NeedPay"].ToString() == "1" && dta.Rows[0]["IsPay"].ToString() != "1")
                        {
                            Response.Redirect("WXPay/WeiPayHD.aspx?hdid=" + dt.Rows[0]["id"].ToString() + "&extid=" + dta.Rows[0]["id"].ToString());
                        }
                    }
                    else
                    {
                        Response.Write("<font size='24px'>您来晚啦，名额已满或活动已结束.</font>");
                        Response.End();
                    }
                    dbHelper.Dispose();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            string ret = string.Empty;
            if (this.txtid.Value == "")
            {
                string sql = "INSERT INTO [T_HD_Extend]([HDID],[openid],[uname],[utel],[usex],[createdate],[PersonCount]) VALUES "
                        + "(@hdid,@openid,@uname,@utel,@usex,GETDATE(),@personcount);select @@identity";
                ret = dbHelper.ExecuteScalar(sql, new SqlParameter[] { 
                    new SqlParameter("@hdid",this.txthdid.Value),
                    new SqlParameter("@openid",this.txtopenid.Value),
                    new SqlParameter("@uname",this.txtName.Value),
                    new SqlParameter("@utel",this.txtTel.Value),
                    new SqlParameter("@usex",this.selSex.Value),
                    new SqlParameter("@personcount",this.selPersonCount.Value),
                }).ToString();
            }
            dbHelper.Dispose();
            this.btnSave.Enabled = false;
            if (this.txtNeedPay.Value == "1") {
                Response.Redirect("WXPay/WeiPayHD.aspx?hdid=" + this.txthdid.Value + "&extid=" + ret);
            }
            Response.Write("<script>alert('您的报名信息我们已经收到我们会尽快与您取得联系');</script>");
        }
    }
}
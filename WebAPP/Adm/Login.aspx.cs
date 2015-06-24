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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null && Session["Login"].ToString() != "") {
                Response.Redirect("Main.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dtLogin = dbHelper.ExecuteDataTable("loginUser","select * from T_Sys_Admin where username = @username and password = @password", new SqlParameter[]{
                new SqlParameter("@username" , this.txtUserName.Value.Trim()), new SqlParameter("@password",this.txtPassword.Value)
            });
            dbHelper.Dispose();
            if (dtLogin.Rows.Count > 0)
            {
                Session.Add("Login", dtLogin.Rows[0]["ID"].ToString());
                Response.Redirect("Main.aspx");
            }
            else
            {
                //this.RequiredFieldValidator2.Text = "用户名或密码不正确";
                Response.Write("<script>alert(\"用户名或密码不正确\");location.href='Login.aspx'</script>");
                //Response.Redirect("Login.aspx");
            }
        }
    }
}
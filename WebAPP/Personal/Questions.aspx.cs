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
using System.Text;

namespace WebAPP.Personal
{
    public partial class Questions : System.Web.UI.Page
    {
        public int intPage = 0;
        public int MaxPage = 3;
        public string strHtml = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["p"] != null && Request.QueryString["p"].ToString() != "") 
                && (Request.QueryString["openid"] != null && Request.QueryString["openid"].ToString() != ""))
            {
                if (int.TryParse(Request.QueryString["p"].ToString(), out intPage))
                {
                    DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
                    if (intPage >= 1 && intPage <= MaxPage)
                    {
                        #region ==== Page ====
                        this.LinkPre.Text = "上一页";
                        if (intPage == 1) {
                            this.LinkPre.Enabled = false;
                        }

                        if (intPage == 3)
                        {
                            this.LinkNextOrSubmit.Text = "提交测试";
                        }
                        else {
                            this.LinkNextOrSubmit.Text = "下一页";
                        }
                        #endregion

                        DataTable dt = dbHelper.ExecuteDataTable("", "select * from T_Questions where page = @p order by QuestionID asc", new SqlParameter[]{ 
                            new SqlParameter("@p",intPage)
                        });

                        StringBuilder sbHtml = new StringBuilder();

                        int i = 1;
                        foreach (DataRow dr in dt.Rows)
                        {
                            sbHtml.AppendLine("<section class=\"t t-0\">" + dr["QuestionID"].ToString() + "." + dr["Question"].ToString() + "</section>");
                            if (dr["QuestionType"].ToString() == "1")
                            {
                                sbHtml.AppendLine("<input type=\"text\" name=\"" + dr["ControlID"].ToString() + "\" id=\"" + dr["ControlID"].ToString() + "\" value=\"sssss\"/>");
                            }
                            else if (dr["QuestionType"].ToString() == "2") {
                                DataTable dtDrop = dbHelper.ExecuteDataTable("", "select * from T_QuestorDropData where DropData = @DropData", new SqlParameter[]{
                                    new SqlParameter("@DropData",dr["DropData"].ToString())
                                });
                                sbHtml.AppendLine("<div class=\"time-0 hz-hid\">");
                                foreach (DataRow d in dtDrop.Rows)
                                {
                                   sbHtml.AppendLine(" <label>");
                                   sbHtml.AppendLine("     <input type=\"checkbox\" name=\"" + dr["ControlID"].ToString() + "\" value=\"" + d["Point"].ToString() + "\" id=\"" + dr["ControlID"].ToString() + "\" /><span>" + d["Op"].ToString() + "</span>");
                                   sbHtml.AppendLine(" </label>");
                                }
                                sbHtml.AppendLine("</div>");
                            }
                            i++;
                        }
                        strHtml = sbHtml.ToString();
                    }
                    dbHelper.Dispose();
                }
            }
        }

        protected void LinkPre_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            string url = "Questions.aspx?p=" + (intPage - 1) + "&openid=" + Request.QueryString["openid"].ToString();
            Response.Redirect(url);
        }

        protected void LinkNextOrSubmit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            if (lb.Text == "下一页") {
                string url = "Questions.aspx?p=" + (intPage + 1) + "&openid=" + Request.QueryString["openid"].ToString();
                Response.Redirect(url);
            }
        }
    }
}
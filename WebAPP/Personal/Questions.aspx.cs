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
using WebAPP.ClassLib;

namespace WebAPP.Personal
{
    public partial class Questions : System.Web.UI.Page
    {
        public int intPage = 0;
        public int MaxPage = 3;
        public string strHtml = string.Empty;
        public string strScript = string.Empty;
        public string BindScript = string.Empty;
        public string openid = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region
                if (Request.QueryString["p"] == null || int.TryParse(Request.QueryString["p"].ToString(), out intPage) == false)
                {
                    intPage = 1;
                }

                CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                openid = aa.GetUserOpenId(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString(), "Questions");

                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());

                DataTable dtInfo = dbHelper.ExecuteDataTable("select * from T_UserInfo where openid = '" + openid + "'");

                //Response.Write("count" + dtInfo.Rows.Count);
                //Response.End();
                if (dtInfo.Rows.Count == 0)
                {
                    Response.Redirect("RegisterUser.aspx");
                }
                else {
                    this.txtOpenid.Value = openid;
                }

                if (intPage >= 1 && intPage <= MaxPage)
                {
                    #region ==== Page ====
                    this.LinkPre.Text = "上一页";
                    if (intPage == 1)
                    {
                        this.LinkPre.Enabled = false;
                    }

                    if (intPage == 3)
                    {
                        this.LinkNextOrSubmit.Text = "提交测试";
                    }
                    else
                    {
                        this.LinkNextOrSubmit.Text = "下一页";
                    }
                    #endregion

                    DataTable dt = dbHelper.ExecuteDataTable("", "select * from T_Questions where page = @p order by QuestionID asc", new SqlParameter[]{ 
                        new SqlParameter("@p",intPage)
                    });

                    StringBuilder sbHtml = new StringBuilder();
                    StringBuilder sbScript = new StringBuilder();
                    StringBuilder sbBindScript = new StringBuilder();
                    int i = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        #region ==== Foreach ====
                        sbHtml.AppendLine("<section class=\"t t-0\">" + dr["QuestionID"].ToString() + "." + dr["Question"].ToString() + "</section>");
                        if (dr["QuestionType"].ToString() == "1")
                        {
                            sbHtml.AppendLine("<input type=\"tel\" name=\"" + dr["ControlID"].ToString() + "\" id=\"" + dr["ControlID"].ToString() + "\" value=\"\"/>");
                            #region ==== 脚本验证 ====
                            sbScript.AppendLine("if ($('#" + dr["ControlID"].ToString() + "').val() == '')");
                            sbScript.AppendLine("{");
                            sbScript.AppendLine("   alert('请回答第" + dr["QuestionID"].ToString() + "题')");
                            sbScript.AppendLine("   return false;");
                            sbScript.AppendLine("}");
                            sbScript.AppendLine("else {");
                            sbScript.AppendLine("   $.cookie('" + dr["ControlID"].ToString() + "', $('#" + dr["ControlID"].ToString() + "').val())");
                            sbScript.AppendLine("}");

                            sbBindScript.AppendLine("if($.cookie('" + dr["ControlID"].ToString() + "') !=undefined)");
                            sbBindScript.AppendLine("{ $('#" + dr["ControlID"].ToString() + "').val($.cookie('" + dr["ControlID"].ToString() + "')) }");

                            #endregion
                        }
                        else if (dr["QuestionType"].ToString() == "2")
                        {
                            DataTable dtDrop = dbHelper.ExecuteDataTable("", "select * from T_Question_DropData where DropData = @DropData", new SqlParameter[]{
                                new SqlParameter("@DropData",dr["DropData"].ToString())
                            });
                            sbHtml.AppendLine("<div class=\"time-0 hz-hid\">");
                            foreach (DataRow d in dtDrop.Rows)
                            {
                                sbHtml.AppendLine(" <label>");
                                sbHtml.AppendLine("     <input type=\"checkbox\" name=\"" + dr["ControlID"].ToString() + "\" value=\"" + d["Point"].ToString() + "\" value1=\"" + d["Point1"] + "\" id=\"" + dr["ControlID"].ToString() + "\" /><span>" + d["Op"].ToString() + "</span>");
                                sbHtml.AppendLine(" </label>");
                            }
                            sbHtml.AppendLine("</div>");

                            #region ==== 脚本验证 ====
                            sbScript.AppendLine("if($('#" + dr["ControlID"].ToString() + "[checked=checked]').length == 0)");
                            sbScript.AppendLine("{");
                            sbScript.AppendLine(" alert('请选择第" + dr["QuestionID"].ToString() + "题')");
                            sbScript.AppendLine(" return false;");
                            sbScript.AppendLine("}");
                            sbScript.AppendLine("else {");
                            sbScript.AppendLine("   $.cookie('" + dr["ControlID"].ToString() + "', $('#" + dr["ControlID"].ToString() + "[checked=checked]').eq(0).val())");
                            sbScript.AppendLine("}");


                            sbBindScript.AppendLine("if($.cookie('" + dr["ControlID"].ToString() + "') !=undefined)");
                            sbBindScript.AppendLine("{");
                            sbBindScript.AppendLine("   var v= $.cookie('" + dr["ControlID"].ToString() + "')");
                            sbBindScript.AppendLine("   $(document).find(\"input[name=" + dr["ControlID"].ToString() + "]\").each(function(idx){ ");
                            sbBindScript.AppendLine("   if($(this).val()==v){ $(this).attr('checked','checked');$(this).parent().attr('class','checked') } })");
                            sbBindScript.AppendLine("}");
                            #endregion
                        }
                        i++;
                        #endregion
                    }
                    strHtml = sbHtml.ToString();
                    BindScript = sbBindScript.ToString();
                    strScript = sbScript.ToString();
                }
                dbHelper.Dispose();
                #endregion
            }
        }

        protected void LinkPre_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["p"] == null || int.TryParse(Request.QueryString["p"].ToString(), out intPage) == false)
            {
                intPage = 1;
            }
            LinkButton lb = (LinkButton)sender;
            string url = "Questions.aspx?p=" + (intPage - 1);
            Response.Redirect(url);
        }

        protected void LinkNextOrSubmit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            if (lb.Text == "下一页")
            {
                if (Request.QueryString["p"] == null || int.TryParse(Request.QueryString["p"].ToString(), out intPage) == false)
                {
                    intPage = 1;
                }
                string url = "Questions.aspx?p=" + (intPage + 1); //+ "&openid=" + Request.QueryString["openid"].ToString();
                //Response.Write(url + "_" + intPage);
                //Response.End();
                Response.Redirect(url);
            }
            else if (lb.Text == "提交测试")
            {
                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());

                string strAlert = string.Empty;

                #region ==== Sql ====
                string sql = "INSERT INTO [WeixinWeb].[dbo].[T_Question_Answer] "
                       + "   ([openid],[age],[sex],[height],[weight] ,[yw] ,[tw],[xl] ,[bqsy],[phnl] ,[xyzs] ,[ydxg] ,[yjkzz] ,[createdate])                    "
                       + "  VALUES (@openid,@age,@sex, @height,@weight, @yw,@tw,@xl,@bqsy,@phnl,@xyzs, @ydxg, @yjkzz,GETDATE())";
                #endregion;
                #region ==== Check ====
                double age = 0;
                if (Request.Cookies["txtAge"] == null || double.TryParse(Request.Cookies["txtAge"].Value, out age) == false)
                {
                    strAlert += "参数年龄错误\n\t";
                }

                double sex = 0;
                if (Request.Cookies["radSex"] == null || double.TryParse(Request.Cookies["radSex"].Value, out sex) == false)
                {
                    strAlert += "参数性别错误\n\t";
                }

                double height = 0;
                if (Request.Cookies["txtHeight"] == null || double.TryParse(Request.Cookies["txtHeight"].Value, out height) == false)
                {
                    strAlert += "参数身高错误\n\t";
                }

                double weight = 0;
                if (Request.Cookies["txtWeight"] == null || double.TryParse(Request.Cookies["txtWeight"].Value, out weight) == false)
                {
                    strAlert += "参数体重错误\n\t";
                }

                double yw = 0;
                if (Request.Cookies["txtYw"] == null || double.TryParse(Request.Cookies["txtYw"].Value, out yw) == false)
                {
                    strAlert += "参数腰围错误\n\t";
                }

                double tw = 0;
                if (Request.Cookies["txtTw"] == null || double.TryParse(Request.Cookies["txtTw"].Value, out tw) == false)
                {
                    strAlert += "参数臀围错误\n\t";
                }


                double xl = 0;
                if (Request.Cookies["txtXl"] == null || double.TryParse(Request.Cookies["txtXl"].Value, out xl) == false)
                {
                    strAlert += "参数心率错误\n\t";
                }

                double bqsx = 0;
                if (Request.Cookies["radBQSY"] == null || double.TryParse(Request.Cookies["radBQSY"].Value, out bqsx) == false)
                {
                    strAlert += "参数憋气实验错误\n\t";
                }

                double phnl = 0;
                if (Request.Cookies["radPHNL"] == null || double.TryParse(Request.Cookies["radPHNL"].Value, out phnl) == false)
                {
                    strAlert += "参数平衡能力实验错误\n\t";
                }

                double xyzs = 0;
                if (Request.Cookies["radXYZS"] == null || double.TryParse(Request.Cookies["radXYZS"].Value, out xyzs) == false)
                {
                    strAlert += "参数吸烟指数错误\n\t";
                }

                double ydxg = 0;
                if (Request.Cookies["radSports"] == null || double.TryParse(Request.Cookies["radSports"].Value, out ydxg) == false)
                {
                    strAlert += "参数运动指数数错误\n\t";
                }

                double yjkzz = 0;
                if (Request.Cookies["radYJKZZ"] == null || double.TryParse(Request.Cookies["radYJKZZ"].Value, out yjkzz) == false)
                {
                    strAlert += "参数亚健康症状症状错误\n\t";
                }

                #endregion



                if (strAlert != string.Empty)
                {
                    Response.Write("<script>alert('" + strAlert + "')</script>");
                    Response.End();
                }
                else
                {
                    dbHelper.ExecuteNonQuery(sql, new SqlParameter[]{
                    new SqlParameter("@openid",txtOpenid.Value.ToString()),
                    new SqlParameter("@age",age),
                    new SqlParameter("@sex",sex),
                    new SqlParameter("@height",height),
                    new SqlParameter("@weight",weight),
                    new SqlParameter("@yw",yw),
                    new SqlParameter("@tw",tw),
                    new SqlParameter("@xl",xl),
                    new SqlParameter("@bqsy",bqsx),
                    new SqlParameter("@phnl",phnl),
                    new SqlParameter("@xyzs",xyzs),
                    new SqlParameter("@ydxg",ydxg),
                    new SqlParameter("@yjkzz",yjkzz)
                });
                }
                dbHelper.Dispose();
                Response.Redirect("TestResult.aspx");
            }
        }
    }
}
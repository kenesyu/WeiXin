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
                if (Session["Login"] == null || Session["Login"].ToString() == "")
                {
                    Response.Redirect("Login.aspx");
                }
                InitControl();
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "") {
                    BindData(Request.QueryString["id"].ToString());
                }
            }
        }

        private void BindData(string id)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "select * from T_Coachs where id= @id", new SqlParameter[]{
                new SqlParameter("@id", id)
            });

            if (dt.Rows.Count > 0) {
                this.txtcoachid.Value = dt.Rows[0]["id"].ToString();
                this.txtAge.Value = dt.Rows[0]["Age"].ToString();
                this.txtAvatar.Value = dt.Rows[0]["Avatar"].ToString();
                this.txtCoachName.Value = dt.Rows[0]["CoachName"].ToString();
                this.imgAvatar.Src = "/img/avatar/" + dt.Rows[0]["Avatar"].ToString();
                this.txtinfo.Value = dt.Rows[0]["info"].ToString();
                this.txtSignature.Value = dt.Rows[0]["Signature"].ToString();
                this.txtTel.Value = dt.Rows[0]["Tel"].ToString();
                this.txtWeiXin.Value = dt.Rows[0]["WeiXin"].ToString();
                for (int i = 0; i < selSex.Items.Count; i++) {
                    if (dt.Rows[0]["Sex"].ToString() == selSex.Items[i].Value) {
                        selSex.Items[i].Selected = true;
                    }else{
                        selSex.Items[i].Selected = false;
                    }
                }

                for (int i = 0; i < selSoports.Items.Count; i++)
                {
                    if (dt.Rows[0]["SportID"].ToString() == selSoports.Items[i].Value)
                    {
                        selSoports.Items[i].Selected = true;
                    }
                    else
                    {
                        selSoports.Items[i].Selected = false;
                    }
                }

                DataTable dtPhoto = dbHelper.ExecuteDataTable("select * from T_CoachPhoto where CoachID = " + dt.Rows[0]["id"].ToString());
                string v =string.Empty;
                foreach (DataRow dr in dtPhoto.Rows) {
                    v += "," + dr["ID"].ToString();
                }
                this.txtCoachPhoto.Value = this.txtCoachPhoto.Value + v;

                DataTable dtRegion = dbHelper.ExecuteDataTable("select * from T_CoachRegion where coachID = " + dt.Rows[0]["id"].ToString());
                foreach (DataRow dr in dtRegion.Rows) { 
                    chkRegion.Items.FindByValue(dr["RegionID"].ToString()).Selected = true;
                }
            }
            dbHelper.Dispose();
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
                this.chkRegion.Items.Add(new ListItem(dr["RegionName"].ToString(), dr["RegionID"].ToString()));
            }
            dbHelper.Dispose();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            if (this.txtcoachid.Value == "" || this.txtcoachid.Value == "0")
            {
                #region ==== 新建 ====
                string insertSql = "INSERT INTO [T_Coachs] "
                                + "([CoachName],[Sex],[Avatar],[Signature],[SportID],[Age],[Info],[Tel],[WeiXin],[Views],[openid],[OverdueDate],[JoinDate]) "
                                + " VALUES "
                                + "(@CoachName,@Sex,@Avatar,@Signature,@SportID, @Age, @Info,@Tel,@WeiXin, 100,NULL, @OverdueDate,GETDATE());select @@identity";


                DateTime overDueDate = DateTime.Now.AddMonths(Convert.ToInt32(this.selTimes.Value));


                string retid = dbHelper.ExecuteScalar(insertSql,
                    new SqlParameter[]{
                        new SqlParameter("@CoachName",this.txtCoachName.Value),
                        new SqlParameter("@Sex",this.selSex.Value),
                        new SqlParameter("@Avatar",this.txtAvatar.Value),
                        new SqlParameter("@Signature",this.txtSignature.Value),
                        new SqlParameter("@SportID",this.selSoports.Value),
                        new SqlParameter("@Age",this.txtAge.Value),
                        new SqlParameter("@Info",this.txtinfo.Value),
                        new SqlParameter("@Tel",this.txtTel.Value),
                        new SqlParameter("@WeiXin",this.txtWeiXin.Value),
                        new SqlParameter("@OverdueDate",overDueDate)
                    }
                ).ToString();


                for (int i = 0; i < chkRegion.Items.Count; i++) {
                    if (chkRegion.Items[i].Selected == true) {
                        dbHelper.ExecuteNonQuery("insert into T_CoachRegion (CoachID,RegionID) values ('" + retid + "','" + chkRegion.Items[i].Value + "')");
                    }
                }



                    dbHelper.ExecuteNonQuery("update T_CoachPhoto set CoachID = @CoachID where id in (" + this.txtCoachPhoto.Value + ")", new SqlParameter[]{
                    new SqlParameter("@CoachID",retid)
                });

                dbHelper.Dispose();
                Response.Write("<script>alert(\"保存成功\");location.href='jl_list.aspx'</script>");
                #endregion
            }
            else
            {
                #region ==== 更新 ====
                string updateSql = "UPDATE [T_Coachs]"
                                    + "   SET [CoachName] = @CoachName"
                                    + "    ,[Sex] = @Sex"
                                    + "    ,[Avatar] = @Avatar"
                                    + "    ,[Signature] = @Signature"
                                    + "    ,[SportID] = @SportID"
                                    + "    ,[Age] = @Age"
                                    + "    ,[Info] = @Info"
                                    + "    ,[Tel] = @Tel"
                                    + "    ,[WeiXin] =@WeiXin"
                                    + "    ,[OverdueDate] = dateadd(month," + this.selTimes.Value + ",OverdueDate) "
                                    + " WHERE id= @id ";

                DateTime overDueDate = DateTime.Now.AddMonths(Convert.ToInt32(this.selTimes.Value));
                dbHelper.ExecuteNonQuery(updateSql,
                    new SqlParameter[]{
                        new SqlParameter("@CoachName",this.txtCoachName.Value),
                        new SqlParameter("@Sex",this.selSex.Value),
                        new SqlParameter("@Avatar",this.txtAvatar.Value),
                        new SqlParameter("@Signature",this.txtSignature.Value),
                        new SqlParameter("@SportID",this.selSoports.Value),
                        new SqlParameter("@Age",this.txtAge.Value),
                        new SqlParameter("@Info",this.txtinfo.Value),
                        new SqlParameter("@Tel",this.txtTel.Value),
                        new SqlParameter("@WeiXin",this.txtWeiXin.Value),
                        new SqlParameter("@id",this.txtcoachid.Value)
                    }
                ).ToString();

                dbHelper.ExecuteNonQuery("delete from T_CoachRegion where coachid = " + this.txtcoachid.Value.ToString());
                for (int i = 0; i < chkRegion.Items.Count; i++)
                {
                    if (chkRegion.Items[i].Selected == true)
                    {
                        dbHelper.ExecuteNonQuery("insert into T_CoachRegion (CoachID,RegionID) values ('" + this.txtcoachid.Value.ToString() + "','" + chkRegion.Items[i].Value + "')");
                    }
                }

                dbHelper.Dispose();
                Response.Write("<script>alert(\"保存成功\")</script>");
                #endregion
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            dbHelper.ExecuteNonQuery("Delete from T_CoachPhoto where CoachID = " + this.txtcoachid.Value.ToString());
            dbHelper.Dispose();
            Response.Write("<script>alert(\"清除成功\")</script>");
        }
    }
}
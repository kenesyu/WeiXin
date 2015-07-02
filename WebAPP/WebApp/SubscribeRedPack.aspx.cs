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
using WeiXin.Helper;
using Weixin.Mp.Sdk.Util;
using System.Xml;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace WebAPP.WebApp
{
    public partial class SubscribeRedPack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CheckRegisterAndRegister aa = new CheckRegisterAndRegister();
                Dictionary<string, object> userinfo = aa.RegisterPushInfo(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString(), Request.Url.ToString());
                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());

                //ViewState.Add("openid", userinfo["openid"].ToString());
                string openid = userinfo["openid"].ToString();
                string city = userinfo["city"].ToString();


                this.imgProfile.Src = userinfo["headimgurl"].ToString();
                this.lblNickname.Text = userinfo["nickname"].ToString();
                this.lblCity.Text = userinfo["city"].ToString();
                string chkSex = userinfo["sex"].ToString();
                if (chkSex == "1") { chkSex = "男"; }
                else if (chkSex == "2") { chkSex = "女"; }
                else { chkSex = "保密"; }
                this.lblSex.Text = chkSex;


  

                this.repList.DataSource = dbHelper.ExecuteDataTable("select top 10 * from T_RedPack a inner join T_UserInfo  b on  a.openid = b.openid where amount > 0 order by amount desc"); ;
                this.repList.DataBind();

                dbHelper.Dispose();
            }
            catch (SystemException ex)
            {
                Logger.WriteTxtLog(ex.Message.ToString());
                throw ex;
            }
        }

        public string st(string s, int l)
        {
            if (s.Length > l)
            {
                return s.Substring(0, l);
            }
            return s;
        }
    }
}
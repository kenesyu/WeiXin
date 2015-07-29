using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper;
using System.Configuration;
using System.Data;
using WeiPay;
using Newtonsoft.Json;
using System.Xml;

namespace WebAPP.WebApp.WXPay
{
    public partial class Products : System.Web.UI.Page
    {
        //页面输出 不用操作
        public static string Code = "";     //微信端传来的code
        public static string PrepayId = ""; //预支付ID
        public static string Sign = "";     //为了获取预支付ID的签名
        public static string PaySign = "";  //进行支付需要的签名
        public static string Package = "";  //进行支付需要的包
        public static string TimeStamp = ""; //时间戳 程序生成 无需填写
        public static string NonceStr = ""; //随机字符串  程序生成 无需填写


        //支付相关参数 ，以下参数请从需要支付的页面通过get方式传递过来
        protected string OrderSN = ""; //商户自己订单号
        protected string Body = ""; //商品描述
        protected string TotalFee = "";  //总支付金额，单位为：分，不能有小数
        protected string Attach = ""; //用户自定义参数，原样返回
        protected string UserOpenId = "";//微信用户openid

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                GetUserOpenId();
                BindData();
            }
        }

        private void BindData() {
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
            {
                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
                DataTable dt = dbHelper.ExecuteDataTable("select * from T_Products where productid = " + Request.QueryString["id"].ToString() + " and isopen = 1");
                if (dt.Rows.Count > 0)
                {
                    this.lblProductName.Text = dt.Rows[0]["ProductName"].ToString();
                    this.lblPrice.Text = dt.Rows[0]["ProductPrice"].ToString();
                    this.lblDetails.Text = dt.Rows[0]["Details"].ToString();
                    this.TotalFee = (Convert.ToDecimal(dt.Rows[0]["ProductPrice"]) * 100).ToString();
                    dbHelper.Dispose();
                    this.OrderSN = DateTime.Now.ToString("yyyyMMddHHmmss");
                    this.Body = dt.Rows[0]["ProductName"].ToString();
                    this.Attach = "No";
                    this.txtid.Value = Request.QueryString["id"].ToString();
                }
                else
                {
                    Response.Write("<font size='24px'>该商品已销售完</font>");
                    Response.End();
                }
            }
            else
            {
                Response.Write("<font size='24px'>该商品已销售完</font>");
                Response.End();
            }
        }

        private void GetUserOpenId()
        {
            string code = Request.QueryString["code"];
            if (string.IsNullOrEmpty(code))
            {
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state=lk#wechat_redirect", PayConfig.AppId, string.Format(PayConfig.SendUrl, Request.QueryString["id"].ToString()));
                Response.Redirect(code_url);
            }
            else
            {
                LogUtil.WriteLog(" ============ 开始 获取微信用户相关信息 =====================");

                #region 获取支付用户 OpenID================
                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", PayConfig.AppId, PayConfig.AppSecret, code);
                string returnStr = HttpUtil.Send("", url);
                LogUtil.WriteLog("Send 页面  returnStr 第一个：" + returnStr);

                var obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", PayConfig.AppId, obj.refresh_token);
                returnStr = HttpUtil.Send("", url);
                obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                LogUtil.WriteLog("Send 页面  access_token：" + obj.access_token);
                LogUtil.WriteLog("Send 页面  openid=" + obj.openid);

                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", obj.access_token, obj.openid);
                returnStr = HttpUtil.Send("", url);
                LogUtil.WriteLog("Send 页面  returnStr：" + returnStr);

                this.txtOpenID.Value = obj.openid;


                LogUtil.WriteLog(" ============ 结束 获取微信用户相关信息 =====================");
                #endregion
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //设置支付数据
            PayModel model = new PayModel();
            model.OrderSN = this.OrderSN;
            model.TotalFee = int.Parse(this.lblPrice.Text);
            model.Body = this.lblProductName.Text;
            model.Attach = this.txtid.Value; //不能有中午
            model.OpenId = this.txtOpenID.Value;

            //跳转到 WeiPay.aspx 页面，请设置函数中WeiPay.aspx的页面地址
            this.Response.Redirect(model.ToString());
        }
    }
}
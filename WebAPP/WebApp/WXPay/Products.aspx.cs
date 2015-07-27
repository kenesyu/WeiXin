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


                    GetUserOpenId();
                    LogUtil.WriteLog("============ 单次支付开始 ===============");
                    LogUtil.WriteLog(string.Format("传递支付参数：OrderSN={0}、Body={1}、TotalFee={2}、Attach={3}、UserOpenId={4}",
                    this.OrderSN, this.Body, this.TotalFee, this.Attach, this.UserOpenId));


                    #region 支付操作============================


                    #region 基本参数===========================
                    //时间戳 
                    TimeStamp = TenpayUtil.getTimestamp();
                    //随机字符串 
                    NonceStr = TenpayUtil.getNoncestr();

                    //创建支付应答对象
                    var packageReqHandler = new RequestHandler(Context);
                    //初始化
                    packageReqHandler.init();

                    //设置package订单参数  具体参数列表请参考官方pdf文档，请勿随意设置
                    packageReqHandler.setParameter("body", this.Body); //商品信息 127字符
                    packageReqHandler.setParameter("appid", PayConfig.AppId);
                    packageReqHandler.setParameter("mch_id", PayConfig.MchId);
                    packageReqHandler.setParameter("nonce_str", NonceStr.ToLower());
                    packageReqHandler.setParameter("notify_url", PayConfig.NotifyUrl);
                    packageReqHandler.setParameter("openid", this.UserOpenId);
                    packageReqHandler.setParameter("out_trade_no", this.OrderSN); //商家订单号
                    packageReqHandler.setParameter("spbill_create_ip", Page.Request.UserHostAddress); //用户的公网ip，不是商户服务器IP
                    packageReqHandler.setParameter("total_fee", this.TotalFee); //商品金额,以分为单位(money * 100).ToString()
                    packageReqHandler.setParameter("trade_type", "JSAPI");
                    if (!string.IsNullOrEmpty(this.Attach))
                        packageReqHandler.setParameter("attach", "test");//自定义参数 127字符

                    #endregion

                    #region sign===============================
                    Sign = packageReqHandler.CreateMd5Sign("key", PayConfig.AppKey);
                    LogUtil.WriteLog("WeiPay 页面  sign：" + Sign);
                    #endregion

                    #region 获取package包======================
                    packageReqHandler.setParameter("sign", Sign);

                    string data = packageReqHandler.parseXML();
                    LogUtil.WriteLog("WeiPay 页面  package（XML）：" + data);

                    string prepayXml = HttpUtil.Send(data, "https://api.mch.weixin.qq.com/pay/unifiedorder");
                    LogUtil.WriteLog("WeiPay 页面  package（Back_XML）：" + prepayXml);

                    //获取预支付ID
                    var xdoc = new XmlDocument();
                    xdoc.LoadXml(prepayXml);
                    XmlNode xn = xdoc.SelectSingleNode("xml");
                    XmlNodeList xnl = xn.ChildNodes;
                    if (xnl.Count > 7)
                    {
                        PrepayId = xnl[7].InnerText;
                        Package = string.Format("prepay_id={0}", PrepayId);
                        LogUtil.WriteLog("WeiPay 页面  package：" + Package);
                    }
                    #endregion

                    #region 设置支付参数 输出页面  该部分参数请勿随意修改 ==============
                    var paySignReqHandler = new RequestHandler(Context);
                    paySignReqHandler.setParameter("appId", PayConfig.AppId);
                    paySignReqHandler.setParameter("timeStamp", TimeStamp);
                    paySignReqHandler.setParameter("nonceStr", NonceStr);
                    paySignReqHandler.setParameter("package", Package);
                    paySignReqHandler.setParameter("signType", "MD5");
                    PaySign = paySignReqHandler.CreateMd5Sign("key", PayConfig.AppKey);

                    LogUtil.WriteLog("WeiPay 页面  paySign：" + PaySign);
                    #endregion
                    #endregion
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
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state=lk#wechat_redirect", PayConfig.AppId, Request.Url.ToString());
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

                this.UserOpenId = obj.openid;

                LogUtil.WriteLog(" ============ 结束 获取微信用户相关信息 =====================");
                #endregion
            }
        }
    }
}
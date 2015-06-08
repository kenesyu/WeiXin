using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Web.Script.Serialization;
using WebAPP.ClassLib;
using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Request;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk.Domain;
using System.Text;

namespace WebAPP.WebApp
{
    public partial class Product : System.Web.UI.Page
    {
        public string appid;// = ConfigurationManager.AppSettings["AppID"].ToString();
        public int timestamp;
        public string nonceStr;
        public string signature;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WXJSSDK jssdk = new WXJSSDK(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString());
                //timestamp = jssdk.ConvertDateTimeInt(DateTime.Now);
                Hashtable SignPackage = jssdk.getSignPackage();
                appid = SignPackage["appId"].ToString();
                timestamp = Convert.ToInt32(SignPackage["timestamp"]);
                nonceStr = SignPackage["nonceStr"].ToString();
                signature = SignPackage["signature"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WXJSSDK jssdk = new WXJSSDK(ConfigurationManager.AppSettings["AppID"].ToString(), ConfigurationManager.AppSettings["AppSecret"].ToString());
            Hashtable SignPackage = jssdk.getSignPackage();

            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            StringBuilder sbParameter = new StringBuilder();


            string stringSignTemp = "appid=" + ConfigurationManager.AppSettings["AppID"].ToString() + "&body=健身卡&mch_id=1227576402&nonce_str=" + SignPackage["nonceStr"].ToString()
                + "&notify_url=http://www.baidu.com&openid=ovTALuEgDT2sxXOcGwJ_rBgipgtY&out_trade_no=001&spbill_create_ip=14.23.150.211&total_fee=1&trade_type=JSAPI";

            stringSignTemp += "&key=" + ConfigurationManager.AppSettings["WxPayKey"].ToString();
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringSignTemp, "MD5");  //MD5(stringSignTemp).toUpperCase() = "9A0A8659F005D6984697E2CA0A9CF3B7";



            sbParameter.AppendLine("<xml>");
            sbParameter.AppendLine("   <appid>" + ConfigurationManager.AppSettings["AppID"].ToString() + "</appid>");
            //sbParameter.AppendLine("   <attach>支付测试</attach>");
            sbParameter.AppendLine("   <body>健身卡</body>");
            sbParameter.AppendLine("   <mch_id>1227576402</mch_id>");
            sbParameter.AppendLine("   <nonce_str>" + SignPackage["nonceStr"].ToString() + "</nonce_str>");
            sbParameter.AppendLine("   <notify_url>http://www.baidu.com</notify_url>");
            sbParameter.AppendLine("   <openid>ovTALuEgDT2sxXOcGwJ_rBgipgtY</openid>");
            sbParameter.AppendLine("   <out_trade_no>001</out_trade_no>");
            sbParameter.AppendLine("   <spbill_create_ip>14.23.150.211</spbill_create_ip>");
            sbParameter.AppendLine("   <total_fee>1</total_fee>");
            sbParameter.AppendLine("   <trade_type>JSAPI</trade_type>");
            sbParameter.AppendLine("   <sign>" + sign + "</sign>");
            sbParameter.AppendLine("</xml>");




            //sbParameter.AppendLine("?appid=" + ConfigurationManager.AppSettings["AppID"].ToString())";
            //sbParameter += "&mch_id=1227576402";
            //sbParameter += "&nonce_str=" + SignPackage["nonceStr"].ToString();
            //sbParameter += "&sign=" + SignPackage["signature"].ToString();
            //sbParameter += "&body=测试";
            //sbParameter += "&out_trade_no=001";
            //sbParameter += "&total_fee=1";
            //sbParameter += "&spbill_create_ip=127.0.0.1";
            //sbParameter += "&notify_url=www.baidu.com";
            //sbParameter += "&trade_type=JSAPI";
            //sbParameter += "&openid=ovTALuEgDT2sxXOcGwJ_rBgipgtY";

            string result = WeiXin.WexinAPI.HttpUtility.SendPostHttpRequest(url, "text/xml", sbParameter.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Text;
using System.Collections;

namespace WebAPP.BussinessService
{
    /// <summary>
    /// WxPayService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WxPayService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetPayInfo()
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


            string result = WeiXin.WexinAPI.HttpUtility.SendPostHttpRequest(url, "text/xml", sbParameter.ToString());

            return result;
        }
    }
}

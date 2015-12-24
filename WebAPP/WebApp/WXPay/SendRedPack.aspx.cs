using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAPP.ClassLib;
using System.Xml;
using Newtonsoft.Json;
using WeiXin.Models;
using WeiXin.Helper;

namespace WebAPP.WebApp.WXPay
{
    public partial class SendRedPack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.ContentType = "text/plain";
            PayWeiXin model = new PayWeiXin();
            PayForWeiXinHelp PayHelp = new PayForWeiXinHelp();
            string result = string.Empty;
            //传入OpenId
            string openId = "ovTALuEgDT2sxXOcGwJ_rBgipgtY";//Request.Form["openId"].ToString();
            //传入红包金额(单位分)
            string amount = "100";//Request.Form["amount"] == null ? "" : Request.Form["amount"].ToString();
            //接叐收红包的用户 用户在wxappid下的openid 
            model.re_openid = openId;//"oFIYdszuDXVqVCtwZ-yIcbIS262k";
            //付款金额，单位分 
            model.total_amount = int.Parse("100");
            //最小红包金额，单位分 
            model.min_value = int.Parse("100");
            //最大红包金额，单位分 
            model.max_value = int.Parse("100");
            //调用方法
            string postData = PayHelp.DoDataForPayWeiXin(model);
            try
            {
                result = PayHelp.PayForWeiXin(postData);
            }
            catch (Exception ex)
            {
                //写日志
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            string jsonResult = JsonConvert.SerializeXmlNode(doc);
            Response.ContentType = "application/json";
            Response.Write(jsonResult);
            Response.End();
        }
    }
}
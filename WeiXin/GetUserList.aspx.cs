using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weixin.Mp.Sdk.Request;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Util;
using Weixin.Mp.Sdk.Domain;
using System.Configuration;

namespace WeiXin
{
    public partial class GetUserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAttentionsTest();
        }




        public void GetAttentionsTest()
        {
            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = ConfigurationManager.AppSettings["AppID"].ToString(), AppSecret = ConfigurationManager.AppSettings["AppSecret"].ToString() }
            };
            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Response.Write("获取令牌环失败..");
                //request..WriteLine();
                return;
            }

            GetAttentionsRequest request2 = new GetAttentionsRequest()
            {
                AccessToken = response.AccessToken.AccessToken
            };

            var response2 = mpClient.Execute(request2);
            if (response2.IsError)
            {
                Response.Write("获取关注者列表失败，错误信息为：" + response2.ErrInfo.ErrCode + "-" + response2.ErrInfo.ErrMsg);
            }
            else
            {
                Response.Write("获取关注者列表成功");

                //MessageHandler.SendTextReplyMessage("gh_a21a5cfa913f", "ovTALuEgDT2sxXOcGwJ_rBgipgtY", "你好测试");

                //SendTextCustomMessageTest();

                //response2.Attentions.data.openid

                foreach (string ToUser in response2.Attentions.data.openid)
                {
                    SendTextCustomMessageTest(ToUser);
                    //Response.Write(ToUser);
                }


                //Response.Write(Tools.ToJsonString(response2.Attentions));
            }
        }


        public void SendTextCustomMessageTest(string ToUser)
        {

            //IMpClient mpClient = new MpClient();
            //AccessTokenGetRequest request = new AccessTokenGetRequest()
            //{
            //    AppIdInfo = new AppIdInfo() { AppID = ConfigurationManager.AppSettings["AppID"].ToString(), AppSecret = ConfigurationManager.AppSettings["AppSecret"].ToString() }
            //};
            //AccessTokenGetResponse response = mpClient.Execute(request);
            //if (response.IsError)
            //{
            //    Console.WriteLine("获取令牌环失败..");
            //    return;
            //}
            //var response2 = MessageHandler.SendTextCustomMessage(response.AccessToken.AccessToken, ToUser, "圣诞快乐！！");
            //if (response2.IsError)
            //{
            //    Response.Write("发送失败");
            //}
            //else
            //{
            //    Response.Write("发送成功");
            //}
        }
    }
}
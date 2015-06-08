using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Domain;
using Weixin.Mp.Sdk.Util;
using Weixin.Mp.Sdk.Request;
using Weixin.Mp.Sdk.Response;
using WeixinMpSdkTestWeb;

namespace WeiXin
{
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = "yuze";  //您在公众平台填写的token
            if (MessageHandler.CheckSignature(token))
            {
                Response.Write(" "); //未通过真实性校验
                return;
            }

            string chkLogFile = AppDomain.CurrentDomain.BaseDirectory + "ChkLog.txt";
            string contentFile = AppDomain.CurrentDomain.BaseDirectory + "Content.txt";


            Logger.WriteTxtLog("进来了" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), chkLogFile); //正式环境您可以将这句删除掉，或者启用您自己的日志记录

            var recMsg = MessageHandler.ConvertMsgToObject(token);  //将消息转换成对象
            if (recMsg == null)
            {
                Response.Write(" ");
                Response.End();
                return;
            }


            IMessageProcessor msgProcessor = new MessageProcessor();  //处理消息，这里定义一个类，并继承接口IMessageProcessor来处理接受到的消息，MessageProcessor您可以实现您自己的处理方法
            if (msgProcessor.ProcessMessage(recMsg, "参数1", "参数2")) //处理消息，下面会为您提供处理类的样例MessageProcessor，这个类需要您自己去实现业务，样例只是简单测试
            {
                Response.End();
                return;
            }
        }
    }
}




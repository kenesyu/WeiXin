using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.Security;
using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Util;
using WeixinMpSdkTestWeb;
using Weixin.Mp.Sdk.Domain;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk.Request;
using System.Configuration;
using WeiXin.Helper;
using DBHelper;
using System.Xml;
using Newtonsoft.Json;

namespace WeiXin
{
    public partial class WeiXinAPI : System.Web.UI.Page
    {
        //const string Token = "yuze";  //你的token
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = "yuze";  //您在公众平台填写的token

            ///MessageHandler.Valid(token);

            //if (MessageHandler.CheckSignature(token))
            //{
            //    Response.Write(" "); //未通过真实性校验
            //    return;
            //}

           
            string chkLogFile = AppDomain.CurrentDomain.BaseDirectory + "ChkLog.txt";
            string contentFile = AppDomain.CurrentDomain.BaseDirectory + "Content.txt";


            //Logger.WriteTxtLog("进来了" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), chkLogFile); //正式环境您可以将这句删除掉，或者启用您自己的日志记录
            var recMsg = MessageHandler.ConvertMsgToObject(token);  //将消息转换成对象
            //Logger.WriteTxtLog(recMsg.eve);

            Logger.WriteTxtLog(recMsg.MsgType.ToString());
            try
            {
                //if (recMsg == null)
                //{
                //    Response.Clear();
                //    Response.End();
                //    return;
                //}

                IMessageProcessor msgProcessor = new MessageProcessor();  //处理消息，这里定义一个类，并继承接口IMessageProcessor来处理接受到的消息，MessageProcessor您可以实现您自己的处理方法
                if (msgProcessor.ProcessMessage(recMsg, "参数1", "参数2")) //处理消息，下面会为您提供处理类的样例MessageProcessor，这个类需要您自己去实现业务，样例只是简单测试
                {
                    //Logger.WriteTxtLog(recMsg.MessageBody);
                    //Response.Clear();
                    //Response.End();
                    return;
                }
            }
            catch (Exception ex) {
                Logger.WriteTxtLog(ex.Message);
            }
        }
    }
}

namespace WeixinMpSdkTestWeb
{
    /// 
    /// 消息处理类
    /// 
    public class MessageProcessor : IMessageProcessor
    {
        /// 
        /// 处理消息
        /// 
        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功

        public bool ProcessMessage(ReceiveMessageBase msg, params object[] args)
        {

            Logger.WriteTxtLog("Dothis");

            string chkLogFile = AppDomain.CurrentDomain.BaseDirectory + "ChkLog.txt";
            string contentFile = AppDomain.CurrentDomain.BaseDirectory + "Content.txt";
            TextReplyMessage replyMsg = new TextReplyMessage()
            {
                Content = "您好,您发送的消息类型为：" + msg.GetType().ToString(),
                CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                FromUserName = msg.ToUserName,
                ToUserName = msg.FromUserName
            };
            Logger.WriteTxtLog(msg.MessageBody, contentFile);
            //System.Web.HttpContext.Current.Response.Write(replyMsg.ToXmlString());
            Logger.WriteTxtLog(msg.MsgType.ToString());

            if (msg.MsgType == MsgType.Event)
            {
                EventMessage evtMsg = msg as EventMessage;
                if (evtMsg.EventType == EventType.Click) {
                    ProcessMenuEvent(msg as MenuEventMessage, args);
                }
                else if (evtMsg.EventType == EventType.subscribe)
                {
                    ProcessSubscribeEvent(msg as SubscribeEventMessage, args);
                }
            }
            else {
                MessageHandler.TransferToAutoCustomer(msg.ToUserName, msg.FromUserName);
            }
            return true;




            //switch (msg.MsgType)
            //{
            //    case MsgType.Text:
            //        return ProcessTextMessage(msg as TextReceiveMessage, args);
            //    case MsgType.Image:
            //        return ProcessImageMessage(msg as ImageReceiveMessage, args);
            //    case MsgType.Link:
            //        return ProcessLinkMessage(msg as LinkReceiveMessage, args);
            //    case MsgType.Location:
            //        return ProcessLocationMessage(msg as LocationReceiveMessage, args);
            //    case MsgType.UnKnown:
            //        return ProcessNotHandlerMsg(msg, args);
            //    case MsgType.Video:
            //        return ProcessVideoMessage(msg as VideoReceiveMessage, args);
            //    case MsgType.Voice:
            //        return ProcessVoiceMessage(msg as VoiceReceiveMessage, args);
            //    case MsgType.VoiceResult:
            //        return ProcessVoiceMessage(msg as VoiceReceiveMessage, args);
            //    case MsgType.Event:
            //        EventMessage evtMsg = msg as EventMessage;
            //        Logger.WriteTxtLog(evtMsg.EventType.ToString());
            //        switch (evtMsg.EventType)
            //        {
            //            case EventType.Click:
            //                return ProcessMenuEvent(msg as MenuEventMessage, args);
            //            case EventType.Location:
            //                return ProcessUploadLocationEvent(msg as UploadLocationEventMessage, args);
            //            case EventType.Scan:
            //                return ProcessScanEvent(msg as ScanEventMessage, args);
            //            case EventType.subscribe:
            //                return ProcessSubscribeEvent(msg as SubscribeEventMessage, args);
            //            case EventType.UnKnown:
            //                return ProcessNotHandlerMsg(msg, args);
            //            case EventType.UnSubscribe:
            //                return ProcessUnSubscribeEvent(msg as UnSubscribeEventMessage, args);
            //            default:
            //                return ProcessNotHandlerMsg(msg, args);
            //        }
            //    default:
            //        return ProcessNotHandlerMsg(msg, args);
            //}
        }

        /// 

        /// 处理文本消息
        /// 
        /// 消息对象


        /// 参数（用于具体业务传递参数用）


        /// 是否处理成功

        public bool ProcessTextMessage(TextReceiveMessage msg, params object[] args)
        {
            
            //Logger.WriteTxtLog(msg.);
            //if (msg.Content.Equals("v", StringComparison.InvariantCultureIgnoreCase))
            ////{
            //    string token = "yuze";
            //    string appId = ConfigurationManager.AppSettings["AppID"].ToString();
            //    string appSecret = ConfigurationManager.AppSettings["AppSecret"].ToString();
            //    IMpClient mpClient = new MpClient();
            //    AccessTokenGetRequest request = new AccessTokenGetRequest()
            //    {
            //        AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
            //    };

            //    Logger.WriteTxtLog("11111111111");
            //    AccessTokenGetResponse response = mpClient.Execute(request);
            //    Logger.WriteTxtLog("22222222222");
            //    if (response.IsError)
            //    {
            //        Logger.WriteTxtLog("eeeeeeeeee");
            //        //这里回应1条文本消息，当然您也可以回应其他消息
            //        MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "发送视频时,获取AccessToken失败");
            //        return true;
            //    }
            //    else
            //    {
            //        Logger.WriteTxtLog("kkkkkkkkkkkkkk");
            //        token = response.AccessToken.AccessToken;
            //        return MessageHandler.SendVideoReplyMessage(token, msg.ToUserName, msg.FromUserName, "精美视频", "这个是很漂亮的流畅高清视频", AppDomain.CurrentDomain.BaseDirectory + "2771cae7-8756-4dd4-8491-976589ab17cc.mp4");
            //    }


            //    return true;
           // }

            //这里回应1条文本消息，当然您也可以回应其他消息

            string keyword = string.Empty;

            #region 自动回复

            //Logger.WriteTxtLog("2222");
            #endregion

            #region 转发到多客服

            try
            {
                //TransferAutoCustomer t = new TransferAutoCustomer();
                ////t.MsgType = MsgType.transfer_customer_service;
                //t.FromUserName = msg.FromUserName;
                //t.ToUserName = msg.ToUserName;
                //t.CreateTime = msg.CreateTime;
                Logger.WriteTxtLog("接入客服");
                //System.Web.HttpContext.Current.Response.Write(t.ToXmlString());
                MessageHandler.TransferToAutoCustomer(msg.ToUserName, msg.FromUserName);
                Logger.WriteTxtLog("接入客服结束");
            }
            catch (Exception ex)
            {
                Logger.WriteTxtLog("接入客服出错：" + ex.Message);
            }


            #endregion

            //发送1条图文信息测试看
            //List<NewsReplyMessageItem> items = new List(NewsReplyMessageItem);
            //List<NewsReplyMessageItem> items = new List<NewsReplyMessageItem>();

            //NewsReplyMessageItem itm = new NewsReplyMessageItem()
            //{
            //    Description = "汽车描述1",
            //    Url = "http://www.60px.com",
            //    PicUrl = "http://t10.baidu.com/it/u=3676282639,2721194652&fm=23&gp=0.jpg",
            //    Title = "汽车标题1"
            //};
            //items.Add(itm);

            //itm = new NewsReplyMessageItem()
            //{
            //    Description = "汽车描述2",
            //    Url = "http://www.011011.com",
            //    PicUrl = "http://t2.baidu.com/it/u=308326304,3930874379&fm=21&gp=0.jpg",
            //    Title = "汽车标题2"
            //};
            //items.Add(itm);

            //itm = new NewsReplyMessageItem()
            //{
            //    Description = "汽车描述3",
            //    Url = "http://www.gd-fzc.com",
            //    PicUrl = "http://t2.baidu.com/it/u=2618819304,4153638089&fm=21&gp=0.jpg",
            //    Title = "汽车标题3"
            //};
            //items.Add(itm);

            //NewsReplyMessage replyMsg = new NewsReplyMessage()
            //{
            //    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
            //    FromUserName = msg.ToUserName,
            //    ToUserName = msg.FromUserName,
            //    Articles = items
            //};
            //MessageHandler.SendReplyMessage(replyMsg);

            return true;
        }

        /// 
        /// 处理图片消息
        /// 
        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessImageMessage(ImageReceiveMessage msg, params object[] args)
        {
            try
            {
                // string token = args[0].ToString();
                Logger.WriteTxtLog("ImageMessage");
                string token = "yuze";
                string appId = ConfigurationManager.AppSettings["AppID"].ToString();
                string appSecret = ConfigurationManager.AppSettings["AppSecret"].ToString();
                IMpClient mpClient = new MpClient();
                Logger.WriteTxtLog("11111:");
                AccessTokenGetRequest request = new AccessTokenGetRequest()
                {
                    AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
                };
                Logger.WriteTxtLog("22222:");
                AccessTokenGetResponse response = mpClient.Execute(request);
                Logger.WriteTxtLog("33333:");
                if (response.IsError)
                {
                    //这里回应1条文本消息，当然您也可以回应其他消息
                    MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您发送了语音消息");
                    return true;
                }
                else
                {
                    Logger.WriteTxtLog("Token:" + token);
                    token = response.AccessToken.AccessToken;
                    Logger.WriteTxtLog("Token:" + token);
                    //这里回复一个图片，当然您也可以回复其他类型的消息
                    Logger.WriteTxtLog(AppDomain.CurrentDomain.BaseDirectory + "aa.jpg");
                    return MessageHandler.SendImageReplyMessage(token, msg.ToUserName, msg.FromUserName, AppDomain.CurrentDomain.BaseDirectory + "aa.jpg");
                }
            }
            catch (Exception ex)
            {
                //这里回应1条文本消息，当然您也可以回应其他消息
                Logger.WriteTxtLog("44444:");
                MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "出错了：" + ex.ToString());
                return true;


            }
        }

        /// 
        /// 处理语音消息
        /// 
        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessVoiceMessage(VoiceReceiveMessage msg, params object[] args)
        {
            // string token = args[0].ToString();

            string token = "yuze";
            string appId = ConfigurationManager.AppSettings["AppID"].ToString();
            string appSecret = ConfigurationManager.AppSettings["AppSecret"].ToString();
            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
            };
            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                //这里回应1条文本消息，当然您也可以回应其他消息
                MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您发送了语音消息");
                return true;
            }
            else
            {
                token = response.AccessToken.AccessToken;
                //这里回复1条语音消息，当然您也可以回复其他类型的信息
                return MessageHandler.SendVoiceReplyMessage(token, msg.ToUserName, msg.FromUserName, AppDomain.CurrentDomain.BaseDirectory + "11.mp3");
            }

        }

        /// 
        /// 处理视频消息
        /// 
        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessVideoMessage(VideoReceiveMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您发送的视频" + msg.MediaId.ToString() + "-" + msg.ThumbMediaId.ToString());
            return true;
        }

        /// 
        /// 处理地理位置消息
        /// 
        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessLocationMessage(LocationReceiveMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您的地里位置为：" + msg.Label + "(" + msg.Location_X + "," + msg.Location_Y + ")");
            return true;
        }

        /// 
        /// 处理链接消息
        /// 
        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessLinkMessage(LinkReceiveMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您发送的是连接信息");
            return true;
        }

        /// 
        /// 处理关注事件
        /// 
        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessSubscribeEvent(SubscribeEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            Logger.WriteTxtLog("关注开始");
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "<a href=\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + ConfigurationManager.AppSettings["AppID"].ToString() + "&redirect_uri=http://dede.dlyssoft.com/userauth/userauth.aspx&response_type=code&scope=snsapi_userinfo&state=1#wechat_redirect\">大连地区用户领取现金红包</a> ");
            #region SendRedPack
            Logger.WriteTxtLog("SendRedPack");
            if (msg.ToUserName == "ovTALuEgDT2sxXOcGwJ_rBgipgtY" || msg.FromUserName == "ovTALuEgDT2sxXOcGwJ_rBgipgtY")
            {
                SendRedBack(msg.FromUserName);
            }
            #endregion
            return true;
        }

        public void SendRedBack(string openId)
        {
            Logger.WriteTxtLog("SendRedPack 进来了");

            DataBaseHelper dbhelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            int count = Convert.ToInt32(dbhelper.ExecuteDataTable("select count(*) from T_RedPack where openid = '" + openId + "' and RedBackName = '关注'").Rows[0][0].ToString());
            Logger.WriteTxtLog("sql:" + "select count(*) from T_RedPack where openid = '" + openId + "' and RedBackName = '关注'");
            Logger.WriteTxtLog("count:" + count);
            Logger.WriteTxtLog("openId:" + openId);
            if (count == 0)
            {
                Logger.WriteTxtLog("发红包");
                WeiXin.Models.PayWeiXin model = new WeiXin.Models.PayWeiXin();
                PayForWeiXinHelp PayHelp = new PayForWeiXinHelp();
                string result = string.Empty;
                //传入OpenId
                //string openId = "ovTALuEgDT2sxXOcGwJ_rBgipgtY";//Request.Form["openId"].ToString();
                //传入红包金额(单位分)
                //string amount = "100";//Request.Form["amount"] == null ? "" : Request.Form["amount"].ToString();
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
                    Logger.WriteTxtLog(ex.Message);
                }
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                string jsonResult = JsonConvert.SerializeXmlNode(doc);
                //Response.ContentType = "application/json";
                Logger.WriteTxtLog(jsonResult);

                dbhelper.ExecuteNonQuery("insert into T_RedPack (OpenID,CreateTime,Amount,RedBackName) values ('" + openId + "',GETDATE(),100,'关注')");
                Logger.WriteTxtLog("完成");
            }
            dbhelper.Dispose();
        }

        /// 
        /// 处理取消关注事件
        /// 
        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessUnSubscribeEvent(UnSubscribeEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            Logger.WriteTxtLog("取消关注");
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您触发了取消关注事件，欢迎您下次再光临哦");
            return true;
        }

        /// 
        /// 处理扫描二维码关注事件
        /// 
        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessScanSubscribeEvent(ScanSubscribeEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您扫描了我们的二维码关注我们");
            return true;
        }

        /// 
        /// 处理扫描二维码事件
        /// 
        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessScanEvent(ScanEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您扫描了我们的二维码");
            return true;
        }

        /// 
        /// 处理上报地理位置事件
        /// 
        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessUploadLocationEvent(UploadLocationEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您的地里位置为：" + msg.Latitude + "-" + msg.Longitude);
            return true;
        }

        /// 
        /// 处理自定义菜单事件
        /// 
        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessMenuEvent(MenuEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            switch (msg.EventKey.ToString())
            {
                case "btn2":
                    //接入客服
                    MessageHandler.TransferToAutoCustomer(msg.ToUserName, msg.FromUserName);
                    break;
                default:
                    MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您触发了自定义事件" + msg.EventKey.ToString());
                    break;
            }
            return true;
        }

        /// 
        /// 处理未定义处理方法消息
        /// 
        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessNotHandlerMsg(ReceiveMessageBase msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您输入的指令不正确，请发送H寻求帮助");
            return true;
        }
    } // class end
}
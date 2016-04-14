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
using System.Data;

namespace WeiXin
{
    public partial class WeiXinAPI : System.Web.UI.Page
    {
        //const string Token = "yuze";  //你的token
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = "yuze";  //您在公众平台填写的token

            //MessageHandler.Valid(token);

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
            else
            {
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

            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("select * from T_Subscribe_Msg order by IndexOrder");
            List<NewsReplyMessageItem> items = new List<NewsReplyMessageItem>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NewsReplyMessageItem itm = new NewsReplyMessageItem()
                {
                    Description = dt.Rows[i]["Descriptions"].ToString(),
                    Url = dt.Rows[i]["Url"].ToString(),
                    PicUrl = dt.Rows[i]["PicUrl"].ToString(),
                    Title = dt.Rows[i]["Title"].ToString()
                };
                items.Add(itm);
            }
            dbHelper.Dispose();

            NewsReplyMessage replyMsg = new NewsReplyMessage()
            {
                CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                FromUserName = msg.ToUserName,
                ToUserName = msg.FromUserName,
                Articles = items
            };

            //items.Add(itm);
            MessageHandler.SendReplyMessage(replyMsg);

            //MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "<a href=\"" + ConfigurationManager.AppSettings["Host"].ToString() + "/webapp/SubscribeRedPack.aspx\">点此领取现金红包</a>");
            return true;
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
            string key = msg.EventKey.ToString();
            if (key == "subkey4")
            {
                MessageHandler.TransferToAutoCustomer(msg.ToUserName, msg.FromUserName);
                return true;
            }
            else if (key == "subkey1")
            {
                //本期活动

                DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
                DataTable dt = dbHelper.ExecuteDataTable("select * from T_HD_Current order by IndexOrder");
                List<NewsReplyMessageItem> items = new List<NewsReplyMessageItem>();

                for (int i = 0; i < dt.Rows.Count; i++) {
                    NewsReplyMessageItem itm = new NewsReplyMessageItem()
                    {
                        Description = dt.Rows[i]["Descriptions"].ToString(),
                        Url = dt.Rows[i]["Url"].ToString(),
                        PicUrl = dt.Rows[i]["PicUrl"].ToString(),
                        Title = dt.Rows[i]["Title"].ToString()
                    };
                    items.Add(itm);
                }
                dbHelper.Dispose();

                //List<NewsReplyMessageItem> items = new List<NewsReplyMessageItem>();
                //NewsReplyMessageItem itm = new NewsReplyMessageItem()
                //{
                //    Description = "入伏一过，三伏天步步逼近，如此高温，周末你是不是宅在家里，然后“健康”就跟隔壁老王出去玩了？",
                //    Url = "http://mp.weixin.qq.com/s?__biz=MzA4Nzc0MTExNw==&mid=206932752&idx=1&sn=c019a07e4b792a89ca9db52eab1ef4a9#rd",
                //    PicUrl = "https://mmbiz.qlogo.cn/mmbiz/wiawsQjia0DrAsbcaeV5xXxOQfoF7NoQrxgMwg3Wm7nIQKxB5f8cb4bZIrm0paahuP3wpibhJ72MiaI04clgttd9gA/0?wx_fmt=jpeg",
                //    Title = "再宅，你的健康就跟人跑了"
                //};

                NewsReplyMessage replyMsg = new NewsReplyMessage()
                {
                    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = msg.ToUserName,
                    ToUserName = msg.FromUserName,
                    Articles = items
                };

                //items.Add(itm);
                MessageHandler.SendReplyMessage(replyMsg);
            }
            else if (key == "subkey5")
            {
                List<NewsReplyMessageItem> items = new List<NewsReplyMessageItem>();
                NewsReplyMessageItem itm = new NewsReplyMessageItem()
                {
                    Description = "“大连运动健身网微信公众平台”是大连易是网络科技有限公司于2014年10月推出的大连本土市民运动健身公共信息服务平台。",
                    Url = "http://mp.weixin.qq.com/s?__biz=MzA4Nzc0MTExNw==&mid=202148672&idx=1&sn=0233ae5a7415fdbb93235f5fa1b18522#rd",
                    PicUrl = "https://mmbiz.qlogo.cn/mmbiz/wiawsQjia0DrC3tKKw5jqHpp18AqlXPYljfDA4C2FwYus1ZtQtc8mzZ1wJRCicptIUJE93w6lVsTsg3MDg43LRWfA/0?wx_fmt=jpeg",
                    Title = "关于我们"
                };

                NewsReplyMessage replyMsg = new NewsReplyMessage()
                {
                    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = msg.ToUserName,
                    ToUserName = msg.FromUserName,
                    Articles = items
                };

                items.Add(itm);
                MessageHandler.SendReplyMessage(replyMsg);
            }
            else if (key == "subkey6")
            {
                List<NewsReplyMessageItem> items = new List<NewsReplyMessageItem>();
                NewsReplyMessageItem itm = new NewsReplyMessageItem()
                {
                    Description = "不够牛，不够叼，不够美，不够精，就别戳我了！！！",
                    Url = "http://mp.weixin.qq.com/s?__biz=MzA4Nzc0MTExNw==&mid=206902104&idx=1&sn=e98881bad586e5424d2a6dc8a1c32b5d#rd",
                    PicUrl = "https://mmbiz.qlogo.cn/mmbiz/wiawsQjia0DrA5FLVbicZfg9bQMbJ7K6PUtenNWFuxtUmP0N6RiaWgJpu3IYKxr2Ka56PjFUDSLpTa95rPmpY7wOWQ/0?wx_fmt=jpeg",
                    Title = "非牛人，不要点"
                };

                NewsReplyMessage replyMsg = new NewsReplyMessage()
                {
                    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = msg.ToUserName,
                    ToUserName = msg.FromUserName,
                    Articles = items
                };

                items.Add(itm);
                MessageHandler.SendReplyMessage(replyMsg);
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
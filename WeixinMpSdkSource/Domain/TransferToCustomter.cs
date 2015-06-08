using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weixin.Mp.Sdk.Domain
{
    public abstract class TransferToCustomter
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgType MsgType { get; set; }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型） 
        /// </summary>
        public long CreateTime { get; set; }



        public abstract string ToXmlString();
    }

    public class TransferAutoCustomer : TransferToCustomter {
        public override string ToXmlString()
        {
            string s = "<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[transfer_customer_service]]></MsgType></xml>";
            s = string.Format(s,
                ToUserName ?? string.Empty,
                FromUserName ?? string.Empty,
                CreateTime.ToString()
                );
            return s;
        }
    }
}

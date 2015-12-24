using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Request;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk.Domain;
using System.Web.Script.Serialization;
using Weixin.Mp.Sdk.Util;
using System.Configuration;
using System.Text;

namespace WeiXin
{
    public partial class CreateMenu : System.Web.UI.Page
    {
        private string hosturl = ConfigurationManager.AppSettings["Host"].ToString();


        protected void Page_Load(object sender, EventArgs e)
        {
            CreateMenuTest();
        }

        public void CreateMenuTest()
        {
            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = ConfigurationManager.AppSettings["AppID"].ToString(), AppSecret = ConfigurationManager.AppSettings["AppSecret"].ToString() }
            };
            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Console.WriteLine("获取令牌环失败..");
                return;
            }

            Weixin.Mp.Sdk.Domain.Menu menu = new Weixin.Mp.Sdk.Domain.Menu();

            List<Weixin.Mp.Sdk.Domain.Button> button = new List<Weixin.Mp.Sdk.Domain.Button>();

            string[] subkeyText1 = { "趣运动" };
            string[] subkeyText2 = { "运动场", "协会"};
            string[] subkeyText3 = { "本期活动", "往期活动", "关于我们", "招贤纳士", "东软专区" };

            #region ==== SubMenu 1 ====
            List<Weixin.Mp.Sdk.Domain.Button> subBtnForKey1 = new List<Weixin.Mp.Sdk.Domain.Button>();
            int keyIndex = 1;
            foreach (string s in subkeyText1)
            {
                var clicktype = "click";
                var clickurl = "http://";
                if (s == "趣运动")
                {
                    clicktype = "view";
                    clickurl = "http://mp.weixin.qq.com/s?__biz=MzA4Nzc0MTExNw==&mid=400048887&idx=1&sn=f061fbdefc29a8200172480f75b3c7aa&scene=1&srcid=12113M1bX594nZF1FF5sdTVA&from=singlemessage&isappinstalled=0#wechat_redirect";//hosturl + "/webapp/list.aspx";
                }
                //else if (s == "找场馆")
                //{
                //    clicktype = "view";
                //    clickurl = hosturl + "/webapp/gym_list.aspx"; //"http://mp.weixin.qq.com/s?__biz=MzA4Nzc0MTExNw==&mid=203884252&idx=1&sn=26f6323d4b8f9da1046e5c126c796ebd#rd";
                //}


                Weixin.Mp.Sdk.Domain.Button subBtn = new Weixin.Mp.Sdk.Domain.Button()
                {
                    key = "subkey" + keyIndex,
                    name = s,
                    sub_button = null,
                    type = clicktype,
                    url = clickurl    //"http://dede.dlyssoft.com/WebApp/list.aspx?r=&s=" + keyIndex
                };
                subBtnForKey1.Add(subBtn);
                keyIndex++;

            }
            #endregion

            //List<Weixin.Mp.Sdk.Domain.Button> subBtnForKey2 = new List<Weixin.Mp.Sdk.Domain.Button>();

            //foreach (string s in subkeyText2)
            //{
            //    var clicktype = "click";
            //    var clickurl = "http://";
            //    if (s == "运动场")
            //    {
            //        clicktype = "view";
            //        clickurl = hosturl + "/webapp/gym_list.aspx";
            //    }
            //    else if (s == "协会") {
            //        clicktype = "view";
            //        clickurl = "http://mp.weixin.qq.com/s?__biz=MzA4Nzc0MTExNw==&mid=203884252&idx=1&sn=26f6323d4b8f9da1046e5c126c796ebd#rd";
            //    }
            //    Weixin.Mp.Sdk.Domain.Button subBtn = new Weixin.Mp.Sdk.Domain.Button()
            //    {
            //        key = "subkey" + keyIndex,
            //        name = s,
            //        sub_button = null,
            //        type = clicktype,
            //        url = clickurl
            //    };
            //    subBtnForKey2.Add(subBtn);
            //    keyIndex++;
            //}


            List<Weixin.Mp.Sdk.Domain.Button> subBtnForKey3 = new List<Weixin.Mp.Sdk.Domain.Button>();


            foreach (string s in subkeyText3)
            {
                var clicktype = "click";
                var clickurl = "http://";

                if (s == "往期活动")
                {
                    clicktype = "view";
                    clickurl = "http://mp.weixin.qq.com/mp/homepage?__biz=MzA4Nzc0MTExNw==&hid=1&sn=28565b5f17a562b386d06662a7f00272#wechat_redirect";
                }


                Weixin.Mp.Sdk.Domain.Button subBtn = new Weixin.Mp.Sdk.Domain.Button()
                {
                    key = "subkey" + keyIndex,
                    name = s,
                    sub_button = null,
                    type = clicktype,
                    url = clickurl
                };
                subBtnForKey3.Add(subBtn);
                keyIndex++;
            }


            Weixin.Mp.Sdk.Domain.Button btn = new Weixin.Mp.Sdk.Domain.Button()
            {
                key = "btn1",
                name = "趣运动",
                url = "http://mp.weixin.qq.com/s?__biz=MzA4Nzc0MTExNw==&mid=400048887&idx=1&sn=f061fbdefc29a8200172480f75b3c7aa#rd",
                type = "view"

            };
            button.Add(btn);

            btn = new Weixin.Mp.Sdk.Domain.Button()
            {
                key = "btn2",
                name = "问客服",
                url = "httpbig",
                type = "click",
                //sub_button = subBtnForKey2
            };
            button.Add(btn);

            btn = new Weixin.Mp.Sdk.Domain.Button()
            {
                key = "btn3",
                name = "资  讯",
                url = "httpbig",
                type = "click",
                sub_button = subBtnForKey3
            };
            button.Add(btn);

            menu.button = button;

            MenuGroup mg = new MenuGroup()
            {
                menu = menu
            };

            string postData = mg.ToJsonString();

            CreateMenuRequest createRequest = new CreateMenuRequest()
            {
                AccessToken = response.AccessToken.AccessToken,
                SendData = postData
            };

            CreateMenuResponse createResponse = mpClient.Execute(createRequest);

            if (createResponse.IsError)
            {
                Response.Write("创建菜单失败，错误信息为：" + createResponse.ErrInfo.ErrCode + "-" + createResponse.ErrInfo.ErrMsg);
            }
            else
            {
                Response.Write("创建菜单成功");
            }
        }

        private string escape(string s)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byteArr = System.Text.Encoding.Unicode.GetBytes(s);

            for (int i = 0; i < byteArr.Length; i += 2)
            {
                sb.Append("%u");
                sb.Append(byteArr[i + 1].ToString("X2"));//把字节转换为十六进制的字符串表现形式

                sb.Append(byteArr[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
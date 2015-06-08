<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="WebAPP.WebApp.Product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../ScriptsLib/Core/IsTech_core.js"></script>
    <script src="../ScriptsLib/Core/IsTech_form.js"></script>
    <script src="../ScriptsLib/WxPayService.js"></script>
    <script>
        wx.config({
        debug: true, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        appId: '<%=appid %>', // 必填，公众号的唯一标识
        timestamp: <%=timestamp %>, // 必填，生成签名的时间戳
        nonceStr: '<%=nonceStr %>', // 必填，生成签名的随机串
        signature: '<%=signature %>',// 必填，签名，见附录1
        jsApiList: [
        'checkJsApi',
        'onMenuShareTimeline',
        'onMenuShareAppMessage',
        'onMenuShareQQ',
        'onMenuShareWeibo',
        'hideMenuItems',
        'showMenuItems',
        'hideAllNonBaseMenuItem',
        'showAllNonBaseMenuItem',
        'translateVoice',
        'startRecord',
        'stopRecord',
        'onRecordEnd',
        'playVoice',
        'pauseVoice',
        'stopVoice',
        'uploadVoice',
        'downloadVoice',
        'chooseImage',
        'previewImage',
        'uploadImage',
        'downloadImage',
        'getNetworkType',
        'openLocation',
        'getLocation',
        'hideOptionMenu',
        'showOptionMenu',
        'closeWindow',
        'scanQRCode',
        'chooseWXPay',
        'openProductSpecificView',
        'addCard',
        'chooseCard',
        'openCard'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
    }); 
});

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="ClickMe" onclick="WxPayService.GetPayInfo()" />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            style="height: 21px" Text="购买" />
        
    </div>
    </form>
</body>
</html>

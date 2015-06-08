var WxPayService = {
    GetPayInfo: function () {
        IsTechForm.Post("/BussinessService/WxPayService.asmx/GetPayInfo", {}
            , function (response) {
                if ($("string", response).text() != "") {
                    var result = $("string", response);
                    alert(result.prepay_id)
                    //alert(json)
                    //                   wx.chooseWXPay({
                    //                        timestamp: 0, // 支付签名时间戳，注意微信jssdk中的所有使用timestamp字段均为小写。但最新版的支付后台生成签名使用的timeStamp字段名需大写其中的S字符
                    //                        nonceStr: '', // 支付签名随机串，不长于 32 位
                    //                        package: '', // 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=***）
                    //                        signType: '', // 签名方式，默认为'SHA1'，使用新版支付需传入'MD5'
                    //                        paySign: '', // 支付签名
                    //                        success: function (res) {
                    //                            // 支付成功后的回调函数
                    //                    }
                }
            }, false);
    },


    xmlToJson: function (xml) {
        var obj = {};
        if (xml.nodeType == 1) { // element
            // do attributes
            if (xml.attributes.length > 0) {
                obj["@attributes"] = {};
                for (var j = 0; j < xml.attributes.length; j++) {
                    var attribute = xml.attributes.item(j);
                    obj["@attributes"][attribute.nodeName] = attribute.nodeValue;
                }
            }
        } else if (xml.nodeType == 3) { // text
            obj = xml.nodeValue;
        }

        // do children
        if (xml.hasChildNodes()) {
            for (var i = 0; i < xml.childNodes.length; i++) {
                var item = xml.childNodes.item(i);
                var nodeName = item.nodeName;
                if (typeof (obj[nodeName]) == "undefined") {
                    obj[nodeName] = xmlToJson(item);
                } else {
                    if (typeof (obj[nodeName].length) == "undefined") {
                        var old = obj[nodeName];
                        obj[nodeName] = [];
                        obj[nodeName].push(old);
                    }
                    obj[nodeName].push(xmlToJson(item));
                }
            }
        }
        return obj;
    }
}
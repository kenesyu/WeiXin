var CustomerService = {
    ConnectCustomerService: function (openid) {
        var message = "";
        if ($("#lblSportName") != undefined && $("#lblSportName").text() != "") {
            message = "我对" + $("#lblSportName").text() + "教练[" + $("#lblName").text() + "]感兴趣想要咨询"
        } else {
            message = "我对运动场馆[" + $("#agymname").text() + "]感兴趣想要咨询"
        }
        IsTechForm.Post("/BussinessService/CustomerService.asmx/ConnectService", { openid: openid, message: message }
            , function (response) {
                if ($("string", response).text() != "") {
                    var result = $("string", response).text();
                    alert(result);
                }
            }, false);
    }
}
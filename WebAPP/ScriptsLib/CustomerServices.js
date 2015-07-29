var CustomerService = {
    ConnectCustomerService: function (openid, message) {
        alert(/xxxxx/)
        IsTechForm.Post("/BussinessService/CustomerService.asmx/ConnectService", { openid: openid, message: message }
            , function (response) {
                if ($("string", response).text() != "") {
                    var result = $("string", response).text();
                    alert(result);
                }
            }, true);
    },


    SentKey: function (openid, code, productid) {
        alert(/xxx/)
        IsTechForm.Post("/BussinessService/CustomerService.asmx/SentKey", { openid: openid, code: code, productid: productid }
        , function (response) {
            if ($("string", response).text() == "true") {
                //var result = $("string", response).text();
                alert("支付成功，请注意查收交易凭证！");
            }
        }, true);
    }
}
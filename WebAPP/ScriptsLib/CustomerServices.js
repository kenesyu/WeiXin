var CustomerService = {
    ConnectCustomerService: function (openid,message) {
        IsTechForm.Post("/BussinessService/CustomerService.asmx/ConnectService", { openid: openid, message: message }
            , function (response) {
                if ($("string", response).text() != "") {
                    var result = $("string", response).text();
                    alert(result);
                }
            }, true);
    }
}
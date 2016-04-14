var AdmServices = {
    SaveCurrentHD: function () {
        var Data = "";
        var flag = true;
        $("#tbList").find("tr[isdata=true]").each(function () {
            $(this).find("input[type=text]").each(function (idx) {
                if (idx < 5) {
                    if ($(this).val() == "") {
                        flag = false;
                    }
                    Data += $(this).val() + "~";
                }
            })
            Data += "|";
        })

        if (!flag) {
            alert("请添写所有项");
            return false;
        }


        IsTechForm.Post("/BussinessService/AdmService.asmx/SaveCurrentHD", { Data: Data }
        , function (response) {
            //if ($("string", response).text() == "true") {
            //var result = $("string", response).text();
            alert($("string", response).text());
            //}
        }, true);
    },

    SaveSubscribeMsg: function () {
        var Data = "";
        var flag = true;
        $("#tbList").find("tr[isdata=true]").each(function () {
            $(this).find("input[type=text]").each(function (idx) {
                if (idx < 5) {
                    if ($(this).val() == "") {
                        flag = false;
                    }
                    Data += $(this).val() + "~";
                }
            })
            Data += "|";
        })

        if (!flag) {
            alert("请添写所有项");
            return false;
        }


        IsTechForm.Post("/BussinessService/AdmService.asmx/SaveSubscribeMsg", { Data: Data }
        , function (response) {
            //if ($("string", response).text() == "true") {
            //var result = $("string", response).text();
            alert($("string", response).text());
            //}
        }, true);
    }
}
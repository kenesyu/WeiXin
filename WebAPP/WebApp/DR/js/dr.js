var dr = {
    LoadData: function (Page) {
        if (Page == "1") {
            $("#list1").html("");
        }
        var PageSize = 20;
        IsTechForm.Post("/WebApp/DR/service/drservice.asmx/search", { strKey: $("#strKey1").val(), Page: Page, PageSize: PageSize, order: "OrdResult asc" }
            , function (response) {
                var res = $.parseJSON($("string", response).text());
                var content = res.Contents;

                TotalPage1 = res.TotalPage;
                CurrentPage1 = res.CurrentPage;

                if (TotalPage1 == CurrentPage1) {
                    $("#btnMore1").css("display", "none");
                } else {
                    $("#btnMore1").css("display", "block");
                }

                if (content.length > 0) {
                    for (var i = 0; i < content.length; i++) {
                        var row = ""
                              + "<ul class=\"listBox\">"
                              + " <li class=\"list\">" + content[i].OrdResult + "</li>"
                              + " <li class=\"list\"><img width='50px' height='50px' src='" + content[i].headimgurl + "' /></br><a href='DR_Personal.aspx?op=" + content[i].openid + "'>" + content[i].Name + "</a></li>"
                              + " <li class=\"list listSecond\">" + content[i].Result + "</li>"
                              + " <li class=\"list\">" + content[i].XName + "</li>"
                              + "</ul>";
                        $("#list1").append(row);
                    }
                } else {
                    $("#btnMore1").css("display", "none");
                    $("#list1").append("找不到相关的数据！");
                }
            }, true);

    },


    LoadData1: function (Page) {
        if (Page == "1") {
            $("#list2").html("");
        }
        var PageSize = 20;
        IsTechForm.Post("/WebApp/DR/service/drservice.asmx/search", { strKey: $("#strKey2").val(), Page: Page, PageSize: PageSize, order: "OrdRQ asc" }
            , function (response) {
                var res = $.parseJSON($("string", response).text());
                var content = res.Contents;

                TotalPage2 = res.TotalPage;
                CurrentPage2 = res.CurrentPage;

                if (TotalPage2 == CurrentPage2) {
                    $("#btnMore2").css("display", "none");
                } else {
                    $("#btnMore2").css("display", "block");
                }

                if (content.length > 0) {
                    for (var i = 0; i < content.length; i++) {
                        var row = ""
                              + "<ul class=\"listBox\">"
                              + " <li class=\"list\">" + content[i].OrdRQ + "</br>(" + content[i].CountNum + "票)</li>"
                              + " <li class=\"list listSecond\">" + content[i].OrdResult + "</li>"
                              + " <li class=\"list\"><img width='50px' height='50px' src='" + content[i].headimgurl + "' /></br><a href='DR_Personal.aspx?op=" + content[i].openid + "'>" + content[i].Name + "</a></li>"
                              + " <li class=\"list\">" + content[i].XName + "</li>"
                              + "</ul>";
                        $("#list2").append(row);
                    }
                } else {
                    $("#btnMore2").css("display", "none");
                    $("#list2").append("找不到相关的数据！");
                }
            }, true);

    },



    More: function () {
        if (parseInt(CurrentPage1) < parseInt(TotalPage1)) {
            dr.LoadData(parseInt(CurrentPage1) + 1);
        }
    },

    More1: function () {
        if (parseInt(CurrentPage2) < parseInt(TotalPage2)) {
            dr.LoadData1(parseInt(CurrentPage2) + 1);
        }
    },


    SupportMe: function (openid, toopenid) {
        IsTechForm.Post("/WebApp/DR/service/drservice.asmx/supportme", { openid: openid, toopenid: toopenid }
            , function (response) {
                alert($("string", response).text());
            }, true);
    },


    GetInput: function (Num) {
        if (Num != "" && Num.length == 4) {
            IsTechForm.Post("/WebApp/DR/service/drservice.asmx/GetInput", { id: Num }
            , function (response) {
                $("#divinfo").html("");
                var res = $.parseJSON($("string", response).text());
                var content = res.Contents;
                if (content.length > 0) {
                    $("#divinfo").append("</br><img src='" + content[0].headimgurl + "' width='100px' height='100px'>");
                    $("#divinfo").append("</br>姓名：" + content[0].Name);
                    $("#divinfo").append("</br>院系：" + content[0].XName);
                    $("#divinfo").append("</br>成绩：<input type='text' id='txtResult' readonly='true' value='" + content[0].Result + "' onclick=\"_SetTime(this)\" />");
                    $("#divinfo").append("&nbsp;&nbsp;&nbsp;<input type='button' id='btnSave' value='保存' onclick='dr.SaveResult(" + content[0].ID + ")' />")
                }
                //alert($("string", response).text());
            }, true);

        } else {
            $("#divinfo").html("");
        }
    },

    SaveResult: function (id) {
        if ($("#txtResult").val() == "") {
            alert("请输入成绩");
            return false;
        } else {
            IsTechForm.Post("/WebApp/DR/service/drservice.asmx/SaveResult", { id: id, Result: $("#txtResult").val() }
            , function (response) {
                alert($("string", response).text());
            }, true);
        }
    },

    Login: function () {
        var pass = $("#password").val();
        IsTechForm.Post("/WebApp/DR/service/drservice.asmx/Login", { pass: pass }
            , function (response) {
                if ($("string", response).text() == "1") {
                    $("#logTab").css("display", "");
                    $("#divLogin").css("display", "none");
                } else {
                    alert("密码错误");
                    $("#logTab").css("display", "none");
                }
            }, true);

    }
}
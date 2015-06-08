var IsTech_util = {
    culture: {},
    valid: {},
    dialog: {},
    tab: {},
    security: {},
    helper: {},
    staticflag: {},
    history: {},
    download: {}
};

IsTech_util.staticflag = {
    EditFlag: false
};

IsTech_util.download = {
    DownloadFile: function(url) {
        var elemIF = document.createElement("iframe");
        elemIF.src = url;
        elemIF.style.display = "none";
        document.body.appendChild(elemIF);
    }
};

IsTech_util.history = {
    h_flag: false,
    h_login: false,
    h_list: new Array(10),
    h_index: 0,
    SaveHistory: function(index) {
        if (document.getElementById('hisStoryFrame')) {
            if (IsTech_util.history.h_index == 9) {
                IsTech_util.history.h_index = 0;
            } else {
                IsTech_util.history.h_index++;
            }
            IsTech_util.history.h_list[IsTech_util.history.h_index] = index;
            document.getElementById('hisStoryFrame').src = 'Browser.aspx?' + IsTech_util.history.h_index;
        }
    },
    GetHistory: function(curIndex) {
        if (curIndex != IsTech_util.history.h_index) {
            IsTech_util.history.h_index = curIndex;
            IsTech_util.history.h_flag = true;
            $('#MainTab').tabs('select', IsTech_util.history.h_list[curIndex]);
            if (IsTech_util.history.h_list[curIndex] == 3)
                $("#ctl00_ContentPlaceHolderMain_liNotification").css("display", "block");
            if (IsTech_util.history.h_list[curIndex] == 2)
                $("#ctl00_ContentPlaceHolderMain_liReport").css("display", "block");
            IsTech_util.history.h_flag = false;
        }
    }
};
IsTech_util.security = {
    RequestSecurityPage: function() {
        T2VForm.RequestPage('UserControl/Common/MasterMessage.uc', document.getElementById("MasterMessage"));
        $.ajax({
            type: "GET",
            url: "AjaxSecurityPage.aspx",
            data: "ranArg=" + Math.random(),
            success: function(response) {
                return;
            },
            error: function(xml, status) {
                document.location.href = 'signin.aspx';
            }
        });
    },
    Init: function() {
        T2VForm.RequestPage('UserControl/Common/MasterMessage.uc', document.getElementById("MasterMessage"));
        setInterval("IsTech_util.security.RequestSecurityPage();", 180000);
    }
};
IsTech_util.valid = {
    IsPlusNumber: function(s) {
        var reg = /^\d+(\.\d+)?$/;
        if (reg.test(s)) return false;
        return true;
    },
    IsPlusInteger: function(s) {
        var reg = /^[0-9]\d*$/;
        if (reg.test(s)) return false;
        return true;
    },
    IsEmail: function(s) {
        var patrn = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
        if (patrn.test(s)) return false
        return true
    },
    ConvertToJson: function(s) {
        s = s.replace(/(\\|\"|\')/g, "\\$1")
            .replace(/\n|\r|\t/g,
        function() {
            var a = arguments[0];
            return (a == '\n') ? '\\n' : ""
        });
        return s;
    },
    ConvertToResponse: function(s) {
        s = s.replace(/(\%)/g, "%25")
                    .replace(/(\#)/g, "%23")
                    .replace(/(\&)/g, "%26")
                    .replace(/(\=)/g, "%3D")
            .replace(/\n|\r|\t/g,
        function() {
            var a = arguments[0];
            return (a == '\n') ? '\\n' :
           (a == '\r') ? '\\r' :
           (a == '\t') ? '\\t' : ""
        });
        return s;
    },
    ConvertToUrlAndJson: function(s) {
        s = s.replace(/(\\|\"|\')/g, "\\\\\\$1")
                    .replace(/\n|\r|\t/g,
           function() {
               var a = arguments[0];
               return (a == '\n') ? '\\n' :
                    (a == '\r') ? '\\r' :
                    (a == '\t') ? '\\t' : ""
           });
        return s;
    }

};



IsTech_util.culture = {
    SetCookie: function(language) {
        var Days = 30;
        var exp = new Date(); //new Date("December 31, 9998");
        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
        document.cookie = "CurrentLanguage=" + language + ";path=/;"; //expires=" + exp.toGMTString();                
    },
    ChangeMulti: function(divList, enUrl, frUrl, async) {
        var data = IsTech_util.culture.GetLanguageData(enUrl, frUrl, async);
        for (var i = 0; i < divList.length; i++) {
            IsTech_util.culture.ChangeLanguage(divList[i], data);
        }
    },
    ChangeMultiByDiv: function(divList, enDiv, frDiv) {
        var data = IsTech_util.culture.GetLanguageDataByDiv(enDiv, frDiv);
        for (var i = 0; i < divList.length; i++) {
            IsTech_util.culture.ChangeLanguage(divList[i], data);
        }

    },
    GetLanguageDataByDiv: function(enDiv, frDiv) {
        var language = IsTech_util.culture.GetLanguage();
        if (language == "en-us") {
            return $(enDiv).html();
        }
        else {
            return $(frDiv).html();
        }
    },
    GetLanguageData: function(enUrl, frUrl, async) {
        var language = IsTech_util.culture.GetLanguage();
        var data;
        var isasync = false;
        if (async != undefined) {
            isasync = async;
        }

        if (language == "en-us") {
            $.ajax({
                type: "GET",
                url: enUrl,
                data: "ranArg=" + Math.random(),
                async: isasync,
                success: function(response) {
                    data = response;
                },
                error: function(xml, status) {
                    alert(xml.responseText);
                }
            });
        }
        else {
            $.ajax({
                type: "GET",
                url: frUrl,
                data: "ranArg=" + Math.random(),
                async: false,
                success: function(response) {
                    data = response;
                },
                error: function(xml, status) {
                    alert(xml.responseText);
                }
            });
        }
        return data;
    },
    ChangeOneLanguage: function(aDiv, enUrl, frUrl) {
        var data = IsTech_util.culture.GetLanguageData(enUrl, frUrl);
        IsTech_util.culture.ChangeLanguage(aDiv, data);
    },

    ChangeLanguage: function(aDiv, data) {
        var strXml = "";
        try {
            $("[metakey]", aDiv).each(function() {
                var metakey = $(this).attr("metakey");
                strXml += "<" + metakey + "><value></value><title></title></" + metakey + ">";
                if ($(metakey + " > value", data).length > 0) {
                    switch ($(this).attr("tagName")) {
                        case "INPUT":
                            {
                                $(this).val($(metakey + "> value", data).text());
                            }
                            break;
                        case "TH":
                            {
                                $(this).text($(metakey + " > value", data).text());
                            }
                            break;
                        case "TD":
                            {
                                $(this).text($(metakey + " > value", data).text());
                            }
                            break;
                        case "A":
                            {
                                $(this).text($(metakey + " > value", data).text());
                            }
                            break;
                        default:
                            $(this).text($(metakey + " > value", data).text());
                            break;
                    }
                }
            })
            if (IsTech_util.culture.GetLanguage() == "en-us") {
                $("[en]", aDiv).each(function() {
                    $(this).text($(this).attr("en"));
                })
            }
            else {
                $("[fr]", aDiv).each(function() {
                    $(this).text($(this).attr("fr"));
                })
            }
        }
        catch (e) {
            alert("languageError")
        }
    },
    GetLanguage: function() {
        var strCookie = document.cookie;
        var arrCookie = strCookie.split(";");
        for (var i = 0; i < arrCookie.length; i++) {
            var arr = arrCookie[i].split("=");
            if (arr[0] == "CurrentLanguage" || arr[0] == " CurrentLanguage")
                return arr[1];
        }
        return "fr-FR";
    },
    GetErrorInfo: function(key, resPreName) {
        var errorInfo = $("*").data("ErrorInfo");
        return $(key, errorInfo).text();
    },
    InitErrorInfo: function() {
        var currentLanguage = IsTech_util.culture.GetLanguage();
        var xmlUrl = "";
        if (currentLanguage == "en-us") {
            xmlUrl = "LanguageData/WarningInfo.en.xml?ran=" + Math.random();
        }
        else {
            xmlUrl = "LanguageData/WarningInfo.fr.xml?ran=" + Math.random();
        }
        $.ajax({
            type: "GET",
            url: xmlUrl,
            data: "ranArg=" + Math.random(),
            success: function(response) {
                $("*").data("ErrorInfo", response);
            }
        });
    },
    GetLanguageForcalendar: function() {
        return this.GetLanguage().substring(0, 2);
    }
};

IsTech_util.dialog = {
    JqConfirm: function(txt, callback) {
        var dialogYes = IsTech_util.culture.GetErrorInfo("Dialog_Yes");
        var dialogNo = IsTech_util.culture.GetErrorInfo("Dialog_No");
        $.alerts.okButton = '&nbsp;' + dialogYes + '&nbsp;';
        $.alerts.cancelButton = '&nbsp;' + dialogNo + '&nbsp;';
        jConfirm(txt, '', callback);

    },
    Open: function(divName) {
        $("#" + divName).html("<img  src='App_Themes/Default/Images/load.gif'/>");
        $("#" + divName).dialog("open");
    },
    Close: function(divName) {
        $("#" + divName).dialog("close");
    },
    OpenPopWindow: function(url) {
        var LeftPos = (screen.width - 600) / 2;
        var TopPos = (screen.height - 250) / 2;
        window.open(url, '', 'height=500, width=550, top=' + LeftPos + ', left=' + TopPos + ', toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no')
    },
    FunctionLoading: function(cmd) {
        if (cmd == "open") {
            $(".functionLoading").show();
        }

        if (cmd == "close") {
            $(".functionLoading").hide();
        }
    }
};




(function ($) {
    var oldHTML = $.fn.html;

    $.fn.formhtml = function () {
        if (arguments.length) return oldHTML.apply(this, arguments);
        $("input,textarea,button", this).each(function () {
            this.setAttribute('value', this.value);
        });
        $(":radio,:checkbox", this).each(function () {
            if (this.checked) this.setAttribute('checked', 'checked');
            else this.removeAttribute('checked');
        });
        $("option", this).each(function () {
            if (this.selected) this.setAttribute('selected', 'selected');
            else this.removeAttribute('selected');
        });
        return oldHTML.apply(this);
    };
})(jQuery);

(function ($) {
    $.fn.IsTechForm = function (p) {
        aDiv = $(this);
        op = $.extend({
            operationUrl: "",
            autoLoadType: "None",
            errorContainer: "errorContainer"
        }, p);


        var IsTechFormBase = {
            SaveIsTechFormConfig: function () {
                var IsTechFormConfigData = eval('(' + $("[DataField=IsTechFormConfigData]", IsTechFormBase.aDiv).val() + ')');
                IsTechFormBase.IsTechFormConfigData = IsTechFormConfigData;
            },

            ChangeLanguage: function () {
                if (IsTechFormBase.OperationType == "Edit") {
                    IsTechFormBase.aDiv.IsTechFormShowEdit(IsTechFormBase["OperationArgs1"], IsTechFormBase["OperationArgs2"]);
                }
                if (IsTechFormBase.OperationType == "Detail") {
                    IsTechFormBase.aDiv.IsTechFormShowDetail(IsTechFormBase["OperationArgs1"], IsTechFormBase["OperationArgs2"]);
                }
            },
            SetLanguage: function (languageData) {
                for (var i = 0; i < languageData.length; i++) {
                    var enUrl = languageData[i].enUrl;
                    var frUrl = languageData[i].frUrl;
                    var divs = new Array();
                    for (var index = 0; index < languageData[i].divIDs.length; index++) {
                        divs.push($("#" + languageData[i].divIDs[index]));
                    }

                    t2v_util.culture.ChangeMulti(divs, enUrl, frUrl);
                }
            },
            SubmitData: function (afterSave, beforeSave, otherData) {
                var data = IsTechForm.GetJsonDataByConfig(IsTechFormBase.IsTechFormConfigData);
                data["OperationType"] = "Submit";
                data["r"] = Math.random();
                if (otherData != undefined) {
                    $.each(otherData, function (key, value) {
                        data[key] = value;
                    });
                }
                if (beforeSave != undefined)
                    beforeSave(data);
                var IsTechFormConfig = IsTechFormBase.IsTechFormConfigData[0];
                var groupName = IsTechFormConfig.GroupName
                var dataStr = "{";
                $.each(data[groupName], function (key, value) {
                    if (dataStr != "{")
                        dataStr += ",";
                    dataStr += "\"" + key + "\" : \"" + value + "\"";
                });
                dataStr += "}"
                data[groupName] = dataStr;
                $.ajax({
                    type: "POST",
                    url: IsTechFormBase.op.operationUrl,
                    data: data,
                    async: true,
                    beforeSend: function (xhr) {
                        $("#divLoading").show();
                    },
                    success: function (response) {
                        var valid = true;
                        if (response.indexOf("IsTechFormSaveError") >= 0) {
                            valid = false;
                            $("#" + IsTechFormBase.op.errorContainer).html(response);
                            $("#" + IsTechFormBase.op.errorContainer).show();
                            t2v_util.staticflag.EditFlag = true;
                        }
                        else {
                            IsTechFormBase.aDiv.html(response);
                            t2v_util.staticflag.EditFlag = false;
                        }
                        if (afterSave != undefined)
                            afterSave(response, valid);
                    },
                    error: function (xml, status) {
                        alert(xml.responseText);
                    },
                    complete: function () {
                        $("#divLoading").hide();
                    }
                });
                return true;
            },
            SaveData: function (afterSave, beforeSave, otherData) {
                var data = IsTechForm.GetJsonDataByConfig(IsTechFormBase.IsTechFormConfigData);
                data["OperationType"] = "Save";
                data["r"] = Math.random();
                if (otherData != undefined) {
                    $.each(otherData, function (key, value) {
                        data[key] = value;
                    });
                }
                if (beforeSave != undefined)
                    beforeSave(data);
                var IsTechFormConfig = IsTechFormBase.IsTechFormConfigData[0];
                var groupName = IsTechFormConfig.GroupName
                var dataStr = "{";
                $.each(data[groupName], function (key, value) {
                    if (dataStr != "{")
                        dataStr += ",";
                    dataStr += "\"" + key + "\" : \"" + value + "\"";
                });
                dataStr += "}"
                data[groupName] = dataStr;
                $.ajax({
                    type: "POST",
                    url: IsTechFormBase.op.operationUrl,
                    data: data,
                    async: true,
                    beforeSend: function (xhr) {
                        $("#divLoading").show();
                    },
                    success: function (response) {
                        var valid = true;
                        if (response.indexOf("IsTechFormSaveError") >= 0) {
                            valid = false;
                            $("#" + IsTechFormBase.op.errorContainer).html(response);
                            $("#" + IsTechFormBase.op.errorContainer).show();
                            t2v_util.staticflag.EditFlag = true;
                        }
                        else {
                            IsTechFormBase.aDiv.html(response);
                            t2v_util.staticflag.EditFlag = false;
                        }
                        if (afterSave != undefined)
                            afterSave(response, valid);
                    },
                    error: function (xml, status) {
                        alert(xml.responseText);
                    },
                    complete: function () {
                        $("#divLoading").hide();
                    }
                });
                return true;
            }
        };

        IsTechFormBase.aDiv = $(this);
        IsTechFormBase.loadType = "None";
        IsTechFormBase.op = op;
        $(this).data("IsTechFormBase", IsTechFormBase);
    }

    $.fn.IsTechFormSubmitData = function (afterSave, beforeSave, otherData) {
        var IsTechFormBase = $(this).data("IsTechFormBase");
        $("#" + IsTechFormBase.op.errorContainer).empty();
        $("#" + IsTechFormBase.op.errorContainer).hide();
        var saveResult = IsTechFormBase.SubmitData(afterSave, beforeSave, otherData);
        return saveResult;
    }

    $.fn.IsTechFormSaveData = function (afterSave, beforeSave, otherData) {
        var IsTechFormBase = $(this).data("IsTechFormBase");
        $("#" + IsTechFormBase.op.errorContainer).empty();
        $("#" + IsTechFormBase.op.errorContainer).hide();
        var saveResult = IsTechFormBase.SaveData(afterSave, beforeSave, otherData);
        return saveResult;
    }

    //Public Show Detail Function
    $.fn.IsTechFormShowDetail = function (data, callback) {
        var originalData = data;

        var IsTechFormBase = $(this).data("IsTechFormBase");
        $("#" + IsTechFormBase.op.errorContainer).empty();
        $("#" + IsTechFormBase.op.errorContainer).hide();
        data["OperationType"] = "Detail";
        data["r"] = Math.random();
        IsTechFormBase["OperationType"] = "Detail";
        IsTechFormBase["OperationArgs1"] = data;
        IsTechFormBase["OperationArgs2"] = callback;
        $.ajax({
            type: "Post",
            url: IsTechFormBase.op.operationUrl,
            data: data,
            async: true,
            beforeSend: function (xhr) {
                $("#divLoading").show();
            },
            success: function (response) {
                IsTechFormBase.aDiv.html(response);
                IsTechFormBase.SaveIsTechFormConfig();
                if (callback != undefined)
                    callback();
            },
            error: function (xml, status) {
                IsTechFormBase.aDiv.html(xml.responseText);
            },
            complete: function () {
                $("#divLoading").hide();
            }
        });

        t2v_util.staticflag.EditFlag = false;
    }

    $.fn.IsTechFormShowEdit = function (data, callback) {
        var originalData = data;
        var IsTechFormBase = $(this).data("IsTechFormBase");
        $("#" + IsTechFormBase.op.errorContainer).empty();
        $("#" + IsTechFormBase.op.errorContainer).hide();
        data["OperationType"] = "Edit";
        data["r"] = Math.random();
        IsTechFormBase["OperationType"] = "Edit";
        IsTechFormBase["OperationArgs1"] = data;
        IsTechFormBase["OperationArgs2"] = callback;

        $.ajax({
            type: "Post",
            url: IsTechFormBase.op.operationUrl,
            data: data,
            async: true,
            beforeSend: function (xhr) {
                $("#divLoading").show();
            },
            success: function (response) {
                IsTechFormBase.aDiv.html(response);
                IsTechFormBase.SaveIsTechFormConfig();
                if (callback != undefined)
                    callback();
            },
            error: function (xml, status) {
                IsTechFormBase.aDiv.html(xml.responseText);
            },
            complete: function () {
                $("#divLoading").hide();
            }
        });

        t2v_util.staticflag.EditFlag = true;
    }

    $.fn.IsTechFormPost = function (url, data, callback) {
        aDiv = $(this);
        data["r"] = Math.random();
        $.ajax({
            type: "Post",
            url: url,
            data: data,
            async: true,
            beforeSend: function (xhr) {
                $("#divLoading").show();
            },
            success: function (response) {
                aDiv.html(response);
                if (callback != undefined)
                    callback();
            },
            error: function (xml, status) {
                aDiv.html(xml.responseText);
            },
            complete: function () {
                $("#divLoading").hide();
            }
        });
    }

    $.fn.IsTechFormChangeLanguage = function () {
        var IsTechFormBase = $(this).data("IsTechFormBase");
        IsTechFormBase.ChangeLanguage();
    }

})(jQuery);

var IsTechForm = {
    PostModelPage: function (url, div, data) {
        div.html("Loading...").dialog("open").empty();
        IsTechForm.PostPage(url, div, data);
    },
    PostAsync: function (url, data, callback) {
        if (data == undefined)
            data = {};
        $.ajax({
            type: "Post",
            url: url,
            data: data,
            async: false,
            beforeSend: function (xhr) {
                $("#divLoading").show();
            },
            success: function (response) {
                if (callback != undefined) {
                    callback(response);
                }
            },
            error: function (xml, status) {
                alert(xml.responseText);
            },
            complete: function () {
                $("#divLoading").hide();
            }
        });
    },
    Post: function (url, data, callback, Async) {
        if (Async == undefined) {
            Async = true;
        }
        if (data == undefined)
            data = {};
        $.ajax({
            type: "Post",
            url: url,
            data: data,
            async: Async,
            cache: false,
            beforeSend: function (xhr) {
                $("#divLoading").show();
            },
            success: function (response) {
                if (callback != undefined) {
                    callback(response);
                }
            },
            error: function (xml, status) {
                alert(xml.responseText);
            },
            complete: function () {
                $("#divLoading").hide();
            }
        });
    },
    MergeJsonData: function (data1, data2) {

        $.each(data2, function (key, value) {

            data1[key] = value;
        });
    },
    SetDivFormData: function (div, jsonData) {
        div.find("[DataField]").each(function (i) {
            var dataField = $(this).attr("DataField");
            if (dataField != undefined) {
                IsTechForm.SetControlData($(this), jsonData[dataField]);
            }
        });
    },
    GetDivFormData: function (div) {
        var data = {};
        div.find("[DataField]").each(function (i) {
            data[$(this).attr("DataField")] = IsTechForm.GetControlData($(this));
        });
        return data;
    },
    GetJsonDataByConfig: function (IsTechFormConfigData) {
        var data = {};
        for (var i = 0; i < IsTechFormConfigData.length; i++) {
            var IsTechFormConfig = IsTechFormConfigData[i];
            if (IsTechFormConfig.GroupType == "DIV") {
                data[IsTechFormConfig.GroupName] = IsTechForm.GetDivFormDataByConfig(IsTechFormConfig);
            }
        }
        return data;
    },
    GetDivFormDataByConfig: function (IsTechFormConfig) {
        var div = $("#" + IsTechFormConfig.ControlID);
        var data = {};
        for (var i = 0; i < IsTechFormConfig.DataFields.length; i++) {
            var dataFieldName = IsTechFormConfig.DataFields[i].DataFieldName;
            var control = $(div).find("[DataField=" + dataFieldName + "]");
            if (control.length > 0) {
                data[dataFieldName] = IsTechForm.GetControlData($(control));
            }
        }
        return data;
    },
    GetInputData: function (control) {
        var data = "";
        var inputData = IsTechForm.GetControlData(control);
        inputData = t2v_util.valid.ConvertToUrlAndJson(inputData);
        data += $(control).attr("DataField") + ":'" + inputData + "'";
        return data;
    },
    GetControlData: function (control) {
        var data = "";
        switch ($(control).attr("tagName")) {
            case "INPUT":
                {
                    if ($(control).attr("type") == "checkbox") {
                        data += $(control).attr("checked");
                    }
                    else
                        data += $(control).val();
                }
                break;
            case "SPAN":
                {
                    data += $(control).text();
                }
                break;
            case "SELECT":
                {
                    data += $(control).val();
                }
                break; default:
                data += $(control).val();
                break;
        }
        return t2v_util.valid.ConvertToUrlAndJson(data);
    },
    SetControlData: function (control, data) {
        switch ($(control).attr("tagName")) {
            case "INPUT":
                {
                    data += $(control).val(data);
                }
                break;
            case "SPAN":
                {
                    data += $(control).text(data);
                }
                break;
            default:
                data += $(control).val(data);
                break;
        }

    },
    RequestPage: function (url, div, data, op) {
        var requestData = data;
        if (data != "" || data != undefined) {
            requestData += "&";
        }

        requestData += "ranArg=" + Math.random();
        var responseData = $.ajax({
            type: "GET",
            url: url,
            data: requestData,
            async: false,
            beforeSend: function (xhr) {
                $("#divLoading").show();
            },
            success: function (response) {
                $(div).html(response);
            },
            error: function (xml, status) {
                $(div).html(xml.responseText);
            },
            complete: function () {
                $("#divLoading").hide();
            }
        })
    },
    PostPage: function (url, div, data) {
        if (data == undefined)
            data = {};
        data["r"] = Math.random();
        $.ajax({
            type: "Post",
            url: url,
            data: data,
            async: false,
            beforeSend: function (xhr) {
                $("#divLoading").show();
            },
            complete: function () {
                $("#divLoading").hide();
            },
            success: function (response) {
                $(div).html(response);
            },
            error: function (xml, status) {
                $(div).html(xml.responseText);
            }
        });
    }
}
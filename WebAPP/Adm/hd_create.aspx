<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hd_create.aspx.cs" Inherits="WebAPP.Adm.hd_create" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/jquery.idTabs.min.js"></script>
<script type="text/javascript" src="js/select-ui.min.js"></script>
<script type="text/javascript" src="editor/kindeditor.js"></script>
<script type="text/javascript" src="../ScriptsLib/jedate/jedate.js"></script>
</head>

<body>
<form runat="server" id="form1">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">活动管理</a></li>
    <li><a href="#">添加活动</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>添加活动</span></div>
    <input id="txtid" type="text" style="display:none" runat="server">
    <ul id="formBody" class="forminfo">
    <li><label>活动名称</label><input id="txthdName" runat="server" type="text" class="dfinput" /><i></i></li>
    <li><label>报名数</label><input id="txtQuantity" runat="server" type="text" class="dfinput" /><i></i></li>
    <li><label>优惠价(元)</label><input id="txtNewPrice" runat="server" type="text" class="dfinput" /><i></i></li>
    <li><label>原价(元)</label><input id="txtOldPrice" runat="server" type="text" class="dfinput" /><i></i></li>
    <li><label>活动时间</label><input id="txtHDTime" readonly="readonly" runat="server" type="text" class="dfinput" /></li>
    <li><label>报名截止</label><input id="txtEndTime" readonly="readonly" runat="server" type="text" class="dfinput" /></li>
    <li><label>活动介绍</label><textarea cols="5" runat="server" id="txtDetails" rows="5" class="textinput"></textarea></li>
    <li><label>&nbsp;</label>
        <asp:Button runat="server" id="btnSave" class="btn" Text="确认保存"  OnClientClick="return checkSave();"
            onclick="btnSave_Click" /></li>
    </ul>
    
    
    </div>
</form>
<script>
    function checkSave() {
        //if($("#txt"))
        var flag = true;
        $("#formBody").find("input[type=text]").each(function (idx) {
            if ($(this).val() == "") {
                alert("请输入[" + $(this).parent().find("label").eq(0).text() + "]");
                flag = false;
                return false;
            }
        })
        return flag;
    }
</script>

<script>
    jeDate({
        dateCell: "#txtEndTime",
        format: "YYYY-MM-DD hh:mm:ss",
        isTime: true, //isClear:false,
        minDate: "2014-09-19 00:00:00",
        okfun: function (val) { }
    })
    jeDate({
        dateCell: "#txtHDTime",
        format: "YYYY-MM-DD hh:mm:ss",
        isTime: true, //isClear:false,
        minDate: "2014-09-19 00:00:00",
        okfun: function (val) { }
    })
</script>
</body>

</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TP_Create.aspx.cs" Inherits="WebAPP.Adm.TP_Create" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="/assets/uploadify/uploadify.css">
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/jquery.idTabs.min.js"></script>
<script type="text/javascript" src="js/select-ui.min.js"></script>
<script type="text/javascript" src="../ScriptsLib/jedate/jedate.js"></script>


<style>
    body{ padding:50px 0 0 50px;}
    .datainp{ width:200px; height:30px; border:1px #ccc solid;}
    .datep{ margin-bottom:40px;}
</style>
</head>

<body>
    <form id="Form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">投票管理</a></li>
    <li><a href="#">新建投票</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>投票信息</span></div>
    
    <ul class="forminfo">
    <input id="txtid" runat="server" type="text" style="display:none" value="0" />
    <li><label>投票名称</label><input id="txtName" runat="server" type="text" class="dfinput" value="" /></li>
    <li><label>开始时间</label><input class="dfinput" readonly id="txtStartTime" runat="server" type="text"  value="" /></li>
    <li><label>结束时间</label><input id="txtEndTime" readonly runat="server" type="text" class="dfinput" value="" /></li>
    <li align="center"><asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" 
            onclick="btnSave_Click" /></li>
    </ul>
    </div>
    </form>
</body>
<script>
    jeDate({
        dateCell: "#txtStartTime",
        format: "YYYY-MM-DD hh:mm:ss",
        isinitVal: true,
        isTime: true, //isClear:false,
        minDate: "2014-09-19 00:00:00",
        okfun: function (val) {  }
    })

    jeDate({
        dateCell: "#txtEndTime",
        format: "YYYY-MM-DD hh:mm:ss",
        isinitVal: true,
        isTime: true, //isClear:false,
        minDate: "2014-09-19 00:00:00",
        okfun: function (val) {  }
    })
</script>
</html>

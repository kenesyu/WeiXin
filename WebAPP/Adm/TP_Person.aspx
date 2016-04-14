<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TP_Person.aspx.cs" Inherits="WebAPP.Adm.TP_Person" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

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
<script type="text/javascript" src="/assets/uploadify/jquery.uploadify.min.js"></script>
    <style type="text/css">
        .style1
        {
            height: 37px;
        }
    </style>
</head>

<body>
    <form id="Form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">投票管理</a></li>
    <li><a href="#">投票项</a></li>
    </ul>
    </div>
    
    <div class="formbody">
        <ul class="forminfo">
    <input id="txtTPID" runat="server" type="text" style="display:none" value="0" />
    <li><label>姓名</label><input id="txtName" runat="server" type="text" class="dfinput" value="" /></li>
    <li><label>序号</label><input id="txtNo" runat="server" type="text" class="dfinput" value="" /></li>
    <li>
        <div id="queue"></div>
		<input id="file_upload" name="file_upload" type="file" multiple="false" />
        <img id="imgAvatar" runat="server" src="" width="100" height="100"><label>照片</label><input type="text" style="display:none" id="txtAvatar" runat="server"/>
    </li>
    <li><label></label><asp:Button ID="btnSave" runat="server" Text="添加" CssClass="btn" 
            onclick="btnSave_Click" /></li>
    </ul>
    </br>
    <div class="formtitle"><span>投票项</span></div>
        <table class="tablelist" cellpadding="2" cellspacing="2">
    	<thead>
    	<tr>
        <th>序号</th>
        <th>姓名</th>
        <th>头像</th>
        <th>操作</th>
        </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="repList" runat="server" onitemcommand="repList_ItemCommand">
            <ItemTemplate>
         <%--       <tr class="click">--%>
                <tr>
                    <td><%# Eval("PersonNo")%></td>
                    <td><%# Eval("PersonName")%></td>
                    <td><a target="_blank" href="/img/tp/<%# Eval("Pic")%>"><%# Eval("Pic")%></a></td>
                    <td><asp:LinkButton runat="server" CommandName="Del" CommandArgument='<%# Eval("ID")%>' Text="删除"></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="4" align="center">
                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="" runat="server" 
                    onpagechanging="AspNetPager1_PageChanging">
                </webdiyer:AspNetPager>
            </td>
        </tr>
        </tbody>
    </table>

    </div>
    <script>
        $(function () {
            var id = $("#txtcoachid").val();
            $('#file_upload').uploadify({
                'swf': '/assets/uploadify/uploadify.swf',
                'uploader': 'UploadTP.axd',
                'script': 'UploadTP.axd',
                'buttonText': '',
                'multi': false,
                'fileTypeExts': '*.gif; *.jpeg; *.jpg; *.png',
                'onUploadStart': function (file) {
                    //$("#file_upload").uploadify("settings", "formData", { 'jqfgid': id });
                    //在onUploadStart事件中，也就是上传之前，把参数写好传递到后台。  
                },
                'onUploadSuccess': function (file, data, response) {
                    $("#txtAvatar").val(data);
                    $("#imgAvatar").attr("src", "/img/tp/" + data);
                    //$("#txtImg").val($("#txtImg").val() + "," + data);
                }
            });
        });
    </script>
    </form>
</body>

</html>

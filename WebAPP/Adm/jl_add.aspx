<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jl_add.aspx.cs" Inherits="WebAPP.Adm.jl_add" %>

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
</head>

<body>
    <form runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">教练管理</a></li>
    <li><a href="#">添加教练</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>教练信息</span></div>
    
    <ul class="forminfo">
    <input id="txtcoachid" runat="server" type="text" value="0" />
    <li><label>姓名</label><input id="txtCoachName" runat="server" type="text" class="dfinput" value="" /></li>
    <li><label>性别</label>
    					<select class="dfinput">                         <option>--请选择-- </option>                         <option selected="selected">男</option>                         <option>女</option>                     </select>
    </li>
    <li>
        <div id="queue"></div>
		<input id="file_upload" name="file_upload" type="file" multiple="false" />
        <img id="imgAvatar" src="" width="100px" height="100px"><label>头像</label><input type="text" id="txtAvatar" runat="server" style="" />
    </li>
    <li><label>简介</label><input name="" runat="server" id="txtSignature" type="text" class="dfinput" value="" /></li>
    <li><label>运动项目</label><select id="selSoports" runat="server" class="dfinput">         <option>--请选择-- </option>     </select></li>
    <li><label>区域</label><asp:CheckBoxList ID="CheckBoxList1" runat="server" 
            RepeatColumns="5" RepeatDirection="Horizontal" Width="276px">
        </asp:CheckBoxList>
        </li>
    <li><label>年龄</label><input name="" type="text" class="dfinput" /></li>
    <li><label>电话</label><input name="" type="text" class="dfinput" /></li>
    <li><label>微信</label><input name="" type="text" class="dfinput" /></li>
    <li><label>详细信息</label>
    <textarea rows="5" style="border-top:solid 1px #a7b5bc; border-left:solid 1px #a7b5bc; border-right:solid 1px #ced9df; border-bottom:solid 1px #ced9df; background:url(../images/inputbg.gif) repeat-x; line-height:20px; overflow:hidden;width:80%">
    </textarea></li>
    <li>
    <div id="queue1"></div>
		<input id="file_upload1" name="file_upload1" type="file" multiple="false" />
        <label>个人相册</label><input id="txtCoachPhoto" value="0" type="text" runat="server" />
    </li>
    <li><label></label><asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" 
            onclick="btnSave_Click" /></li>
    </ul>
    </div>
    
    <script>
        $(function () {
            var id = $("#txtcoachid").val();
            $('#file_upload').uploadify({
                'swf': '/assets/uploadify/uploadify.swf',
                'uploader': 'UploadAvatar.axd',
                'script': 'UploadAvatar.axd',
                'buttonText': '',
                'multi': false,
                'fileTypeExts': '*.gif; *.jpeg; *.jpg; *.png',
                'onUploadStart': function (file) {
                    //$("#file_upload").uploadify("settings", "formData", { 'jqfgid': id });
                    //在onUploadStart事件中，也就是上传之前，把参数写好传递到后台。  
                },
                'onUploadSuccess': function (file, data, response) {
                    $("#txtAvatar").val(data);
                    $("#imgAvatar").attr("src", "/img/avatar/" + data);
                    //$("#txtImg").val($("#txtImg").val() + "," + data);
                }
            });


            $('#file_upload1').uploadify({
                'swf': '/assets/uploadify/uploadify.swf',
                'uploader': 'UploadMulti.axd',
                'script': 'UploadMulti.axd',
                'buttonText': '',
                'multi': true,
                'fileTypeExts': '*.gif; *.jpeg; *.jpg; *.png',
                'onUploadStart': function (file) {
                    $("#file_upload1").uploadify("settings", "formData", { 'coachid': id });
                    //在onUploadStart事件中，也就是上传之前，把参数写好传递到后台。  
                },
                'onUploadSuccess': function (file, data, response) {
                    $("#txtCoachPhoto").val($("#txtCoachPhoto").val() + "," + data);
                }
            });
        });
    </script>
    </form>
</body>

</html>

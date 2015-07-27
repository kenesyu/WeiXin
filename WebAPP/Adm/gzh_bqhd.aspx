﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gzh_bqhd.aspx.cs" Inherits="WebAPP.Adm.gzh_bqhd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/jquery.js" ></script>
</head>
<body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">公众号设置</a></li>
    <li><a href="#">本期活动</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>本期活动</span></div>
    <input type="button" value="添加一条" onclick="addtr()" class="btn">
    <br /><br />
        <table class="tablelist" id="tbList">
    	    <thead>
    	    <tr>
            <th>标题</th>
            <th>描述</th>
            <th>图片地址</th>
            <th>原文地址</th>
            <th>排序</th>
            <th>操作</th>
            </tr>
            </thead>
        <tbody>
        <%=retHtml%>
        </tbody>
    </table>
    
    </div>
<script>
    function removetr(obj) {
        if (confirm("确定移除此行？")) {
            if ($(obj).parent().parent().parent().find("tr").length >= 2) {
                $(obj).parent().parent().remove();
            } else {
                alert("不能全部移除值少保留一行");
            }
        }
    }

    function addtr() {
        var temp = "<tr><td width='20%'><input type='text' class='dfinput' style='width:95%'/></td><td width='20%'><input type='text' class='dfinput' style='width:95%'/></td><td width='20%'><input type='text' class='dfinput' style='width:95%'/></td><td width='20%'><input type='text' class='dfinput' style='width:95%'/></td><td><input type='text' class='dfinput' /></td><td><input type='button' class='btn' value='移除' onclick='removetr(this);' /></td></tr> ";
        $("#tbList").append(temp);
    }

</script>

</body>
</html>

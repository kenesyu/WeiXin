<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jl_add.aspx.cs" Inherits="WebAPP.Adm.jl_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
</head>

<body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">设施管理</a></li>
    <li><a href="#">设施报修</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>报修表</span></div>
    
    <ul class="forminfo">
    <li><label>标题</label><input name="" type="text" class="dfinput" value="健身器材损坏" /><i>标题不能超过30个字符</i></li>
    <li><label>行政区域</label>
    					<select class="dfinput">                         <option>&nbsp;&nbsp;--请选择-- </option>                         <option selected="selected">&nbsp;&nbsp;中山区</option>                         <option>&nbsp;&nbsp;西岗区</option>                         <option>&nbsp;&nbsp;沙河口区</option>                         <option>&nbsp;&nbsp;甘井子区</option>                     </select>
    </li>
    <li><label>街道</label><cite>
    <select  class="dfinput">                         <option>&nbsp;&nbsp;--请选择-- </option>                         <option>&nbsp;&nbsp;桂林街道</option>                         <option selected="selected">&nbsp;&nbsp;海军广场街道</option>                         <option>&nbsp;&nbsp;葵英街道</option>                     </select>
    </cite></li>
    <li><label>具体位置</label><input name="" type="text" class="dfinput" value="铁路大院内安民31南侧" /></li>
    <li><label>损毁情况</label><textarea name="" cols="" rows="" class="textinput">健身器材XXX损坏，需要更换！！！</textarea></li>
    <li><label>图片上传</label><input name="" type="file" class="dfinput" /></li>
    <li><label>&nbsp;</label><input name="" type="button" class="btn" value="上报维修" onclick="location.href='message.htm'"/></li>
    </ul>
    
    
    </div>


</body>

</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DR_Personal.aspx.cs" Inherits="WebAPP.WebApp.DR.DR_Personal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>东软平板支撑比赛</title>
    <link rel="stylesheet" href="/css/list.css"/>
    <link rel="stylesheet" href="/css/listStyle.css"/>
    <link rel="stylesheet" href="/css/flat-ui.css"/>
    <link rel="stylesheet" href="/css/bootstrap.css"/>
    <script type="text/javascript"  src="/js/jquery.js"></script>
    <script type="text/javascript"  src="/js/application.js"></script>
    <script type="text/javascript"  src="/js/flat-ui.min.js"></script>
    <script type="text/javascript"  src="/js/aply.js"></script>
    <script type="text/javascript" src="/ScriptsLib/Core/IsTech_core.js"></script>
    <script type="text/javascript" src="/ScriptsLib/Core/IsTech_form.js"></script>
    <script type="text/javascript" src="/webapp/dr/js/dr.js"></script>

</head>
<body style="text-align: center">
<!--头像-->
<div class="imgBox">
    <img id="img" runat="server" src="" >
</div>

<div class="name"><asp:Label runat="server" ID="txtName"></asp:Label></div>
<div class="name"><asp:Label runat="server" ID="txtNo"></asp:Label></div>
<div class="name"><asp:Label runat="server" ID="txtResult"></asp:Label></div>
<div class="name"><asp:Label runat="server" ID="txtCountNum"></asp:Label></div>
<div class="fui-heart xin"></div>
<div class="ui-btn zhan" onclick="dr.SupportMe('<%=openid %>','<%=toopenid %>')">支持我</div> 

<div><a href="DR_ResultList.aspx">查看总榜单</a></div>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hd_list.aspx.cs" Inherits="WebAPP.Adm.hd_list" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/select.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/jquery.idTabs.min.js"></script>
<script type="text/javascript" src="js/select-ui.min.js"></script>
<script type="text/javascript" src="editor/kindeditor.js"></script>
<style>

/*拍拍网风格*/
.paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 20px 10px 0; margin: 0px;}
.paginator a {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
.paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
.paginator .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}
.paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;}

/*淘宝风格*/
.paginator { font: 12px Arial, Helvetica, sans-serif;padding:10px 20px 10px 0; margin: 0px;}
.paginator a {border:solid 1px #ccc;color:#0063dc;cursor:pointer;text-decoration:none;}
.paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
.paginator .cpb {border:1px solid #F50;font-weight:700;color:#F50;background-color:#ffeee5;}
.paginator a:hover {border:solid 1px #F50;color:#f60;text-decoration:none;}
.paginator a,.paginator a:visited,.paginator .cpb,.paginator a:hover  
{ float:left;height:16px;line-height:16px;min-width:10px;_width:10px;margin-right:5px;text-align:center;
 white-space:nowrap;font-size:12px;font-family:Arial,SimSun;padding:0 3px;}


</style>

</head>
<form runat="server" id="form1">
    <body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">活动管理</a></li>
    <li><a href="#">活动列表</a></li>
    </ul>
    </div>
    
    <div class="formbody">
     	<div id="tab8" class="tabson">
    
    <table class="tablelist">
    	<thead>
    	<tr>
        <th>活动名称</th>
        <th>活动时间</th>
        <th>报名数</th>
        <th>剩余名额</th>
        <th>价格</th>
        <th>操作</th>
        </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="repList" runat="server">
            <ItemTemplate>
                <tr class="click">
                    <td><%# Eval("ProductName") %></td>
                    <td><%# Eval("HDTime")%></td>
                    <td><%# Eval("Quantity")%></td>
                    <td><%# Eval("InventoryNum")%></td>
                    <td><%# Eval("NewPrice")%></td>
                    <td><a href="hd_create.aspx?id=<%# Eval("ProductID") %>">编辑活动</a>&nbsp;<a href="hd_bm.aspx?id=<%# Eval("ProductID") %>">查看报名</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="6" align="center">
                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="" runat="server" 
                    onpagechanging="AspNetPager1_PageChanging">
                </webdiyer:AspNetPager>
            </td>
        </tr>
        </tbody>
    </table>
    </div>    
    </div>
<script>
    $("#AspNetPager1").find("span").each(function (idx) {
        $(this).replaceWith("<a style='" + $(this).attr("style") + "'>" + $(this).html() + "</a>")
    })
</script>
</body>
</form>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hd_bmlist.aspx.cs" Inherits="WebAPP.Adm.hd_bmlist" %>


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

<script type="text/javascript">
    $(document).ready(function () {
        $(".click").click(function () {
            $("#aaa").fadeIn(200);
        });

        $(".tiptop a").click(function () {
            $("#aaa").fadeOut(200);
        });

        $(".click1").click(function () {
            $("#bbb").fadeIn(200);
        });

        $("#bclose a").click(function () {
            $("#bbb").fadeOut(200);
        })



        //        $(".click1").click(function () {
        //            $(".tip1").fadeIn(200);
        //        });

        //        $(".tiptop1 a").click(function () {
        //            $(".tip1").fadeOut(200);
        //        });
    });
</script>
</head>

<body>

	<form id="form1" runat="server">

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">活动管理</a></li>
    <li><a href="#">报名表</a></li>
    </ul>
    </div>
    
    <div class="formbody">

    <div id="usual1" class="usual"> 

  	<div id="tab1" class="tabson">
    <ul class="seachform">
        <li><asp:Button ID="btn1" runat="server" Text="关闭活动1" onclick="btn1_Click" /> 
            <asp:Button ID="btn2" runat="server" Text="关闭活动2" onclick="btn2_Click" /> 
            <asp:Button ID="btn3" runat="server" Text="关闭活动3" onclick="btn3_Click" /></li>
    </ul>
    
    <table class="tablelist" cellpadding="2" cellspacing="2">
    	<thead>
    	<tr>
        <th></th>
        <th>活动名称</th>
        <th>姓名</th>
        <th>性别</th>
        <th>电话</th>
        <th>报名日期</th>
        <th>参与人数</th>
        </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="repList" runat="server">
            <ItemTemplate>
         <%--       <tr class="click">--%>
                <tr>
                    <td align="center"><input name="" type="checkbox" value="" /></td>
                    <td><%# Eval("HDNAME") %></td>
                    <td><%# Eval("uname")%></td>
                    <td><%# Eval("usex")%></td>
                    <td><%# Eval("utel")%></td>
                    <td><%# Eval("createdate")%></td>
                    <td><%# Eval("personcount")%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="9" align="center">
                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="" runat="server" 
                    onpagechanging="AspNetPager1_PageChanging">
                </webdiyer:AspNetPager>
            </td>
        </tr>
        </tbody>
    </table>
    </div>        
	</div> 
        
    </div>

    </form>
</body>

<div class="tip" id="aaa">
    <div class="tiptop"><span>提示信息</span><a></a></div>
        
    <div class="tipinfo">
    <span><img src="images/ticon.png" /></span>
    <div class="tipright">
    <p>是否确认对该报修信息进行处理？</p>
    <cite>
    <select class="select3">
        <option>---请选择处理人---</option>
        <option>处理人A</option>
        <option>处理人B</option>
        <option>施工单位A</option>
        <option>施工单位B</option>
    </select>
    </cite>
    </div>
    </div>
    <div class="tipbtn">
    <input name="" type="button"  class="sure" value="确定" onclick='alert("报 修信息以转发相关人员进行处理");$(".tip").fadeOut(200);' />&nbsp;
    <input name="" type="button"  class="cancel" value="取消" onclick='$(".tip").fadeOut(200);' />
    </div>
</div>

<div class="tip" id="bbb">
    <div class="tiptop" id="bclose"><span>提示信息</span><a></a></div>
        
    <div class="tipinfo" style="height:150px">
    <span><img src="images/ticon.png" /></span>
    <div class="tipright">
<!--    <p>是否确认对该报修信息进行处理？</p>-->
    <cite>
    <select class="select3">
        <option>---请选择---</option>
        <option selected="selected">已处理</option>
        <option>未处理</option>
    </select>
    <p>
        <textarea rows="5" style="border:1px solid #e0e0e0" >健身器材损坏，现已修复！</textarea>
    </p>
    </cite>
    </div>
    </div>
    <div class="tipbtn">
    <input name="" type="button"  class="sure" value="确定" onclick='$(".tip").fadeOut(200);' />&nbsp;
    <input name="" type="button"  class="cancel" value="取消" onclick='$(".tip").fadeOut(200);' />
    </div>
</div>

<script>
    $("#AspNetPager1").find("span").each(function (idx) {
        $(this).replaceWith("<a style='" + $(this).attr("style") + "'>" + $(this).html() + "</a>")
    })
</script>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultInput.aspx.cs" Inherits="WebAPP.WebApp.DR.ResultInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript"  src="/js/jquery.js"></script>
    <script type="text/javascript"  src="/js/application.js"></script>
    <script type="text/javascript"  src="/js/flat-ui.min.js"></script>
    <script type="text/javascript"  src="/js/aply.js"></script>
    <script type="text/javascript" src="/ScriptsLib/Core/IsTech_core.js"></script>
    <script type="text/javascript" src="/ScriptsLib/Core/IsTech_form.js"></script>
    <script type="text/javascript" src="/webapp/dr/js/dr.js"></script>
    <script language="javascript">
        var str = "";
        document.writeln("<div id=\"_contents\" style=\"padding:6px; background-color:#E3E3E3; font-size: 12px; border: 1px solid #777777; position:absolute; left:?px; top:?px; width:?px; height:?px; z-index:1; visibility:hidden\">");
        str += "\u65f6<select id=\"_hour\">";
        for (h = 0; h <= 9; h++) {
            str += "<option value=\"0" + h + "\">0" + h + "</option>";
        }
        for (h = 10; h <= 23; h++) {
            str += "<option value=\"" + h + "\">" + h + "</option>";
        }
        str += "</select> \u5206<select id=\"_minute\">";
        for (m = 0; m <= 9; m++) {
            str += "<option value=\"0" + m + "\">0" + m + "</option>";
        }
        for (m = 10; m <= 59; m++) {
            str += "<option value=\"" + m + "\">" + m + "</option>";
        }
        str += "</select> \u79d2<select id=\"_second\">";
        for (s = 0; s <= 9; s++) {
            str += "<option value=\"0" + s + "\">0" + s + "</option>";
        }
        for (s = 10; s <= 59; s++) {
            str += "<option value=\"" + s + "\">" + s + "</option>";
        }
        str += "</select> <input name=\"queding\" type=\"button\" onclick=\"_select()\" value=\"\u786e\u5b9a\" style=\"font-size:12px\" /></div>";
        document.writeln(str);
        var _fieldname;
        function _SetTime(tt) {
            _fieldname = tt;
            var ttop = tt.offsetTop;    //TT控件的定位点高
            var thei = tt.clientHeight;    //TT控件本身的高
            var tleft = tt.offsetLeft;    //TT控件的定位点宽
            while (tt = tt.offsetParent) {
                ttop += tt.offsetTop;
                tleft += tt.offsetLeft;
            }


            $("#_contents").css("top", ttop + thei + 4 + "px");
            $("#_contents").css("left", tleft + "px");
            $("#_contents").css("visibility", "visible");
            var inv = $("#txtResult").val().split(":");
            $("#_hour").val(inv[0]);
            $("#_minute").val(inv[1]);
            $("#_second").val(inv[2]);
            //document.getElementById("_contents").style.top = ttop + thei + 4;
            //document.getElementById("_contents").style.left = tleft;
            //document.getElementById("_contents").style.visibility = "visible";
        }
        function _select() {
            _fieldname.value = document.getElementById("_hour").value + ":" + document.getElementById("_minute").value + ":" + document.getElementById("_second").value;
            document.getElementById("_contents").style.visibility = "hidden";
        }

</script>
</head>
<body>
    <form id="form1" runat="server">

    <div id="divLogin"><input type="text" id="password" /> <input type="button" value="login" onclick="dr.Login()"></div>

    <table cellpadding="0" cellspacing="0" id="logTab" style="display:none">
        <tr>
            <td>
                参赛序号 <input type="text" maxlength="4" onblur="dr.GetInput(this.value)" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> 
            </td>
        </tr>
        <tr>
            <td id="divinfo"></td>
        </tr>
    </table>
    </form>
</body>
</html>

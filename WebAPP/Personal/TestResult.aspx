<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestResult.aspx.cs" Inherits="WebAPP.Personal.TestResult" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />
    <title>4</title>
    <link rel="stylesheet" href="css/base.css"/>
    <link rel="stylesheet" href="css/style.css">
    <script src="js/jquery-1.8.0.js"></script>
    <script src="js/js.js"></script>
</head>
<body>

<header>
    结论报告
</header>

<section class="top por">
    <img runat="server" id="imgheader" alt="" class="img"/>
    <div class="txt hz-hid">
        <p>身体年龄为<asp:Label runat="server" ID="lblstAge"></asp:Label>岁 超过了<asp:Label runat="server" ID="lblstAgeP"></asp:Label>同龄人</p>
        <p>预计寿命<asp:Label runat="server" ID="lblyjAge"></asp:Label>岁 超过了<asp:Label runat="server" ID="lblyjAgeP"></asp:Label>（大连）人</p>
    </div>
    <div class="topbottom">
        <span class="dib fl"><asp:Label runat="server" ID="lblName"></asp:Label></span>
        <a href="">我也测试</a>
    </div>
</section>


<section class="chu-1 hz-hid">
    <section class="t-0 t-1">1、BMI</section>
    <div class="p hz-hid">
        <asp:Label ID="lblBMI" runat="server"></asp:Label>
    </div>
    <section class="t-0 t-1">2、WHR</section>
    <div class="p hz-hid">
        <asp:Label ID="lblWHR" runat="server"></asp:Label>
    </div>
    <section class="t-0 t-1">3、心率水平</section>
    <div class="p hz-hid">
        <asp:Label ID="lblXL" runat="server"></asp:Label>
    </div>

    <section class="t-0 t-1">4、心肺功能水平</section>
    <div class="p hz-hid">
        <asp:Label ID="lblBQSY" runat="server"></asp:Label>
    </div>

    <section class="t-0 t-1">5、身体平衡能力水平</section>
    <div class="p hz-hid">
        <asp:Label ID="lblPHNL" runat="server"></asp:Label>
    </div>

    <section class="t-0 t-1">6、吸烟指数</section>
    <div class="p hz-hid">
        <asp:Label ID="lblXYZS" runat="server"></asp:Label>
    </div>

    <section class="t-0 t-1">7、运动习惯对健康的影响</section>
    <div class="p hz-hid">
        <asp:Label runat="server" ID="lblYDXG"></asp:Label>
    </div>

    <section class="t-0 t-1">8、亚健康指数</section>
    <div class="p hz-hid">
        <asp:Label runat="server" ID="lblYJKZZ"></asp:Label>
    </div>
</section>

<section class="c-0">以上8条结论的测试方法适用于大多数健康的成年人</section>

<section class="project hz-hid">
    <p>个性化解决方案</p>
    <p>运动处方是指针对个人的身体状况，采用处方的形式规定健身者锻炼的内容和运动量，有目的、有计划和科学地锻炼的一种方法。运动处方的开具遵循ACSM的FITT-VP原则即：强度、频率、时间、方法、运动量和进度。ACSM（美国运动医学学会）是被世界公认在运动医学、体适能训练、运动损伤与康复、特殊人群训练、健康关爱等领域中的行业权威。ACSM传授的是最权威、最专业的运动科学知识，它是健康运动乃至体育产业中运动科学的航向标。我们根据运动处方的方法论，对大多数健康成年人制定可以促进体适能和健康的个性化有氧运动处方。</p>
    <p>个性化解决方案</p>
</section>

<a href="ChooseSport.aspx" class="zhidao-btn">健康指导</a>

</body>
</html>
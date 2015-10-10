<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DR_ResultList.aspx.cs" Inherits="WebAPP.WebApp.DR.DR_ResultList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>东软平板支撑比赛-成绩榜</title>
    <link rel="stylesheet" href="/css/list.css"/>
    <link rel="stylesheet" href="/css/listStyle.css"/>
    <link rel="stylesheet" href="/css/flat-ui.css"/>
    <link rel="stylesheet" href="/css/bootstrap.css"/>
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/application.js"></script>
    <script type="text/javascript" src="/js/flat-ui.min.js"></script>
    <script type="text/javascript" src="/js/aply.js"></script>
    <script type="text/javascript" src="/ScriptsLib/Core/IsTech_core.js"></script>
    <script type="text/javascript" src="/ScriptsLib/Core/IsTech_form.js"></script>
    <script type="text/javascript" src="/webapp/dr/js/dr.js"></script>
    <style>
        .more-link-wrap {height:40px; *margin-top:20px; _margin-top:0; margin:0 auto; display:none; _position:relative }
        .more-link-wrap .more-link { background: repeat-x; position:relative; display:inline-block; width:100%; height:38px; line-height:38px; text-align:center; cursor:pointer; text-decoration:none; border:1px solid #e5e5e5; background-position:0 0; color:#999; font-weight:bold; vertical-align:middle; zoom:1; background:url("/img/more_links.png") top left repeat-x;}
        .more-link-wrap .more-link span { vertical-align:middle; zoom:1 }
        .more-link-wrap .more-link .ie6-vertical { font-size:0 }
        .more-link-wrap .more-link .arrow-tip{ display:inline-block; width:9px; height:6px; margin-left:10px; background:url("/img/arrow_down.png") no-repeat }
        .more-link-wrap .more-link:hover { text-decoration:none; text-shadow:0 1px 0 #fff; color:#333; background-position:0 -48px; }
        .more-link-wrap .more-link:hover .arrow-tip { background:url("/img/arrow_down_hover.png") no-repeat }
    </style>
    <script type="text/javascript">
        var TotalPage1 = 0;
        var CurrentPage1 = 0;
        var TotalPage2 = 0;
        var CurrentPage2 = 0;
    </script>
</head>
<body style="background: #fff!important;">
<div class="mune">
    <div class="titleBang resultBtn">
        成绩榜
    </div>
    <div class="titleBang renqiBtn renqi">
        人气榜
    </div>
</div>
<!--成绩榜-->
<div class="resultLIstBox">
    <div class="input-group">
        <input class="form-control" id="strKey1" type="search" placeholder="按序号或姓名查找" />
    <span class="input-group-btn">
        <button type="button" class="btn" style="height:34px" onclick="dr.LoadData(1)"><span class="fui-search"></span></button>
    </span>
    </div>
    <ul class="listBox listTop">
        <li class="list">名次</li>
        <li class="list">姓名</li>
        <li class="list">成绩</li>
        <li class="list">院系</li>
    </ul>
    <ss id="list1">
        <ul class="listBox">
            <li class="list">3</li>
            <li class="list">赵六</li>
            <li class="list listSecond">00.00.00</li>
            <li class="list">经管系</li>
        </ul>
    </ss>
    <div class="more-link-wrap" style="display: block;" id="btnMore1">
        <a href="javascript:void(null)" class="more-link" onclick="dr.More()">
            <span class="more-tip" id="MoreTip">加载更多</span>
            <span class="ie6-vertical arrow-tip" id="ArrowTip"></span>
        </a>
    </div>
</div>
<!--人气榜-->
<div class="hightList">
    <div class="input-group">
        <input class="form-control"  id="strKey2" type="search" placeholder="按序号或姓名查找">
    <span class="input-group-btn">
        <button type="button" class="btn" style="height:34px"  onclick="dr.LoadData1(1)"><span class="fui-search"></span></button>
    </span>
    </div>
    <ul class="listBox listTop renqiTop">
        <li class="listR">人气值</li>
        <li class="listR">名次</li>
        <li class="listR">姓名</li>
        <li class="listR">系别</li>

    </ul>
    <ss id="list2">
    <ul class="listBox">
        <li class="listR">53</li>
        <li class="listR">3</li>
        <li class="listR">赵六</li>
        <li class="listR">体育系</li>
    </ul>
    </ss>
    <div class="more-link-wrap" style="display: block;" id="btnMore2">
        <a href="javascript:void(null)" class="more-link" onclick="dr.More1()">
            <span class="more-tip" id="Span1">加载更多</span>
            <span class="ie6-vertical arrow-tip" id="Span2"></span>
        </a>
    </div>
</div>
<script>
    dr.LoadData(1);
    dr.LoadData1(1);
</script>
</body>
</html>
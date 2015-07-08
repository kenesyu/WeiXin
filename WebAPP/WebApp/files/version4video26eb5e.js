define("pages/version4video.js",["biz_common/dom/event.js","biz_wap/jsapi/core.js","biz_wap/utils/device.js"],function(i){
"use strict";
function e(){
return document.domain="qq.com",p.canSupportVideo?top.window.__appmsgCgiData.can_use_page&&(_.is_ios||_.is_android)?!0:_.is_ios&&top.window.user_uin&&top.window.user_uin%104759%10==1?!0:!1:!1;
}
function o(){
return top.window.__appmsgCgiData.can_use_page&&(_.is_ios||_.is_android&&_.is_x5)&&_.inWechat?!0:!1;
}
function n(){
return!0;
}
function t(){
return d.music_support;
}
function s(){
return d.networkType;
}
var r=i("biz_common/dom/event.js"),a=i("biz_wap/jsapi/core.js"),p=i("biz_wap/utils/device.js"),d={
music_support:"addEventListener"in window,
networkType:""
},_={};
return function(i){
var e=p.os;
_.is_ios=!!e.ios,_.is_android=!!e.android,_.is_wp=!!e.phone,_.is_pc=!(e.phone||!e.Mac&&!e.windows),
_.inWechat=/MicroMessenger/.test(i),_.is_android_phone=_.is_android&&/Mobile/i.test(i),
_.is_android_tablet=_.is_android&&!/Mobile/i.test(i),_.ipad=/iPad/i.test(i),_.iphone=!_.ipad&&/(iphone)\sos\s([\d_]+)/i.test(i),
_.is_x5=/TBS\//.test(i)&&/MQQBrowser/i.test(i),r.on(window,"load",function(){
if(""==d.networkType&&_.inWechat){
var i={
"network_type:fail":"fail",
"network_type:edge":"2g/3g",
"network_type:wwan":"2g/3g",
"network_type:wifi":"wifi"
};
a.invoke("getNetworkType",{},function(e){
d.networkType=i[e.err_msg]||"fail";
});
}
},!1);
}(window.navigator.userAgent),{
device:_,
isShowMpVideo:e,
isShowMpMusic:n,
isUseProxy:o,
isSupportMusic:t,
getNetworkType:s
};
});
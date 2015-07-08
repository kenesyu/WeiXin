!function(){
var e={},t={},o={};
e.COMBO_UNLOAD=0,e.COMBO_LOADING=1,e.COMBO_LOADED=2;
var n=function(e,o,n){
if(!t[e]){
t[e]=n;
for(var r=3;r--;)try{
moon.setItem(moon.prefix+e,n.toString()),moon.setItem(moon.prefix+e+"_ver",moon_map[e]);
break;
}catch(a){
moon.clear();
}
}
},r=function(e){
if(!e||!t[e])return null;
var n=t[e];
return"function"!=typeof n||o[e]||(n=t[e]=n(r),o[e]=!0),n;
};
e.combo_status=e.COMBO_UNLOAD,e.run=function(){
var t=e.run.info,o=t&&t[0],n=t&&t[1];
if(o&&e.combo_status==e.COMBO_LOADED){
var a=r(o);
n&&n(a);
}
},e.use=function(t,o){
e.run.info=[t,o],e.run();
},window.define=n,window.seajs=e;
}(),function(e){
function t(e,t,n){
if("object"==typeof e){
var r=Object.prototype.toString.call(e).replace(/^\[object (.+)\]$/,"$1");
if(n=n||e,"Array"==r){
for(var a=0,i=e.length;i>a;++a)if(t.call(n,e[a],a,e)===!1)return;
}else{
if("Object"!==r&&o!=e)throw"unsupport type";
if(o==e){
for(var a=e.length-1;a>=0;a--){
var c=o.key(a),s=o.getItem(c);
if(t.call(n,s,c,e)===!1)return;
}
return;
}
for(var a in e)if(e.hasOwnProperty(a)&&t.call(n,e[a],a,e)===!1)return;
}
}
}
var o=e.localStorage,n=document.head||document.getElementsByTagName("head")[0],r={
prefix:"__MOON__",
loaded:[],
unload:[],
hit_num:0,
mod_num:0,
init:function(){
r.loaded=[],r.unload=[];
var n,a,i;
if(-1!=location.search.indexOf("no_moon=1")&&r.clear(),o){
var c=1*o.getItem(r.prefix+"clean_time"),s=+new Date;
if(s-c>=1296e6){
r.clear();
try{
!!o&&o.setItem(r.prefix+"clean_time",+new Date);
}catch(u){}
}
}
t(moon_map,function(t,c){
if(a=r.prefix+c,i=!!t&&t.replace(/^http(s)?:\/\/res.wx.qq.com/,""),n=!!o&&o.getItem(a),
version=!!o&&(o.getItem(a+"_ver")||"").replace(/^http(s)?:\/\/res.wx.qq.com/,""),
r.mod_num++,n&&i==version)try{
var s="//# sourceURL="+c+"\n//@ sourceURL="+c;
e.eval.call(e,'define("'+c+'",[],'+n+")"+s),r.hit_num++;
}catch(u){
r.unload.push(i.replace(/^http(s)?:\/\/res.wx.qq.com/,""));
}else r.unload.push(i.replace(/^http(s)?:\/\/res.wx.qq.com/,""));
}),r.load(r.genUrl());
},
genUrl:function(){
var e=r.unload;
if(!e||e.length<=0)return[];
for(var t,o,n="",a=[],i={},c=-1!=location.search.indexOf("no_moon=2"),s=0,u=e.length;u>s;++s)/^\/(.*?)\//.test(e[s]),
RegExp.$1&&(o=RegExp.$1,n=i[o],n?(t=n+","+e[s],t.length>1024||c?(a.push(n),n=location.protocol+"//res.wx.qq.com"+e[s],
i[o]=n):(n=t,i[o]=n)):(n=location.protocol+"//res.wx.qq.com"+e[s],i[o]=n));
for(var l in i)i.hasOwnProperty(l)&&a.push(i[l]);
return a;
},
load:function(e){
if(!e||e.length<=0)return seajs.combo_status=seajs.COMBO_LOADED,void seajs.run();
seajs.combo_status=seajs.COMBO_LOADING;
var o=0;
t(e,function(t){
var r=document.createElement("script");
r.src=t,r.type="text/javascript",r.async=!0,"undefined"!=typeof moon_crossorigin&&moon_crossorigin&&r.setAttribute("crossorigin",!0),
r.onload=r.onreadystatechange=function(){
!r||r.readyState&&!/loaded|complete/.test(r.readyState)||(o++,r.onload=r.onreadystatechange=null,
o==e.length&&(seajs.combo_status=seajs.COMBO_LOADED,seajs.run()));
},n.appendChild(r);
});
},
setItem:function(e,t){
!!o&&o.setItem(e,t);
},
clear:function(){
o&&t(o,function(e,t){
~t.indexOf(r.prefix)&&o.removeItem(t);
});
}
};
window.moon=r;
}(window),window.moon.init();
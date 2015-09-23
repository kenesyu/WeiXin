$(function(){
    var aply=$(".aply");
    var flag=true;
    var tanBox=$(".tanBox");
    var link=$(".link");
    var close=$(".break");
    var innerBox=$(".innerBox");
    aply.click(function(){
        if(flag){
            tanBox.css({display:"block"});
            innerBox.css({display:"block"});
            flag=false;
        }else{

        }
    });
    close.click(function(){
        tanBox.css({display:"none"});
        innerBox.css({display:"none"});
        link.attr('href','http://baidu.com');
    });
    /**************************/
    var resultLIstBox=$(".resultLIstBox");
    var hightList=$(".hightList");
    var resultBtn=$(".resultBtn");
    var renqiBtn=$(".renqiBtn");
    resultBtn.click(function(){
        resultBtn.css({background:"#269abc",color:"#fff"});
        renqiBtn.css({background:"#fff",color:"#000",borderBottom:"1px solid #269abc"});
        resultLIstBox.css({display:"block"});
        hightList.css({display:"none"});
    });
    renqiBtn.click(function(){
        renqiBtn.css({background:"#269abc",color:"#fff"});
        resultBtn.css({background:"#fff",color:"#000",borderBottom:"1px solid #269abc"});
        resultLIstBox.css({display:"none"});
        hightList.css({display:"block"});
    });
    var zhan=$(".zhan");
    var xin=$(".xin");
    zhan.click(function(){

        xin.css({color:"#FF4141"});
    })
});
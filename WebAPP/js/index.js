
$(function(argument) {
    $('[type="checkbox"]').bootstrapSwitch();

    $(".position-r").hover(function(index){
        var num= $(".position-r").index(this);
        $($(".detail")[num]).stop();
        $($(".detail")[num]).animate({height:100})
    },function(){
        /*   $(this).stop();*/
        var num= $(".position-r").index(this);
        $($(".detail")[num]).stop();
        $($(".detail")[num]).animate({height:0})
    })
/******************************/
    /*banner*/
        var pics=$(".introo");
        var num=0;
        setInterval(function(){
            num++;
            if(num==pics.length){
                num=0;
            }
            for(var i=0;i<pics.length;i++){
                $(pics[i]).css({display:"none"})

            }
            $(pics[num]).css({display:"block"})

        },3000)

    /********/
    $(".menu").hover(function(){
        $(this).css({color:"fff"})
    },function(){
        $(this).css({color:"000!important"})
    })
    /*活动*/
    $(".active-detail").hover(
        function(index){

            var aa= $(".active-detail").index(this);
            $($(".active-d")[aa]).finish();
            $($(".active-d")[aa]).animate({left:0})
        },
        function(index){

            var aa= $(".active-detail").index(this);
            $($(".active-d")[aa]).stop();
            $($(".active-d")[aa]).animate({left:"-100%"})
        }
    )
/*找工作*/
    $(".offer-middle ul li").click(function(){
        var num= $(".offer-middle ul li").index(this);
       // alert(num)
        $(".offer-box").animate({top:450})
        $($(".offer-box")[num]).animate({top:0})
    })
/*找工作*/
    $(".offer-middle ul li").hover(
        function(index){
            var num= $(".offer-middle ul li").index(this);
            $($(".offer-middle ul li span")[num]).css({color:"#fff"});
        },
        function(index){
            var num= $(".offer-middle ul li").index(this);
            $($(".offer-middle ul li span")[num]).css({color:""});
        }
    )
    /*楼层跳转*/
    var list=$(".menu");
    var scrollT=$(window).scrollTop();
    var floorAll=$('.floor');
    for(var i=0;i<floorAll.length;i++) {
        floorAll[i].aaa = $(floorAll[i]).position().top;
    }
    list.click(function(index){
        $('html,body').animate({scrollTop:floorAll[list.index(this)].aaa});
        var qqq= $(".nav .menu").index(this);
        $(".nav .menu").css({background:""});
        $($(".nav .menu")[qqq]).css({background:"#01A89E"});
    });

    /*goback*/
    $(window).scroll(function(){
            for(var i=0;i<floorAll.length;i++) {
               // var floorTop= $(floorAll[i]).position().top;
                if($(window).scrollTop()>= $(floorAll[i]).position().top){
                  list.css({background:""})
                  $(list[i]).css({background:"#01A89E"})
            }
        }
        if($(window).scrollTop()>600){
            $(window).stop();
            $(".goback").animate({height:50},200);
        }
        if($(window).scrollTop()<600){
            $(window).stop();
            $(".goback").animate({height:0},200) ;
        }
    })

    $(".goback").click(function(){
        $('html,body').animate({scrollTop:0});
    })
})

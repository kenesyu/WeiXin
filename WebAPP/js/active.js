$(function(){
    var sw=document.documentElement.clientWidth;
    var activeMore=$(".activeMore");
    var activeNone=$(".active-card-none");
    var block=$(".active-card-block");
    var flag=true;
    block.click(
        function(index){
            var num=$(block).index(this);
            if(flag){
                $($(activeMore)[num]).css({transform:"rotate(180deg)",transition:"all 0.2s ease"});
                if(sw<375){
                    $($(".active-card-none")[num]).animate({height:281});
                }else{
                    $($(".active-card-none")[num]).animate({height:250});
                }
                flag=false;
            }else{
                $($(activeMore)[num]).css({transform:"rotate(0deg)",transition:"all 0.2s ease"});
                $($(".active-card-none")[num]).animate({height:0});
                flag=true;
            }
        });
    var suo=true;
    $(".newActivity").click(function(){
        if(suo){
            $(this).animate({right:0});
            suo=false;
        }else{
            $(this).animate({right:-85});
            suo=true;
        }
    });

})
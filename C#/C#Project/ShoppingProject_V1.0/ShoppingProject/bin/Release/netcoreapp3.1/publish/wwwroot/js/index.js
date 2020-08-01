
//Login Page import js file

$(() => {

    $(".Classtext").mouseenter(()=> {
        $(".CommodityClass").css("display", "block");
    });
    $(".CommodityClass").mouseleave(() => {
        //$(".CommodityClass").css("display", "none");
        $(".CommodityClass").slideUp(200);
    });
   
});

//标签显示事件
function navtabsshow(e,index) {
    $(".nav-link").removeClass("active");
    $(".navall").css("display","none");
    $(e).addClass("active");
    $(".nav"+index).css("display", "block");
}
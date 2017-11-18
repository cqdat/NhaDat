﻿
$(document).ready(function () {
    $('.carousel').carousel({
        interval: 5000
    });

    $("ul.dropdown li").hover(function () {

        $(this).addClass("hover");
        $('ul:first', this).css('visibility', 'visible');

    }, function () {

        $(this).removeClass("hover");
        $('ul:first', this).css('visibility', 'hidden');

    });

    $("ul.dropdown li ul li:has(ul)").find("a:first").append(" &raquo; ");


    $("#btnlogin").click(function () {
        $(".loginbox").show();
    });

    $("#btnExit").click(function () {
        $(".loginbox").hide();
    });

    $(".dktv").click(function () {

        $(".boxregister").show();

    });

    $(".boxregister .close").click(function () {
        $(".boxregister").hide();
    });

    $(".loginbox .close").click(function () {
        $(".loginbox").hide();
    });

    $('.flexslider').flexslider({
        animation: "slide",
        controlNav: "thumbnails"
    });
    

});
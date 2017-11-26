
$(document).ready(function () {
    $('.carousel').carousel({
        interval: 5000
    });

    $(".captcha a").prop("href", "javascript:");

    $(".captcha br").remove();

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

    jQuery.validator.addMethod("alphanumeric", function (value, element) {
        return this.optional(element) || /^\w+$/i.test(value);
    }, "Không được có ký tự đặc biệt hoặc khoảng trắng");

     $.validator.addMethod("valueNotEquals", function (value, element, arg) {
        return arg !== value;
    }, "Value must not equal arg.");

     $.validator.addMethod('uniqueUsername', function (value) {
         $.ajax({
             url: 'http://localhost:8080/TBS-war/RegisterServlet.java',
             type: 'POST',
             async: false,
             contentType: 'application/json',
             dataType: 'json'

         });
     });

    $("#formreg").validate({
        rules: {
            txtUserName: {
                required: true,
                minlength: 5,
                maxlength: 20,
                alphanumeric: true,
                remote: {
                    url: "/Home/checkUsername",
                    type: "post",
                    data: {
                        txtUserName: function () {
                            return $("#txtUserName").val();
                        }
                    }
                }
            },
            txtPassword: {
                required: true,
                minlength: 5,
                maxlength: 15
            }
            ,
            txtConfirm: {
                required: true,
                equalTo: "#txtPassword"
            },
            txtFullName: {
                required: true,
                minlength: 5,
                maxlength: 30
            },
            txtMobile: {
                required: true,
                minlength: 10,
                maxlength: 11,
                number: true,
                remote: {
                    url: "/Home/checkMobile",
                    timeout: 2000,
                    type: "post"
                }
            },
            txtEmail: {
                required: true,
                minlength: 6,
                maxlength: 40,
                email: true,
                remote: {
                    url: "/Home/checkEmail",
                    timeout: 2000,
                    type: "post"
                }
            },
            slDistrict: {
                required: true,
                valueNotEquals: "default" 
            }
        },
        messages: {
            txtUserName: {
                required: "Tên người dùng không được để trống",
                minlength: "Vui lóng nhập hơn 5 ký tự",
                maxlength: "Vui lòng nhập nhỏ 20 ký tự",
                remote: "Tài khoản này đã được sử dụng"
            },
            txtPassword: {
                required: "Mật khẩu không được để trống",
                minlength: "Vui lóng nhập hơn 5 ký tự",
                maxlength: "Vui lòng nhập nhỏ 15 ký tự"
            }
            ,
            txtConfirm: {
                required: "Vui lòng xác nhập mật khẩu",
                equalTo: "Mật khẩu nhập lại không chính xác"
            },
            txtFullName: {
                required: "Vui lòng nhập họ & tên",
                minlength: "Họ & tên không chính xác",
                maxlength: "Họ & tên không chính xác"
            },
            txtMobile: {
                required: "Vui lòng nhập số điện thoại",
                minlength: "Số điện thoại không chính xác",
                maxlength: "Số điện thoại không chính xác",
                number: "Số điện thoại không chính xác",
            },
            txtEmail: {
                required: "Email không được để trống",
                minlength: "Email không chính xác",
                maxlength: "Email không chính xác",
                email: "Email không chính xác"
            },
            slDistrict: {
                required: "Vui lòng chọn nơi cư trú",
                valueNotEquals: "Vui lòng chọn nơi cư trú"
            }
        }
    });
    

});
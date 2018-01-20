
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#uploadimage1')
                .attr('src', e.target.result)
                .width(110)
                .height(110);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

$(document).ready(function () {

    setHeight();

    $("#uploadimage1").click(function () {
        $("#File1").click();
    });



    $('.carousel').carousel({
        interval: 5000
    });

    $('input:radio[name="hinhthuc"]').change(
        function () {
            if ($(this).is(':checked')) {

                $(".kieutin").css("background-color", "#fff");
                $(this).parent().css("background-color", "#efefef");
            }
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
        $("#full-opacity").show();
        $(".loginbox").show();
    });

    $("#btnExit").click(function () {

        $(".loginbox").hide();
        $("#full-opacity").hide();
    });

    $(".dktv").click(function () {

        $(".boxregister").show();

        $("#full-opacity").show();

    });

    $(".boxregister .close").click(function () {
        $(".boxregister").hide();
        $("#full-opacity").hide();
    });

    $(".loginbox .close").click(function () {
        $(".loginbox").hide();
        $("#full-opacity").hide();
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

     $("#formnewthread").validate({
         rules: {
             tieude: {
                 required: true,
                 minlength: 10,
                 maxlength: 200
             },
             noidung: {
                 required: true,
                 minlength: 20
             },
             slLoaitin: {
                 required: true,
                 valueNotEquals: "default"
             },
             slLoaiBDS: {
                 required: true,
                 valueNotEquals: "default"
             },
             txtDiachi: {
                 required: true
             },
             slDuongPho: {
                 required: true,
                 valueNotEquals: "default"
             },
             slDuAn: {
                 required: true,
                 valueNotEquals: "default"
             },
             txtDientich: {
                 required: true
             },
             txtGia: {
                 required: true
             },
             CaptchaInputText: {
                 required: true
             }
         },
         messages: {
             tieude:
             {
                 required: "Nhập tiêu đề khi đăng tin",
                 minlength: "Tiêu đề phải có ít nhất 10 ký tự",
                 maxlength: "Tiêu đề tối đa chỉ 200 ký tự"
             },
             noidung: {
                 required: "Phải có nội dung khi đăng tin",
                 minlength: "Nội dung phải có ít nhất 20 ký tự"
             }
             ,
             slLoaitin: {
                 required: "Chọn loại tin",
                 valueNotEquals: "Chọn loại tin"
             },
             slLoaiBDS: {
                 required: "Chọn loại bất động sản",
                 valueNotEquals: "Chọn loại bất động sản"
             },
             txtDiachi: {
                 required: "Vui lòng nhập địa chỉ"
             },
             slDuongPho: {
                 required: "Vui lòng chọn đường phố",
                 valueNotEquals: "Vui lòng chọn đường phố"
             },
             slDuAn: {
                 required: "Vui lòng chọn dự án",
                 valueNotEquals: "Vui lòng chọn dự án"
             },
             txtDientich: {
                 required: "Vui lòng chọn diện tích"
             },
             txtGia: {
                 required: "Vui lòng nhập giá"
             },
             CaptchaInputText: {
                 required: "Nhập mã bảo mật"
             }
             
         }
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


    $(document).on("change", "#slQuanHuyen", function () {
        var quanhuyenid = $("#slQuanHuyen option:selected").val(); 

        $.ajax({
            url: '/Home/getPhuongXa',
            contentType: 'application/html; charset=utf-8',
            data: { quanhuyenid: quanhuyenid },
            type: 'GET',
            dataType: 'json'
            , success: function (data) {
                    $.each(data, function (id, dt) {
                        $('#slPhuongXa').append("<option value=" + dt.IDPhuongXa + ">" + dt.NamePhuongXa + "</option>");
                    });
            },
            error: function (xhr, status) {
                alert(status);
            }
        });

    });

    $(document).on("change", "#slPhuongXa", function () {
        var phuongxaid = $("#slPhuongXa option:selected").val();

        $.ajax({
            url: '/Home/getDuongPho',
            contentType: 'application/html; charset=utf-8',
            data: { phuongxaid: phuongxaid },
            type: 'GET',
            dataType: 'json'
            , success: function (data) {
                $.each(data, function (id, dt) {
                    $('#slDuongPho').append("<option value=" + dt.IDDuongPho + ">" + dt.NameDuongPho + "</option>");
                });
            },
            error: function (xhr, status) {
                alert(status);
            }
        });

    });
    

});

function setHeight() {
    windowHeight = $('body').height() + 70;
    //alert(windowHeight);
    $('#full-opacity').css('min-height', windowHeight);

    //$('.noscript').css('min-height', windowHeight);

    //$('.checkbrowser').css('min-height', windowHeight);
};
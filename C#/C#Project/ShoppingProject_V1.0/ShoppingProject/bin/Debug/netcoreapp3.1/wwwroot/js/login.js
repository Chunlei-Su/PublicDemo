
//Login Page import js file

$(() => {

    //添加检查密码格式的自定义规则
    jQuery.validator.addMethod("CheckPwd", function (value, element) {
        var pwd = /^\w+$/;
        return pwd.test(value);
    }, "密码格式为数字字母或下划线");

    //检查登录号
    jQuery.validator.addMethod("CheckNumber", function (value, element) {
        var pwd = /^C[0-9]{9}$/;
        return pwd.test(value);
    }, "帐号格式为C[大写]开头(不包含C)的9位数字");

    $('#loginform').validate({
        //设置验证失败时存放错误提示的标签
        errorElement: 'span',
        //设置标签用到的样式
        errorClass: 'invalid-feedback',
        //设置验证用的规则
        rules: {
            custnumber: {
                required: true,
                CheckNumber:true
            },
            custpwd: {
                required: true,
                minlength: 10,
                CheckPwd: true
            }
        },
        //设置验证失败的错误提示
        messages: {
            custnumber: {
                required: "此项必填",
                minlength: "密码长度固定为10位"
            },
            custpwd: {
                required: "此项必填",
                minlength: "密码长度固定为10位"
            }
        },
        //验证失败触发的事件
        errorPlacement: function (error, element) {
            element.next().remove(); //删除显示图标
            element.after(
                '<span class="glyphicon form-control-feedback invalid-feedback" aria-hidden="true"></span>'
            );
            element.parent().append(error);
        },
        //设置高亮显示的事件
        highlight: function (element) {
            $(element)
                .closest('.form-group')
                .find('input')
                .addClass('is-invalid');
        },
        //验证成功的事件
        success: function (label) {
            var el = label.closest('.form-group').find('input');
            el.next().remove(); //与errorPlacement相似
            el.after('<span class="glyphicon form-control-feedback valid-feedback" aria-hidden="true"></span>');
            el.removeClass('is-invalid').addClass('is-valid');
        }
    });
});

//点击记密码链接弹出丢失码重改密码
function ShowLostPwdKeyText() {
    if ($("#lostpwdaction").text() === "取消") {
        $("#custlostkey").val("");
        $("#lostpwd").css("display", "none");
        $("#loginnote").text("在此登录");
        $("#loginpwd").attr("placeholder", "密码");
        $("#lostpwdaction").text("忘记密码");
        return;
    }
    $("#lostpwd").css("display", "block");
    $("#loginnote").text("凭丢失码可以直接使用新密码登录");
    $("#loginpwd").attr("placeholder", "新密码");
    $("#lostpwdaction").text("取消");
}

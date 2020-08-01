
//Register Page import js file


$(() => {

    //添加检查密码格式的自定义规则
    jQuery.validator.addMethod("CheckPwd", function (value, element) {
        var pwd = /^\w+$/;
        return pwd.test(value);
    }, "密码格式为数字字母或下划线");

    //检查电话号码格式
    jQuery.validator.addMethod("CheckTel", function (value, element) {
        var mobile = /^[1][3,4,5,7,8][0-9]{9}$/;
        return mobile.test(value);
    }, "您的号码格式有误");

    //检查昵称是否重复
    jQuery.validator.addMethod("CheckName",
        function (value, element) {
            //为了避免每输入一个字符就执行一次数据库检查名称请求，在此获取这个元素的焦点状态
            var isFocus = $("#" + element.id).is(":focus");
            var boo = false;
            //只有当该元素失去焦点的时候才会执行检查请求
            if (!isFocus) {
                $.ajax({
                    url: "/Home/CheckCustomerName",
                    type: "POST",
                    async: false,
                    dataType: "json",
                    data: { CustName: value },
                    success: function (data) {
                        if (data === true) {
                            boo = false;
                            return;
                        }
                        boo = true;
                    }
                });
                return boo;
            } else {
                return true;
            }
        }, "昵称已被使用"
    );

    $('#custRegisterForm').validate({
        //设置验证失败时存放错误提示的标签
        errorElement: 'span',
        //设置标签用到的样式
        errorClass: 'invalid-feedback',
        //设置验证用的规则
        rules: {
            CustomerName: {
                required: true,
                CheckName: true
            },
            CustomerPassword: {
                required: true,
                minlength: 10,
                CheckPwd: true
            },
            CustomerTel: {
                required: true,
                CheckTel: true,
                minlength: 11
            },
            LostPasswordKey: {
                required: true,
                minlength: 10,
                CheckPwd: true
            }
        },
        //设置验证失败的错误提示
        messages: {
            CustomerName: {
                required: "此项必填"
            },
            CustomerPassword: {
                required: "此项必填",
                minlength: "密码长度固定为10位"
            },
            CustomerTel: {
                required: "此项必填",
                minlength: "电话长度固定为11位"

            },
            LostPasswordKey: {
                required: "此项必填",
                minlength: "丢失码长度固定为10位",
                CheckPwd: "丢失码为数字字母或者下划线"
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

//用户点击注册按钮以后，先检查一下,然后执行注册，完成后提示是否跳转到login页面
function customerRegister() {

    if ($('#custRegisterForm').valid()) {
        $.post("/Home/ToRegister",
            {
                CustomerName: $("#CustomerName").val(),
                CustomerPassword: $("#CustomerPassword").val(),
                CustomerTel: $("#CustomerTel").val(),
                LostPasswordKey: $("#LostPasswordKey").val()
            },
            function (data) {
                if (data.stats) {
                    window.location.href = "/Home/RegisterSuccess?CustName=" + $("#CustomerName").val() + "&Number=" + data.number;
                } else {
                    alert("注册时出现问题，请重试或稍后注册");
                }
            });
        return false;
    } else {
        return false;
    }
}


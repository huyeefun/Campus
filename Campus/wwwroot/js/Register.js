$(function () {
    $("#subBtn").click(function () {
        var userName = $("#userName").val();
        var password = $("#password").val();
        var isTeacher = $("#isTeacher").is(":checked");
        $.post("/User/Register", { userName: userName, password: password, isTeacher: isTeacher }, function (data) {
            if (data.isSucceed) {
                $('#myModal').modal();
            }
        }).fail(function (xhr, state, error) {
            if (xhr.status == 400) {
                $("#errordiv").html(xhr.responseText);
            }
        });
    });
    $("#userName").blur(function () {
        var username = $(this).val();
        if (username.length < 2) {
            $("#promptUna").text("用户名不能小于两个字！").css("color", "red");
        }
        else if (username.length > 20) {
            $("#promptUna").text("用户名不能大于二十个字！").css("color", "red");
        }
        else {
            $.getJSON("/User/ExistUserName?userName=" + username, null, function (data) {
                if (data.result) {
                    $("#promptUna").text("用户名已经存在！").css("color", "red");
                }
                else {
                    $("#promptUna").text("用户名可用！").css("color", "green");
                }
            });
        }
    });
    $("#password").blur(function () {
        var password = $(this).val();
        if (password.length < 8) {
            $("#promptPwd").text("密码不能小于8个字符！").css("color", "red");
        }
        else if (password.length > 20) {
            $("#promptPwd").text("密码不能大于20个字符！").css("color", "red");
        }
        else {
            $("#promptPwd").text("密码可用！").css("color", "green");
        }
    });
});
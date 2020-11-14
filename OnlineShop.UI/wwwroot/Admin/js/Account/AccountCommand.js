function RequiredFieldSubmit(inputArray) {

    let isValid = true;
    for (var element of inputArray) {

        var inputValue = document.getElementById(element);

        if (!inputValue.value) {
            $(`#${inputValue.id}`).parent("div").parent("div").parent("div").addClass("has-error");
            $(`#span-${inputValue.id}`).text("وارد کردن این فیلد اجباری است");
            isValid = false;
        }
    }
    return isValid;
};

function ComparePasswordSubmit(input) {
    var inputValue = document.getElementById("password");
    var value = document.getElementById(input);
    let isValid = true;
    if (value.value !== inputValue.value) {
        if ($(`#${input.id}`).parent("div").parent("div").parent("div").hasClass("has-success")) {
            $(`#${input.id}`).parent("div").parent("div").parent("div").removeClass("has-success");
        }
        $(`#${input.id}`)
            .parent("div")
            .parent("div").parent("div")
            .addClass("has-error");
        $(`#span-${input.id}`).text(`پسورد ها مشابه یکدیگر نمی باشند`);
        isValid = false;
    } else {
        if ($(`#${input.id}`).parent("div").parent("div").parent("div").hasClass("has-error")) {
            $(`#${input.id}`).parent("div").parent("div").parent("div").removeClass("has-error");
            $(`#span-${input.id}`).text(``);
        }
        $(`#${input.id}`)
            .parent("div")
            .parent("div").parent("div")
            .addClass("has-success");
    }

    return isValid;
}


$("#changePasswordForm").on("submit",
    function (e) {
        var array = $(this).serializeArray();

        e.preventDefault();

        if (!RequiredFieldSubmit(["oldPassword", "password", "confirmPassword"])) {
            return;
        }

        if (!ComparePasswordSubmit("confirmPassword")) {
            return;
        }

        var passwordObject = JSON.stringify({
            OldPassword: array[0].value,
            NewPassword: array[1].value
        });

        $.ajax({
            url: "/AdminApi/user/changePassword/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: passwordObject
        }).done(data => {

            $("#changePasswordForm")[0].reset();
            $.toast({
                heading: 'پسورد با موفیقت ویرایش یافت',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 3500,
                stack: 6
            });

        }).fail(err => {
            $.toast({
                heading: 'خطا',
                text: !err.responseJSON ? "در ارسال پیام شما مشکلی به وجود آمده است." : err.responseJSON.message,
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500,
            });
        });

    });
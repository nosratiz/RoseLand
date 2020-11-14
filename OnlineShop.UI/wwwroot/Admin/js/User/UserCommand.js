
function ValidPhoneNumberSubmit(input) {
    let isValid = true;
    var inputValue = document.getElementById(input);
    var regex = /^[0-9]*$/;
    if ((inputValue.value.length !== 11 || !regex.test(inputValue.value))) {
        if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
            $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
        }

        $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
        $(`#span-${input.id}`).text(` شماره همراه معتبر نمی باشد`);
        isValid = false;
    }

    return isValid;
}

function RequiredFieldSubmit(inputArray) {

    let isValid = true;
    for (var element of inputArray) {

        var inputValue = document.getElementById(element);

        if (!inputValue.value) {
            $(`#${inputValue.id}`).parent("div").parent("div").addClass("has-error");
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
        if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
            $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
        }
        $(`#${input.id}`)
            .parent("div")
            .parent("div")
            .addClass("has-error");
        $(`#span-${input.id}`).text(`پسورد ها مشابه یکدیگر نمی باشند`);
        isValid = false;
    } else {
        if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
            $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
            $(`#span-${input.id}`).text(``);
        }
        $(`#${input.id}`)
            .parent("div")
            .parent("div")
            .addClass("has-success");
    }

    return isValid;
}




function MinLengthSubmit(inputArray) {
    let isValid = true;
    for (var element of inputArray) {
        var inputValue = document.getElementById(element.name);

        if (inputValue.value.length > element.Legth) {
            $(`#${inputValue.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${inputValue.id}`).text(
                `حداقل تعداد کارکتر مورد نظر${element.Legth}  می باشد`
            );

            isValid = false;
        }
    }
    return isValid;
}

//max length
function MaxLengthSubmit(inputArray) {
    let isValid = true;

    for (var element of inputArray) {
        var inputValue = document.getElementById(element.name);

        if (inputValue.value.length < element.Legth) {
            $(`#${inputValue.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${inputValue.id}`).text(
                `حداکثر تعداد کارکتر مورد نظر${element.Legth}  می باشد`
            );

            isValid = false;
        }
    }
    return isValid;
}

function ValidEmailSubmit(input) {
    var regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;
    let isValid = true;
    var inputValue = document.getElementById(input);
    if (!regex.test(inputValue.value)) {
        if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
            $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
        }

        $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
        $(`#span-${input.id}`).text(` فرمت وارد شده ایمیل صحیح نمی باشد`);

        isValid = false;
    }
    return isValid;
}

$("#userForm").on("submit",
    function (e) {

        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["name", "family", "password", "email"])) {
            return;
        }

        if (!MaxLengthSubmit([{ name: "password", length: 6 }])) {
            return;
        }

        if (!MinLengthSubmit([
            { name: "name", length: 3 }, { name: "family", length: 3 }, { name: "password", length: 6 }])) {
            return;
        }

        if (!ComparePasswordSubmit("confirmpassword")) {
            return;
        }

        if (!ValidEmailSubmit("email")) {
            return;
        }

        if (!ValidPhoneNumberSubmit("phonenumber")) {
            return;
        }

        var userObject = JSON.stringify({
            name: array[0].value,
            family: array[1].value,
            password: array[2].value,
            email: array[4].value,
            phoneNumber: array[5].value,
            roleId: parseInt(array[6].value)
        });

        console.log(userObject);

        $.ajax({
            url: "/AdminApi/User/",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: userObject
        }).done(data => {

            $("#userForm")[0].reset();
            $.toast({
                heading: 'کاربر با موفقیت افزوده شد',
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




$("#EditUserForm").on("submit",
    function (e) {

        var array = $(this).serializeArray();
        console.log(array);
        e.preventDefault();

        if (!RequiredFieldSubmit(["name", "family", "email"])) {
            return;
        }

        if (!MinLengthSubmit([
            { name: "name", length: 3 }, { name: "family", length: 3 }])) {
            return;
        }

        if (!ValidEmailSubmit("email")) {
            return;
        }

        if (!ValidPhoneNumberSubmit("phonenumber")) {
            return;
        }

        var userObject = JSON.stringify({
            id: parseInt(array[0].value),
            name: array[1].value,
            family: array[2].value,
            email: array[3].value,
            phoneNumber: array[4].value,
            roleId: parseInt(array[5].value)
        });

        console.log(userObject);

        $.ajax({
            url: "/AdminApi/User/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: userObject
        }).done(data => {

            $.toast({
                heading: 'کاربر با موفقیت ویرایش شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6
            });
            setTimeout(function () { window.location.href = "/adminpanel/user/"; }, 2000);


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




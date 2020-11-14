function ValidEmailSubmit(input) {
    var regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;
    let isValid = true;
    var inputValue = document.getElementById(input);
    console.log(inputValue.value);
    console.log(!regex.test(inputValue.value));
    if (!regex.test(inputValue.value)) {
        if ($(`#${input}`).parent("div").parent("div").hasClass("has-success")) {
            console.log('done');
            $(`#${input}`).parent("div").parent("div").removeClass("has-success");
        }
        console.log(input);
        $(`#${input}`).parent("div").parent("div").addClass("has-error");
        $(`#span-${input}`).text(` فرمت وارد شده ایمیل صحیح نمی باشد`);

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


$("#settingForm").on("submit",
    function (e) {


        e.preventDefault();


        if (!RequiredFieldSubmit(["title", "maxSlider", "maxUploadSize"])) {
            console.log('salam');
            return;
        }

        var title = document.getElementById("title").value;
        var email = document.getElementById("email").value;
        var phone = document.getElementById("phone").value;
        var merchantId = document.getElementById("merchantId").value;
        var googleAnalytic = document.getElementById("googleAnalytic").value;
        var googleMaster = document.getElementById("googleMaster").value;
        var maxSlider = document.getElementById("maxSlider").value;
        var maxUploadSize = document.getElementById("maxUploadSize").value;
        var copyRight = document.getElementById("copyRight").value;
        var eNamad = document.getElementById("eNamad").value;
        var description = document.getElementById("description").value;
        var address = document.getElementById("address").value;
        var latitude = document.getElementById("latitude").value;
        var longitude = document.getElementById("longitude").value;
        var logo = document.getElementById("logo").value;



        if (email !== '') {
            console.log('salam2');
            if (!ValidEmailSubmit("email")) {
                console.log('salam3');
                return;
            }
        }

        if (phone !== '') {
            if (!ValidPhoneNumberSubmit("phone")) {
                return;
            }
        }

        var settingObject = JSON.stringify({
            Address: address,
            PhoneNumber: phone,
            Title: title,
            Description: description,
            MerchantId: merchantId,
            ENamad: eNamad,
            Logo: logo,
            CopyRight: copyRight,
            GoogleAnalytic: googleAnalytic,
            GoogleMaster: googleMaster,
            Latitude: latitude,
            Longitude: longitude,
            MaxSlideShow: parseInt(maxSlider),
            Email: email,
            MaxSizeUploadFile: parseInt(maxUploadSize)


        });


        $.ajax({
            url: "/AdminApi/AppSetting/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: settingObject
        }).done(data => {


            $.toast({
                heading: 'تنظیمات با موفقیت ویرایش شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6
            });
            var element = document.getElementById("settingForm");
            element.classList.remove("has-error");

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

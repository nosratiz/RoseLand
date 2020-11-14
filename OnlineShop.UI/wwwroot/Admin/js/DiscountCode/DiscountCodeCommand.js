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


function PlusNumbersSubmit(inputArray) {
    let isValid = true;

    for (var element of inputArray) {
        var inputValue = document.getElementById(element);

        if (inputValue.value <= 1) {
            $(`#${inputValue.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${inputValue.id}`).text("اعداد بزرگتر از 1 مورد قبول می باشد");
            isValid = false;
        }

    }

    return isValid;

}


function PersianDateSubmit(inputArray) {
    let isValid = true;
    for (var element of inputArray) {
        var inputValue = document.getElementById(element);

        var ex = /^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|([1-2][0-9])|(0[1-9]))))$/;

        if (ex.test(inputValue.value) === false) {
            $(`#${inputValue.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${inputValue.id}`).text(`فرمت تاریخ وارد شده مورد قبول نیست`);
            isValid = false;
        }
        else {
            $(`#${inputValue.id}`).parent("div").parent("div").addClass("has-success");
        }
    }
    return isValid;
}

function ValidAmountSubmit() {
    let isValid = true;

    var discountType = document.getElementById("DiscountType");
    var price = document.getElementById("Price");

    if (parseInt(discountType.value) === 2 && (parseInt(price.value) > 100 || parseInt(price.value) <= 1)) {
        $(`#${price.id}`).parent("div").parent("div").addClass("has-error");
        $(`#span-${price.id}`).text("مقدار تخفیف درصدی بازه 1 تا 100 مورد قبول می باشد");
        isValid = false;
    }

    return isValid;

}

$("#discountCodeForm").on("submit",
    function (e) {

        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["code", "totalCount", "Price"])) {
            return;
        }

        if (!PlusNumbersSubmit(["totalCount", "Price"])) {
            return;
        }

        if (!ValidAmountSubmit()) {
            return;
        }

        var startDate = document.getElementById("datepicker").value;
        var endDate = document.getElementById("datepicker2").value;

        if (startDate !== '' || endDate !== '') {
            if (!PersianDateSubmit(["datepicker", "datepicker2"])) {
                return;
            }
        }

        var discountObject = JSON.stringify({
            Code: array[0].value,
            Count: parseInt(array[1].value),
            DiscountType: parseInt(array[2].value),
            Price: parseInt(array[3].value),
            StartDate: startDate,
            EndDateTime: endDate,
            IsActive: $("#checkbox_1").prop('checked') === true ? true : false
        });




        $.ajax({
            url: "/AdminApi/discountCode/",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: discountObject
        }).done(data => {

            $("#discountCodeForm")[0].reset();
            $.toast({
                heading: 'کد تخفیف با موفقیت افزوده شد',
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



$("#editDiscountCodeForm").on("submit",
    function (e) {

        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["code", "totalCount", "Price"])) {
            return;
        }

        if (!PlusNumbersSubmit(["totalCount", "Price"])) {
            return;
        }

        if (!ValidAmountSubmit()) {
            return;
        }

        var startDate = document.getElementById("datepicker").value;
        var endDate = document.getElementById("datepicker2").value;

        if (startDate !== '' || endDate !== '') {
            if (!PersianDateSubmit(["datepicker", "datepicker2"])) {
                return;
            }
        }

        var discountObject = JSON.stringify({
            Code: array[0].value,
            Count: parseInt(array[1].value),
            DiscountType: parseInt(array[2].value),
            Price: parseInt(array[3].value),
            StartDate: startDate,
            EndDateTime: endDate,
            IsActive: $("#checkbox_1").prop('checked') === true ? true : false,
            id: parseInt(document.getElementById("id").value)
        });




        $.ajax({
            url: "/AdminApi/discountCode/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: discountObject
        }).done(data => {


            $.toast({
                heading: 'کد تخفیف با موفقیت  ویرایش شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6
            });

            setTimeout(function () { window.location.href = "/adminpanel/discountcode/"; }, 2000);

        }).fail(err => {
            $.toast({
                heading: 'خطا',
                text: !err.responseJSON ? "در ارسال پیام شما مشکلی به وجود آمده است." : err.responseJSON.message,
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500
            });
        });
    });
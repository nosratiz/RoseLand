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



$("#slideShowForm").on("submit",
    function (e) {

        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["name", "title", "sortOrder", "logo"])) {
            return;
        }

        if (!PlusNumbersSubmit(["sortOrder"])) {
            return;
        }

        var startDate = document.getElementById("datepicker").value;
        var endDate = document.getElementById("datepicker2").value;

        if (startDate !== '' || endDate !== '') {
            if (!PersianDateSubmit(["datepicker", "datepicker2"])) {
                return;
            }
        }

        var slideShowObject = JSON.stringify({
            Name: array[0].value,
            Title: array[1].value,
            Url: document.getElementById("url").value,
            SortOrder: parseInt(document.getElementById("sortOrder").value),
            StartDateTime: startDate,
            EndDateTime: endDate,
            IsVisible: $("#checkbox_1").prop('checked') === true ? true : false,
            Image: document.getElementById("logo").value
        });




        $.ajax({
            url: "/AdminApi/slideShow/",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: slideShowObject
        }).done(data => {

            $("#slideShowForm")[0].reset();
            $('#previewholder').hide();
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


$("#editSlideShowForm").on("submit",
    function (e) {

        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["name", "title", "sortOrder", "logo"])) {
            return;
        }

        if (!PlusNumbersSubmit(["sortOrder"])) {
            return;
        }

        var startDate = document.getElementById("datepicker").value;
        var endDate = document.getElementById("datepicker2").value;

        if (startDate !== '' || endDate !== '') {
            if (!PersianDateSubmit(["datepicker", "datepicker2"])) {
                return;
            }
        }


        var slideShowObject = JSON.stringify({
            Name: array[0].value,
            Title: array[1].value,
            Url: document.getElementById("url").value,
            SortOrder: parseInt(document.getElementById("sortOrder").value),
            StartDateTime: startDate,
            EndDateTime: endDate,
            IsVisible: $("#checkbox_1").prop('checked') === true ? true : false,
            Image: document.getElementById("logo").value,
            id: parseInt(document.getElementById("id").value)
        });





        $.ajax({
            url: "/AdminApi/slideShow/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: slideShowObject
        }).done(data => {


            $.toast({
                heading: 'اسلاید شو با موفقیت ویرایش یافت',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 3500,
                stack: 6
            });

            setTimeout(function () { window.location.href = "/adminpanel/slideShow/" }, 2000);

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


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

$("#menuForm").on("submit",
    function (e) {
        var array = $(this).serializeArray();
        e.preventDefault();
        var contents = $('#body').summernote('code');




        if (!RequiredFieldSubmit(["title", "uniqueName", "sortOrder"])) {
            return;
        }



        var menuObject = JSON.stringify({
            title: array[0].value,
            uniqueName: array[1].value,
            description: array[2].value,
            parentId: parseInt(array[3].value),
            sortOrder: parseInt(array[4].value),
            isPublish: $("#checkbox_1").prop('checked') === true ? true : false,

            body: contents
        });


        $.ajax({
            url: "/AdminApi/menu/",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: menuObject
        }).done(data => {

            $("#menuForm")[0].reset();
            $.toast({
                heading: 'منو با موفقیت افزوده شد',
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

$("#editMenuForm").on("submit",
    function (e) {
        var array = $(this).serializeArray();
        e.preventDefault();
        var contents = $('#body').summernote('code');


        if (!RequiredFieldSubmit(["title", "uniqueName", "sortOrder"])) {
            return;
        }

        console.log(array[4].value);
        console.log(array[5].value);

        var menuObject = JSON.stringify({
            title: array[0].value,
            uniqueName: array[1].value,
            description: array[2].value,
            parentId: parseInt(array[3].value),
            sortOrder: parseInt(array[4].value),
            id: parseInt(array[5].value),
            isPublish: $("#checkbox_1").prop('checked') === true ? true : false,

            body: contents
        });

        console.log(menuObject);


        $.ajax({
            url: "/AdminApi/menu/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: menuObject
        }).done(data => {


            $.toast({
                heading: 'منو با موفقیت ویرایش یافت',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6
            });
            setTimeout(function () { window.location.href = "/adminpanel/menu/"; }, 2000);

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


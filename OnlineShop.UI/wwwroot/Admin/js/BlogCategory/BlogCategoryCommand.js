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


$("#blogcategoryForm").on("submit",
    function (e) {
        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["name"])) {
            return;
        }



        var categoryObject = JSON.stringify({
            name: array[0].value,
            parentId: parseInt(array[1].value),
            slug: array[2].value,
            description: array[3].value,
            isActive: $("#checkbox_1").prop('checked') === true ? true : false
        });

        console.log(categoryObject);

        $.ajax({
            url: "/AdminApi/blogCategory/",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: categoryObject
        }).done(data => {

            $("#blogcategoryForm")[0].reset();
            $.toast({
                heading: 'دسته بندی با موفقیت افزوده شد',
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



$("#editblogCategory").on("submit",
    function (e) {
        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["name", "slug"])) {
            return;
        }

        var categoryObject = JSON.stringify({
            name: array[0].value,
            parentId: parseInt(array[1].value),
            slug: array[2].value,
            description: array[3].value,
            isActive: $("#checkbox_1").prop('checked') === true ? true : false,
            id: parseInt(array[5].value)
        });

        console.log(categoryObject);

        $.ajax({
            url: "/AdminApi/blogCategory/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: categoryObject
        }).done(data => {

            $.toast({
                heading: 'دسته بندی با موفقیت ویرایش شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 3500,
                stack: 6
            });
            setTimeout(function () { window.location.href = "/adminpanel/blogcategory/"; }, 2000);

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
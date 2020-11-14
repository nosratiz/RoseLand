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


$("#productCategoryForm").on("submit",
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
            isActive: $("#checkbox_1").prop('checked') === true ? true : false,
            Image: document.getElementById("logo").value
        });

        console.log(categoryObject);

        $.ajax({
            url: "/AdminApi/productCategory/",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: categoryObject
        }).done(data => {

            $("#productCategoryForm")[0].reset();
            $('#previewholder').hide();
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



$("#editProductCategoryForm").on("submit",
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
            id: parseInt(document.getElementById("id").value),
            isActive: $("#checkbox_1").prop('checked') === true ? true : false,
            Image: document.getElementById("logo").value
        });

        console.log(categoryObject);

        $.ajax({
            url: "/AdminApi/productCategory/",
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
            setTimeout(function () { window.location.href = "/adminpanel/productCategory/"; }, 2000);

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
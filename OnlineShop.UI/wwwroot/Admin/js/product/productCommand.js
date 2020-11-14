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

$("#editProductForm").on("submit",
    function (e) {
        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["title", "description", "logo"])) {
            return;
        }

        var contents = $('#body').summernote('code');
        var gallery = document.getElementById("tag").value.split(',');

        var productObject = JSON.stringify({
            Name: array[0].value,
            ProductCategoryId: parseInt(document.getElementById("categoryId").value),
            slug: document.getElementById("slug").value,
            description: document.getElementById("description").value,
            IsSpecial: $("#checkbox_1").prop('checked') === true ? true : false,
            Image: document.getElementById("logo").value,
            Tag: document.getElementById("tag").value,
            LongDescription: contents,
            Galleries: gallery,
            id: parseInt(document.getElementById("id").value)
        });



        $.ajax({
            url: "/AdminApi/product/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: productObject
        }).done(data => {

            $("#editproductForm")[0].reset();
            $('#previewholder').hide();
            $.toast({
                heading: 'محصول با موفقیت افزوده شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6
            });

            setTimeout(function () { window.location.href = "/adminpanel/product/"; }, 2000);

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



$("#productForm").on("submit",
    function (e) {
        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["title", "description", "logo"])) {
            return;
        }

        var contents = $('#body').summernote('code');
        var gallery = document.getElementById("tag").value.split(',');

        var productObject = JSON.stringify({
            Name: array[0].value,
            ProductCategoryId: parseInt(document.getElementById("categoryId").value),
            slug: document.getElementById("slug").value,
            description: document.getElementById("description").value,
            IsSpecial: $("#checkbox_1").prop('checked') === true ? true : false,
            Image: document.getElementById("logo").value,
            Tag: document.getElementById("tag").value,
            LongDescription: contents,
            Galleries: gallery
        });



        $.ajax({
            url: "/AdminApi/product/",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: productObject
        }).done(data => {

            $("#productForm")[0].reset();
            $('#previewholder').hide();
            $.toast({
                heading: 'محصول با موفقیت افزوده شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6
            });

            setTimeout(function () { window.location.href = "/adminpanel/product/"; }, 2000);

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
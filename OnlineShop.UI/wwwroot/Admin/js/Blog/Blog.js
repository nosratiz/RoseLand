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

$("#blogForm").on("submit",
    function (e) {
        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["title", "description", "logo"])) {
            return;
        }
        var contents = $('#body').summernote('code');

        var blogObject = JSON.stringify({
            title: array[0].value,
            Slug: document.getElementById("slug").value,
            CategoryId: parseInt(document.getElementById("categoryId").value),
            Description: document.getElementById("description").value,
            Image: document.getElementById("logo").value,
            LongDescription: contents,
            PublishDate: document.getElementById("datepicker").value,
            Tag: document.getElementById("tag").value
        });



        $.ajax({
            url: "/AdminApi/blog/",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: blogObject
        }).done(data => {

            $("#blogForm")[0].reset();
            $.toast({
                heading: 'مقاله با موفقیت افزوده شد',
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


$("#editBlogForm").on("submit",
    function (e) {
        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["title", "description", "logo", "slug"])) {
            return;
        }
        var contents = $('#body').summernote('code');

        console.log(contents);

        var blogObject = JSON.stringify({
            title: array[0].value,
            Slug: document.getElementById("slug").value,
            CategoryId: parseInt(document.getElementById("categoryId").value),
            Description: document.getElementById("description").value,
            Image: document.getElementById("logo").value,
            LongDescription: contents,
            PublishDate: document.getElementById("datepicker").value,
            Tag: document.getElementById("tag").value,
            id: parseInt(document.getElementById("id").value)
        });

        console.log(blogObject);

        $.ajax({
            url: "/AdminApi/blog/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: blogObject
        }).done(data => {

            $.toast({
                heading: 'مقاله با موفقیت افزوده شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6
            });
            setTimeout(function () { window.location.href = "/adminpanel/blog/"; }, 2000);

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
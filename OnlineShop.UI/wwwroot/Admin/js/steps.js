$(".tab-wizard").steps({
    headerTag: "h6"
    , bodyTag: "section"
    , transitionEffect: "none"
    , titleTemplate: '<span class="step">#index#</span> #title#'
    , labels: {
        finish: "Submit"
    }
    , onFinished: function (event, currentIndex) {


        if (!RequiredFieldSubmit(["title", "description", "logo"])) {
            return;
        }

        var contents = $('#body').summernote('code');
        var gallery = document.getElementById("gallery").value.split(',');

        var productObject = JSON.stringify({
            Name: document.getElementById("title").value,
            ProductCategoryId: parseInt(document.getElementById("categoryId").value),
            slug: document.getElementById("slug").value,
            description: document.getElementById("description").value,
            IsSpecial: $("#checkbox_1").prop('checked') === true ? true : false,
            Image: document.getElementById("logo").value,
            Tag: document.getElementById("tag").value,
            LongDescription: contents,
            Galleries: gallery
        });

        swal({
            title: "افزودن محصول",
            text: `ایا ازافزودن محصول اطمینان دارید`,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "بله، آن را انجام کنید!",
            cancelButtonText: "نه، لغو لطفا!",
            closeOnConfirm: false,
            closeOnCancel: false
        },
            function (isConfirm) {
                if (isConfirm) {
                    $.ajax({
                        url: "/AdminApi/product/",
                        method: 'post',
                        contentType: 'application/json',
                        data: productObject,
                        success: function (result) {
                            swal("انجام شد!", "عملیات با موفیقت انجام شد", "success");
                            setTimeout(function () { window.location.href = "/adminpanel/product/"; }, 2000);
                        },
                        error: function (request) {

                            swal("خطا", request.responseJSON.message, "error");
                        }
                    });
                } else {
                    swal("لغو شد", "عملیات لغو شد:)", "error");
                }
            });

    }
});


var form = $(".validation-wizard").show();

$(".validation-wizard").steps({
    headerTag: "h6"
    , bodyTag: "section"
    , transitionEffect: "none"
    , titleTemplate: '<span class="step">#index#</span> #title#'
    , labels: {
        finish: "Submit"
    }
    , onStepChanging: function (event, currentIndex, newIndex) {
        return currentIndex > newIndex || !(3 === newIndex && Number($("#age-2").val()) < 18) && (currentIndex < newIndex && (form.find(".body:eq(" + newIndex + ") label.error").remove(), form.find(".body:eq(" + newIndex + ") .error").removeClass("error")), form.validate().settings.ignore = ":disabled,:hidden", form.valid())
    }
    , onFinishing: function (event, currentIndex) {
        return form.validate().settings.ignore = ":disabled", form.valid()
    }
    , onFinished: function (event, currentIndex) {
        swal("Your Form Submitted!", "Sed dignissim lacinia nunc. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor.");
    }
}), $(".validation-wizard").validate({
    ignore: "input[type=hidden]"
    , errorClass: "text-danger"
    , successClass: "text-success"
    , highlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    }
    , unhighlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    }
    , errorPlacement: function (error, element) {
        error.insertAfter(element)
    }
    , rules: {
        email: {
            email: !0
        }
    }
})
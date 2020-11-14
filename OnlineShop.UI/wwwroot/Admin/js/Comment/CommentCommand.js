function GetComment(id) {
    $.ajax({
        url: "/Adminapi/comment/" + id,
        type: "Get",
        dataType: "json",
        contentType: "application/json",
        //contentType:"application/json",
    }).done(data => {
        $("#name").html(data.user.fullName);
        $("#comment").html(data.description);
        $("#id").val(data.id);
        $("#isConfirm").val(data.isConfirm);

        $("#commentId").val(data.id);
        if (data.isConfirm === true) {

            $("#confirmbtn").html("عدم تایید");
            $("#confirmtxt").html("آیا مایل به رد کردن نظر هستید");
        } else {
            $("#confirmbtn").html(" تایید");
            $("#confirmtxt").html("آیا مایل به تایید کردن نظر هستید");
        }


    })

        .fail(err => {
            $.toast({
                heading: 'خطا',
                text: !err.responseJSON ? "در ارسال پیام شما مشکلی به وجود آمده است." : err.responseJSON.message,
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500,
            });
        });
};


function confirmBtn() {
    var id = $("#commentId").val();
    var confirm = $("#isConfirm").val();
    console.log(confirm);
    $.ajax({
        url: "/Adminapi/comment/" + id,
        type: "put",
        dataType: "json",
        contentType: "application/json",
        //contentType:"application/json",
    }).done(data => {

        $.toast({
            heading: 'عملیات با موفقیت انجام شد',
            text: '',
            position: 'top-right',
            loaderBg: '#ff6849',
            icon: 'success',
            hideAfter: 3500,
            stack: 6
        });

        console.log(confirm);
        if ($("#confrim_" + id).hasClass('ti-check')) {
            $("#confrim_" + id).removeClass('ti-check');
            $("#confrim_" + id).addClass('ti-close');

        } else {
            $("#confrim_" + id).removeClass('ti-close');
            $("#confrim_" + id).addClass('ti-check');
        }
        $('#modal-center').modal('hide');

    })

        .fail(err => {
            $.toast({
                heading: 'خطا',
                text: !err.responseJSON ? "در ارسال پیام شما مشکلی به وجود آمده است." : err.responseJSON.message,
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500,
            });
        });
}

function DeleteComment(id, name) {

    //Parameter

    swal({
        title: "حذف کامنت",
        text: `ایا مطمئن از حذف کامنت ${name} هستید`,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "بله، آن را حذف کنید!",
        cancelButtonText: "نه، لغو لطفا!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    url: '/AdminApi/comment/' + id,
                    method: 'DELETE',
                    contentType: 'application/json',
                    success: function (result) {
                        swal("پاک شد!", "عملیات با موفیقت انجام شد", "success");
                    },
                    error: function (request) {

                        swal("خطا", request.responseJSON.message, "error");
                        $('#tr_' + id).remove();
                    }
                });

            } else {
                swal("لغو شد", "عملیات لغو شد:)", "error");
            }
        });


}


function ReplyComment() {
    var id = $("#commentId").val();
    var content = $("#description").val();
    var replyComment = JSON.stringify({
        id: parseInt(id),
        Description: content
    });

    $.ajax({
        url: "/Adminapi/comment/",
        type: "post",
        dataType: "json",
        contentType: "application/json",
        data: replyComment
        //contentType:"application/json",
    }).done(data => {

        $.toast({
            heading: 'عملیات با موفقیت انجام شد',
            text: '',
            position: 'top-right',
            loaderBg: '#ff6849',
            icon: 'success',
            hideAfter: 2000,
            stack: 6
        });

        setTimeout(function () { window.location.href = "/adminpanel/comment/"; }, 2000);

    })

        .fail(err => {
            $.toast({
                heading: 'خطا',
                text: !err.responseJSON ? "در ارسال پیام شما مشکلی به وجود آمده است." : err.responseJSON.message,
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500,
            });
        });
}
function notification() {

    $.ajax({
        url: "/Adminapi/notification?limit=5",
        type: "Get",
        dataType: "json",
        contentType: "application/json",
        //contentType:"application/json",
    }).done(data => {
        var str = '';


        data.forEach(function (item) {

            str += '<li> <a href="#" >' + item.description + ' </a></li>';

        });
        document.getElementById("notif").innerHTML = str;

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
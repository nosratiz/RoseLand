
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

function PlusNumbers(inputArray) {
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

function LowerThans(input, greaterInput, msg) {

    let isValid = true;
    var lowerPrice = document.getElementById(input).value;
    var inputValue = document.getElementById(greaterInput).value;

    
    if (lowerPrice >= inputValue || (lowerPrice <= 0 && lowerPrice !== null)) {
        $(`#${lowerPrice.id}`).parent("div").parent("div").removeClass("has-success");
        $(`#${lowerPrice.id}`).parent("div").parent("div").addClass("has-error");
        $(`#span-${lowerPrice.id}`).text(msg);
        isValid = false;


    } else {


        $(`#${lowerPrice.id}`).parent("div").parent("div").removeClass("has-error");
        $(`#span-${lowerPrice.id}`).text(``);

        $(`#${lowerPrice.id}`).parent("div").parent("div").addClass("has-success");
    }


    return isValid;
}


$("#variantForm").on("submit",
    function (e) {

        var array = $(this).serializeArray();
        e.preventDefault();

        if (!RequiredFieldSubmit(["price", "count"])) {
            return;
        }

        if (!LowerThans("discountprice", "price", "قیمت تخفیف باید کوچکتر از قیمت محصول باشد")) {
            return;
        }

        if (!PlusNumbers(["price", "count"])) {
            return;
        }

        var discountPrice = array[2].value !== null ? parseInt(array[2].value) : 0;

        console.log("salam");

        var variantObject = JSON.stringify({
            productId: parseInt(array[0].value),
            price: parseInt(array[1].value),
            discountPrice: discountPrice,
            count: parseInt(array[3].value),
            boxType: parseInt(array[4].value),
            description: array[5].value
        });

        $.ajax({
            url: "/AdminApi/productVariant/",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: variantObject
        }).done(data => {

            $("#variantForm")[0].reset();
            $.toast({
                heading: 'محصول با موفقیت افزوده شد',
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


$("#editVariantForm").on("submit",
    function (e) {

        var array = $(this).serializeArray();
        e.preventDefault();


        if (!RequiredFieldSubmit(["price", "count"])) {
            return;
        }

        if (!LowerThans("discountprice", "price", "قیمت تخفیف باید کوچکتر از قیمت محصول باشد")) {
            return;
        }

        if (!PlusNumbers(["price", "count"])) {
            return;
        }

        var discountPrice = array[3].value !== null ? parseInt(array[2].value) : 0;

        console.log();

        var variantObject = JSON.stringify({
            id: parseInt(array[0].value),
            productId: parseInt(array[1].value),
            price: parseInt(array[2].value),
            discountPrice: discountPrice,
            count: parseInt(array[4].value),
            boxType: parseInt(array[5].value),
            description: array[6].value
        });

        $.ajax({
            url: "/AdminApi/productVariant/",
            type: "put",
            dataType: "json",
            contentType: "application/json",
            //contentType:"application/json",
            data: variantObject
        }).done(data => {

   
            $.toast({
                heading: 'محصول با موفقیت ویرایش شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6
            });
            setTimeout(function () { window.location.href = "/adminpanel/productVariant/" + parseInt(array[1].value) + "/list"; }, 2000);

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
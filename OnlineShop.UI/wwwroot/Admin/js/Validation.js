function persiandate(el) {

    if (!el.value) {
        console.log("salam2");
        if ($(`#${el.id}`).parent("div").parent("div").hasClass("has-success")) {
            $(`#${el.id}`).parent("div").parent("div").removeClass("has-success");
        }
        if ($(`#${el.id}`).parent("div").parent("div").hasClass("has-error")) {
            $(`#${el.id}`).parent("div").parent("div").removeClass("has-error");
            $(`#span-${el.id}`).text(``);
        }
        return;
    }
    console.log("salam");
    var ex =
        /^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|([1-2][0-9])|(0[1-9]))))$/;
    if (ex.test(el.value) === false) {
        $(`#${el.id}`).parent("div").parent("div").addClass("has-error");
        $(`#span-${el.id}`).text(`فرمت تاریخ وارد شده مورد قبول نیست`);
    } else {

        if ($(`#${el.id}`).parent("div").parent("div").hasClass("has-error")) {

            $(`#${el.id}`).parent("div").parent("div").removeClass("has-error");
            $(`#span-${el.id}`).text(``);

            $(`#${el.id}`).parent("div").parent("div").addClass("has-success");
        }
    }
}

function addComma(el) {
        if (el.which >= 37 && el.which <= 40) return;
        $(el).val(function (index, value) {

            return value.replace(/^0+/, '').replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",");

        });
    }

    function MinLengthVal(input, length) {

        if (!input.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            return;
        }

        if (!(input.value.length >= length)) {

            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${input.id}`).text(` حداقل تعداد کارکتر مورد نیاز${length} می باشد`);

        }

        else {

            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-success");
        }
    }

    function MaxLengthVal(input, length) {

        if (!input.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            return;
        }

        if (!(input.value.length <= length)) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }

            $(`#${el.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${el.id}`).text(` حداکثر تعداد کارکتر مورد نیاز${length} می باشد`);

        }

        else {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            $(`#${input.id}`).parent("div").parent("div").addClass("has-success");
        }
    }


    function JustInt(input, e) {

        if (!input.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            return;
        }

        var charCode = e.which ? e.which : e.keyCode;
        if (charCode !== 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {

            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${input.id}`).text(`فقط مقدار عددی مورد قبول می باشد`);
        } else {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-success");
        }
    }

    function PlusNumber(input) {

        if (!input.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            return;
        }

        if (input.value < 1) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${input.id}`).text(`اعداد بزرگتر از 1 مورد قبول می باشد`);
        } else {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-success");
        }

    }

    function Just_persian(input) {

        if (!input.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            return;
        }
        var re = /^[پچجحخهعغفقثصضشسیبلاتنمکگوئدذرزطظژؤإأءًٌٍَُِّ\s]+$/;

        if (re.test(input.value) === false) {

            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${input.id}`).text(`فقط کارکتر فارسی مورد قبول می باشد`);


        }

        else {

            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-success");
        }
    }

    function LowerThan(input, greaterInput, msg) {

        if (!input.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            return;
        }

        var inputValue = document.getElementById(greaterInput.name).value;

        console.log(parseInt(input.value) >= parseInt(inputValue));

        if (parseInt(input.value) >= parseInt(inputValue) || (input.value <= 0 && input.value !== null)) {
            $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${input.id}`).text(msg);



        } else {


            $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
            $(`#span-${input.id}`).text(``);

            $(`#${input.id}`).parent("div").parent("div").addClass("has-success");
        }

    }




    function ComparePassword(input) {
        var inputValue = document.getElementById("password");
        let isValid = true;

        if (input.value !== inputValue.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            $(`#${input.id}`)
                .parent("div")
                .parent("div")
                .addClass("has-error");
            $(`#span-${input.id}`).text(`پسورد ها مشابه یکدیگر نمی باشند`);
            isValid = false;
        } else {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            $(`#${input.id}`)
                .parent("div")
                .parent("div")
                .addClass("has-success");
        }

        return isValid;
    }


    function MinLengthSubmit(inputArray) {
        let isValid = true;
        inputArray.forEach((element) => {
            var inputValue = (document.getElementById(element.name))
                .value;

            if (inputValue.length > element.Legth) {
                $(`#${inputValue}`).parent("div").parent("div").addClass("has-error");
                $(`#span-${inputValue}`).text(
                    `حداقل تعداد کارکتر مورد نظر${element.Legth}  می باشد`
                );

                isValid = false;
            }
        });
        return isValid;
    }

    //max length
    function MaxLengthSubmit(inputArray) {
        let isValid = true;
        inputArray.forEach((element) => {
            var inputValue = (document.getElementById(element.name)).value;

            if (inputValue.length < element.Legth) {
                $(`#${inputValue}`).parent("div").parent("div").addClass("has-error");
                $(`#span-${inputValue}`).text(
                    `حداکثر تعداد کارکتر مورد نظر${element.Legth}  می باشد`
                );

                isValid = false;
            }
        });
        return isValid;
    }

    //persian date validation
    function ValidPersianDate(inputArray) {
        let isValid = true;
        var ex = /^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|([1-2][0-9])|(0[1-9]))))$/;
        inputArray.forEach((element) => {
            var inputValue = (document.getElementById(element)).value;

            if (ex.test(inputValue) === false) {
                $(`#${element}`).parent("div").parent("div").addClass("has-error");
                $(`#span-${element}`).text(`فرمت تاریخ وارد شده مورد قبول نیست`);

                isValid = false;
            }
        });
        return isValid;
    }


    function ValidEmailVal(input) {

        if (!input.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            return;
        }

        var regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;

        if (!regex.test(input.value)) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${input.id}`).text(` فرمت وارد شده ایمیل صحیح نمی باشد`);
        }

        else {

            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-success");
        }

    }

    function ValidEmailSubmit(input) {
        var regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;
        let isValid = true;

        if (!regex.test(input.value)) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${input.id}`).text(` فرمت وارد شده ایمیل صحیح نمی باشد`);

            isValid = false;
        }
        return isValid;
    }

    function ValidPhoneNumber(input) {
        var regex = /^[0-9]*$/;

        if (!input.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            return;
        }
        if ((input.value.length !== 11 || !regex.test(input.value))) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${input.id}`).text(` شماره همراه معتبر نمی باشد`);
        } else {

            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-success");

        }
    }

    function ValidPhoneNumberSubmit(input) {
        let isValid = true;
        var regex = /^[0-9]*$/;
        if ((input.value.length !== 11 || !regex.test(input.value))) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }

            $(`#${input.id}`).parent("div").parent("div").addClass("has-error");
            $(`#span-${input.id}`).text(` شماره همراه معتبر نمی باشد`);
            isValid = false;
        }

        return isValid;
    }

    function ComparePasswordSubmit(input) {
        var inputValue = document.getElementById("password");
        var value = document.getElementById(input);
        let isValid = true;
        console.log(inputValue);
        if (value.value !== inputValue.value) {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-success")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-success");
            }
            $(`#${input.id}`)
                .parent("div")
                .parent("div")
                .addClass("has-error");
            $(`#span-${input.id}`).text(`پسورد ها مشابه یکدیگر نمی باشند`);
            isValid = false;
        } else {
            if ($(`#${input.id}`).parent("div").parent("div").hasClass("has-error")) {
                $(`#${input.id}`).parent("div").parent("div").removeClass("has-error");
                $(`#span-${input.id}`).text(``);
            }
            $(`#${input.id}`)
                .parent("div")
                .parent("div")
                .addClass("has-success");
            isValid = true;
        }

        return isValid;
    }



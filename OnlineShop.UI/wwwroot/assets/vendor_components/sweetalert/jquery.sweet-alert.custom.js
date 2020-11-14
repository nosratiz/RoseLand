
!function($) {
    "use strict";

    var SweetAlert = function() {};

    //examples 
    SweetAlert.prototype.init = function() {
        
    //Basic
    $('#sa-basic').click(function(){
        swal("در اینجا یک پیام است!");
    });

    //A title with a text under
    $('#sa-title').click(function(){
        swal("در اینجا یک پیام است!", "لورم ایپسوم متن ساختگی با تولید سادگی, نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است, چاپگرها و متون بلکه.")
    });

    //Success Message
    $('#sa-success').click(function(){
        swal("آفرین!", "لورم ایپسوم متن ساختگی با تولید سادگی, نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است, چاپگرها و متون بلکه.", "success")
    });

    //Warning Message
    $('#sa-warning').click(function(){
        swal({   
            title: "شما مطمئن هستید؟",   
            text: "شما نمیتوانید این فایل خیالی را بازیابی کنید!",   
            type: "warning",   
            showCancelButton: true,   
            confirmButtonColor: "#DD6B55",   
            confirmButtonText: "بله، آن را حذف کنید!",   
            closeOnConfirm: false 
        }, function(){   
            swal("پاک شد!", "فایل خیالی شما حذف شده است.", "success"); 
        });
    });

    //Parameter
    $('#sa-params').click(function(){
        swal({   
            title: "شما مطمئن هستید؟",   
            text: "شما نمیتوانید این فایل خیالی را بازیابی کنید!",   
            type: "warning",   
            showCancelButton: true,   
            confirmButtonColor: "#DD6B55",   
            confirmButtonText: "بله، آن را حذف کنید!",   
            cancelButtonText: "نه، لغو لطفا!",   
            closeOnConfirm: false,   
            closeOnCancel: false 
        }, function(isConfirm){   
            if (isConfirm) {     
                swal("پاک شد!", "فایل خیالی شما حذف شده است.", "success");   
            } else {     
                swal("لغو شد", "فایل خیالی شما امن است :)", "error");   
            } 
        });
    });

    //Custom Image
    $('#sa-image').click(function(){
        swal({   
            title: "آرش!",   
            text: "به تازگی توییتر پیوست",   
            imageUrl: "../../images/avatar.png" 
        });
    });

    //Auto Close Timer
    $('#sa-close').click(function(){
         swal({   
            title: "هشداربسته شدن خودکار!",   
            text: "من در عرض 2 ثانیه بسته خواهم شد.",   
            timer: 2000,   
            showConfirmButton: false 
        });
    });


    },
    //init
    $.SweetAlert = new SweetAlert, $.SweetAlert.Constructor = SweetAlert
}(window.jQuery),

//initializing 
function($) {
    "use strict";
    $.SweetAlert.init()
}(window.jQuery);
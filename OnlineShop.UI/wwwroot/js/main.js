var styles = [
  {
    elementType: 'geometry',
    stylers: [
      {
        color: '#212121',
      },
    ],
  },
  {
    elementType: 'labels.icon',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    elementType: 'labels.text.fill',
    stylers: [
      {
        color: '#757575',
      },
    ],
  },
  {
    elementType: 'labels.text.stroke',
    stylers: [
      {
        color: '#212121',
      },
    ],
  },
  {
    featureType: 'administrative',
    elementType: 'geometry',
    stylers: [
      {
        color: '#757575',
      },
    ],
  },
  {
    featureType: 'administrative.country',
    elementType: 'labels.text.fill',
    stylers: [
      {
        color: '#9e9e9e',
      },
    ],
  },
  {
    featureType: 'administrative.land_parcel',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'administrative.land_parcel',
    elementType: 'labels',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'administrative.locality',
    elementType: 'labels.text.fill',
    stylers: [
      {
        color: '#bdbdbd',
      },
    ],
  },
  {
    featureType: 'poi',
    elementType: 'labels.text',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'poi',
    elementType: 'labels.text.fill',
    stylers: [
      {
        color: '#757575',
      },
    ],
  },
  {
    featureType: 'poi.business',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'poi.park',
    elementType: 'geometry',
    stylers: [
      {
        color: '#181818',
      },
    ],
  },
  {
    featureType: 'poi.park',
    elementType: 'labels.text.fill',
    stylers: [
      {
        color: '#616161',
      },
    ],
  },
  {
    featureType: 'poi.park',
    elementType: 'labels.text.stroke',
    stylers: [
      {
        color: '#1b1b1b',
      },
    ],
  },
  {
    featureType: 'road',
    elementType: 'geometry.fill',
    stylers: [
      {
        color: '#2c2c2c',
      },
    ],
  },
  {
    featureType: 'road',
    elementType: 'labels.icon',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'road',
    elementType: 'labels.text.fill',
    stylers: [
      {
        color: '#8a8a8a',
      },
    ],
  },
  {
    featureType: 'road.arterial',
    elementType: 'geometry',
    stylers: [
      {
        color: '#373737',
      },
    ],
  },
  {
    featureType: 'road.arterial',
    elementType: 'labels',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'road.highway',
    elementType: 'geometry',
    stylers: [
      {
        color: '#3c3c3c',
      },
    ],
  },
  {
    featureType: 'road.highway',
    elementType: 'labels',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'road.highway.controlled_access',
    elementType: 'geometry',
    stylers: [
      {
        color: '#4e4e4e',
      },
    ],
  },
  {
    featureType: 'road.local',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'road.local',
    elementType: 'labels',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'road.local',
    elementType: 'labels.text.fill',
    stylers: [
      {
        color: '#616161',
      },
    ],
  },
  {
    featureType: 'transit',
    stylers: [
      {
        visibility: 'off',
      },
    ],
  },
  {
    featureType: 'transit',
    elementType: 'labels.text.fill',
    stylers: [
      {
        color: '#757575',
      },
    ],
  },
  {
    featureType: 'water',
    elementType: 'geometry',
    stylers: [
      {
        color: '#000000',
      },
    ],
  },
  {
    featureType: 'water',
    elementType: 'labels.text.fill',
    stylers: [
      {
        color: '#3d3d3d',
      },
    ],
  },
];

var map;
function initMap() {
  if (document.getElementById('map')) {
    map = new google.maps.Map(document.getElementById('map'), {
      center: { lat: -34.397, lng: 150.644 },
      zoom: 8,
      styles: styles,
      disableDefaultUI: true,
    });
  }
}

$(function () {
  $(document).ready(function () {
    // Banner Height
    $('.banner-container .swiper-slide').css('height', 'calc(100vh - ' + $('header').innerHeight() + 'px)');

    // Banner Init
    var bannerSlider = new Swiper('.banner-container .swiper-container', {
      navigation: {
        nextEl: '.banner-container .swiper-button-next',
        prevEl: '.banner-container .swiper-button-prev',
      },
    });

    // Product Carousel Init
    var productSlider = new Swiper('.products-container .swiper-container', {
      navigation: {
        nextEl: '.products-container .swiper-button-next',
        prevEl: '.products-container .swiper-button-prev',
      },
      slidesPerView: 4,
      breakpoints: {
        375: {
          slidesPerView: 1,
        },
        550: {
          slidesPerView: 1,
        },
        768: {
          slidesPerView: 2,
        },
        1024: {
          slidesPerView: 4,
        },
      },
      // spaceBetween: 30,
      loop: true,
    });

    // Accordion Item
    if ($('.questions-page').length > 0) {
      $('.questions-page').on('click', '.accordion', function () {
        $(this).toggleClass('active');
        var panel = $(this).next();
        panel.toggleClass('active');
        if (panel[0].style.maxHeight) {
          panel[0].style.maxHeight = null;
        } else {
          panel[0].style.maxHeight = panel[0].scrollHeight + 20 + 'px';
        }
      });
    }

    // Ajax Global
    function ajaxInstance(url, method, data) {
      return $.ajax({
        url: url,
        type: method,
        dataType: 'json',
        contentType: 'application/json',
        //contentType:"application/json",
        data: data,
      });
    }

    // textarea focus/blur
    $('.textarea').focus(function () {
      if ($(this).hasClass('is-danger')) {
        $(this).removeClass('is-danger');
        $(this).parent().next().addClass('hide');
      }
    });

    // input focus/blur
    $('.input').focus(function () {
      if ($(this).hasClass('is-danger')) {
        $(this).removeClass('is-danger');
        $(this).parent().next().addClass('hide');
      }
    });

    // Make Auth page full height
    if ($('#loginForm').length > 0) {
      // $(".auth-container").css('height', 'calc(100vh - ' + $('header').innerHeight() + 'px)')
    }

    // Seach Icon
    $('#searchIcon').on('click', function (e) {
      $('#searchContainer').addClass('active');
      $('#searchContainer .input').focus();
    });

    // Close Search Modal
    $('#searchContainer .close-btn').on('click', function (e) {
      $('#searchContainer').removeClass('active');
    });

    // Search
    $('#searchContainer .input').on('keyup', function (e) {
      if ($(this).val().length > 2) {
        $.ajax({
          url: '/site/search?query=' + $(this).val(),
          type: 'GET',
          dataType: 'json',
          contentType: 'application/x-www-form-urlencoded',
          success: function (res) {
            if (res.length > 0) {
              $('#searchContainer').addClass('active');
              var template = '<ul>';
              res.forEach(function (item) {
                if (item.searchType === 1) {
                  return (template +=
                    "<li><a href='/product/" +
                    item.slug +
                    "'>" +
                    "<div class='img-container' style='background-image: url(" +
                    item.image +
                    ");'></div>" +
                    "<div><span class='item-title'>" +
                    item.title +
                    '</span>' +
                    '</div>' +
                    '</a></li>');
                }
                if (item.searchType === 2) {
                  return (template +=
                    "<li><a href='/blog/" +
                    item.slug +
                    "'>" +
                    "<div class='img-container' style='background-image: url(" +
                    item.image +
                    ");'></div>" +
                    "<div><span class='item-title'>" +
                    item.title +
                    '</span>' +
                    "<div class='price-container'>" +
                    '</div>' +
                    '</div>' +
                    '</a></li>');
                }
              });
              template += '</ul>';
              $('#searchContainer .search-result').html(template);
            } else {
              $('#searchContainer').removeClass('active');
              $('#searchContainer .search-result').empty();
            }
          },
          error: function (error) {
            $('#searchContainer').removeClass('active');
          },
        });
      } else {
        $('#searchContainer').removeClass('active');
        $('#searchContainer .search-result').empty();
      }
    });

    // Login Form
    var isLoginFormLoading = false;
    $('#loginForm').on('submit', function (e) {
      e.preventDefault();
      var array = $(this).serializeArray(),
        isFormValid = true,
        regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;

      // remove form input
      $('#loginForm .input').removeClass('is-danger');
      $('#loginForm .input').parent().next().addClass('hide');
      // validate each input
      if (!array[0].value || !regex.test(array[0].value)) {
        $('#loginForm input[name=email]').addClass('is-danger');
        $('#loginForm input[name=email]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[1].value) {
        $('#loginForm input[name=password]').addClass('is-danger');
        $('#loginForm input[name=password]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (isFormValid) {
        isLoginFormLoading = true;
        if (isLoginFormLoading) {
          $('#loginForm .button').addClass('is-loading');
          $('#loginForm .button').prop('disabled', true);
        }
        var login = JSON.stringify({
          email: array[0].value,
          password: array[1].value,
        });
        return $.ajax({
          url: '/Account/SignIn',
          type: 'POST',
          dataType: 'json',
          contentType: 'application/json',
          data: login,
        })
          .done(function (res) {
            $('#loginForm .button').removeClass('is-loading');
            $('#loginForm .button').prop('disabled', false);
            return window.location.replace('/');
          })
          .fail(function (err) {
            $('#loginForm .button').removeClass('is-loading');
            $('#loginForm .button').prop('disabled', false);
            $.toast({
              heading: 'خطا',
              text: !err.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : err.responseJSON.message,
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'error',
              hideAfter: 3500,
            });
          });
      }
    });

    // Register Form
    var isRegisterFormLoading = false;
    $('#registerForm').on('submit', function (e) {
      e.preventDefault();
      var array = $(this).serializeArray(),
        isFormValid = true,
        regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;

      // remove form input
      $('#registerForm .input').removeClass('is-danger');
      $('#registerForm .input').parent().next().addClass('hide');
      // validate each input
      if (!array[0].value) {
        $('#registerForm input[name=name]').addClass('is-danger');
        $('#registerForm input[name=name]').parent().next().removeClass('hide');
        isFormValid = false;
      }
      if (!array[1].value) {
        $('#registerForm input[name=family]').addClass('is-danger');
        $('#registerForm input[name=family]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[2].value || !regex.test(array[2].value)) {
        $('#registerForm input[name=email]').addClass('is-danger');
        $('#registerForm input[name=email]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[3].value) {
        $('#registerForm input[name=password]').addClass('is-danger');
        $('#registerForm input[name=password]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (isFormValid) {
        isRegisterFormLoading = true;
        if (isRegisterFormLoading) {
          $('#registerForm .button').addClass('is-loading');
          $('#registerForm .button').prop('disabled', true);
        }

        var register = JSON.stringify({
          name: array[0].value,
          family: array[1].value,
          email: array[2].value,
          password: array[3].value,
        });
        return $.ajax({
          url: '/Account/Register',
          type: 'POST',
          dataType: 'json',
          contentType: 'application/json',
          data: register,
        })
          .done(function (res) {
            $('#registerForm .button').removeClass('is-loading');
            $('#registerForm .button').prop('disabled', false);
            $('#registerForm')[0].reset();
            $.toast({
              heading: 'یک ایمیل برای تایید حساب کاربری برای شما ارسال شد',
              text: '',
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'success',
              hideAfter: 2000,
              stack: 6,
            });
          })
          .fail(function (err) {
            $('#registerForm .button').removeClass('is-loading');
            $('#registerForm .button').prop('disabled', false);
            $.toast({
              heading: 'خطا',
              text: !err.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : err.responseJSON.message,
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'error',
              hideAfter: 3500,
            });
          });
      }
    });

    // Forgot Password Form
    var isForgotPasswordFormLoading = false;
    $('#forgotPasswordForm').on('submit', function (e) {
      e.preventDefault();
      var array = $(this).serializeArray(),
        isFormValid = true,
        regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;

      // remove form input
      $('#forgotPasswordForm .input').removeClass('is-danger');
      $('#forgotPasswordForm .input').parent().next().addClass('hide');
      // validate each input
      if (!array[0].value || !regex.test(array[0].value)) {
        $('#forgotPasswordForm input[name=email]').addClass('is-danger');
        $('#forgotPasswordForm input[name=email]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (isFormValid) {
        isForgotPasswordFormLoading = true;
        if (isForgotPasswordFormLoading) {
          $('#forgotPasswordForm .button').addClass('is-loading');
          $('#forgotPasswordForm .button').prop('disabled', true);
        }

        var forgetPassword = JSON.stringify({
          email: array[0].value,
        });
        return $.ajax({
          url: '/Account/forgetPassword',
          type: 'POST',
          dataType: 'json',
          contentType: 'application/json',
          data: forgetPassword,
        })
          .done(function (res) {
            $('#forgotPasswordForm .button').removeClass('is-loading');
            $('#forgotPasswordForm .button').prop('disabled', false);
            $('#forgotPasswordForm')[0].reset();
            $.toast({
              heading: 'ایمیل با موفیقت برای شما راسال شد',
              text: '',
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'success',
              hideAfter: 2000,
              stack: 6,
            });
          })
          .fail(function (err) {
            $('#forgotPasswordForm .button').removeClass('is-loading');
            $('#forgotPasswordForm .button').prop('disabled', false);
            $.toast({
              heading: 'خطا',
              text: !err.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : err.responseJSON.message,
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'error',
              hideAfter: 3500,
            });
          });
      }
    });

    // Contact Form
    var isContactFormLoading = false;
    $('#contactForm').on('submit', function (e) {
      e.preventDefault();

      var array = $(this).serializeArray(),
        isFormValid = true,
        regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/,
        phoneRegex = /^([0-9\(\)\/\+ \-]*)$/;

      // remove form input
      $('#contactForm .input').removeClass('is-danger');
      $('#contactForm .input').parent().next().addClass('hide');
      // validate each input
      if (!array[0].value) {
        $('#contactForm input[name=fullName]').addClass('is-danger');
        $('#contactForm input[name=fullName]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[1].value || !regex.test(array[1].value)) {
        $('#contactForm input[name=email]').addClass('is-danger');
        $('#contactForm input[name=email]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[2].value || !phoneRegex.test(array[2].value) || array[2].value.length !== 11) {
        $('#contactForm input[name=phoneNumber]').addClass('is-danger');
        $('#contactForm input[name=phoneNumber]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!$('#contactForm textarea').val()) {
        $('#contactForm textarea').addClass('is-danger');
        $('#contactForm textarea').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (isFormValid) {
        isContactFormLoading = true;
        if (isContactFormLoading) {
          $('#contactForm .button').addClass('is-loading');
          $('#contactForm .button').prop('disabled', true);
        }
        return $.ajax({
          url: 'http://localhost:1337/contacts',
          type: 'POST',
          dataType: 'json',
          contentType: 'application/x-www-form-urlencoded',
          data: { fullName: array[0].value, email: array[1].value, mobileNumber: array[2].value, message: array[3].value },
        })
          .done(function (res) {
            $('#contactForm .button').removeClass('is-loading');
            $('#contactForm .button').prop('disabled', false);
            $('#contactForm')[0].reset();
            return toastr.success('پیام شما با موفقیت ارسال گردید.');
          })
          .fail(function (err) {
            $('#contactForm .button').removeClass('is-loading');
            $('#contactForm .button').prop('disabled', false);
            return toastr.error(!err.responseJSON.message ? 'فرم خود را به درستی وارد نمایید.' : err.responseJSON.message);
          });
      }
    });

    // Edit Profile Form
    var isEditProfileFormLoading = false;
    $('#editprofileForm').on('submit', function (e) {
      e.preventDefault();

      var array = $(this).serializeArray(),
        isFormValid = true,
        regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/,
        phoneRegex = /^([0-9\(\)\/\+ \-]*)$/;

      // remove form input
      $('#editprofileForm .input').removeClass('is-danger');
      $('#editprofileForm .input').parent().next().addClass('hide');
      // validate each input
      if (!array[0].value) {
        $('#editprofileForm input[name=name]').addClass('is-danger');
        $('#editprofileForm input[name=name]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[1].value) {
        $('#editprofileForm input[name=family]').addClass('is-danger');
        $('#editprofileForm input[name=family]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[2].value || !regex.test(array[2].value)) {
        $('#editprofileForm input[name=email]').addClass('is-danger');
        $('#editprofileForm input[name=email]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[3].value || !phoneRegex.test(array[3].value) || array[3].value.length !== 11) {
        $('#editprofileForm input[name=phoneNumber]').addClass('is-danger');
        $('#editprofileForm input[name=phoneNumber]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (isFormValid) {
        isEditProfileFormLoading = true;
        if (isEditProfileFormLoading) {
          $('#editprofileForm .button').addClass('is-loading');
          $('#editprofileForm .button').prop('disabled', true);
        }

        var profile = JSON.stringify({
          Name: array[0].value,
          Family: array[1].value,
          Email: array[2].value,
          PhoneNumber: array[3].value,
          Id: parseInt(array[4].value),
        });

        return $.ajax({
          url: '/account/editProfile',
          type: 'PUT',
          dataType: 'json',
          contentType: 'application/json',
          data: profile,
        })
          .done(function (res) {
            $('#editprofileForm .button').removeClass('is-loading');
            $('#editprofileForm .button').prop('disabled', false);

            $.toast({
              heading: 'پروفایل با موفیقت ویرایش یافت',
              text: '',
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'success',
              hideAfter: 3500,
              stack: 6,
            });
          })
          .fail(function (err) {
            $('#editprofileForm .button').removeClass('is-loading');
            $('#editprofileForm .button').prop('disabled', false);
            $.toast({
              heading: 'خطا',
              text: !err.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : err.responseJSON.message,
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'error',
              hideAfter: 3500,
            });
          });
      }
    });

    // Change Password Form
    var ischangepasswordFormLoading = false;
    $('#changepasswordForm').on('submit', function (e) {
      e.preventDefault();

      var array = $(this).serializeArray(),
        isFormValid = true;

      // remove form input
      $('#changepasswordForm .input').removeClass('is-danger');
      $('#changepasswordForm .input').parent().next().addClass('hide');
      // validate each input
      if (!array[0].value) {
        $('#changepasswordForm input[name=currentpassword]').addClass('is-danger');
        $('#changepasswordForm input[name=currentpassword]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[1].value) {
        $('#changepasswordForm input[name=newpassword]').addClass('is-danger');
        $('#changepasswordForm input[name=newpassword]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[2].value) {
        $('#changepasswordForm input[name=retypePassword]').addClass('is-danger');
        $('#changepasswordForm input[name=retypePassword]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (array[1].value !== array[2].value) {
        $('#changepasswordForm input[name=retypePassword]').addClass('is-danger');
        $('#changepasswordForm input[name=retypePassword]').parent().next().removeClass('hide');

        isFormValid = false;
      }

      if (isFormValid) {
        ischangepasswordFormLoading = true;
        if (ischangepasswordFormLoading) {
          $('#changepasswordForm .button').addClass('is-loading');
          $('#changepasswordForm .button').prop('disabled', true);
        }
        var password = JSON.stringify({
          OldPassword: array[0].value,
          NewPassword: array[1].value,
        });

        return $.ajax({
          url: '/profileApi/changePassword',
          type: 'PUT',
          dataType: 'json',
          contentType: 'application/json',
          data: password,
        })
          .done(function (res) {
            $('#changepasswordForm .button').removeClass('is-loading');
            $('#changepasswordForm .button').prop('disabled', false);
            $('#changepasswordForm')[0].reset();
            $.toast({
              heading: 'رمز عبور شما با موفقیت تغییر یافت',
              text: '',
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'success',
              hideAfter: 3500,
              stack: 6,
            });
          })
          .fail(function (err) {
            $('#changepasswordForm .button').removeClass('is-loading');
            $('#changepasswordForm .button').prop('disabled', false);
            $.toast({
              heading: 'خطا',
              text: !err.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : err.responseJSON.message,
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'error',
              hideAfter: 3500,
            });
          });
      }
    });

    // Add Address Form
    var isaddAddressFormLoading = false;
    $('#addAddressForm').on('submit', function (e) {
      e.preventDefault();

      var array = $(this).serializeArray(),
        isFormValid = true;

      // remove form input
      $('#addAddressForm .input').removeClass('is-danger');
      $('#addAddressForm .input').parent().next().addClass('hide');
      // validate each input
      if (!array[0].value) {
        $('#addAddressForm input[name=name]').addClass('is-danger');
        $('#addAddressForm input[name=name]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[1].value && array[1].value.length !== 11) {
        $('#addAddressForm input[name=tel]').addClass('is-danger');
        $('#addAddressForm input[name=tel]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[2].value && array[2].value.length !== 10) {
        $('#addAddressForm input[name=postalCode]').addClass('is-danger');
        $('#addAddressForm input[name=postalCode]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[3].value) {
        $('#addAddressForm input[name=address]').addClass('is-danger');
        $('#addAddressForm input[name=address]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (isFormValid) {
        isaddAddressFormLoading = true;
        if (isaddAddressFormLoading) {
          $('#addAddressForm .button').addClass('is-loading');
          $('#addAddressForm .button').prop('disabled', true);
        }

        var address = JSON.stringify({
          Name: array[0].value,
          Mobile: array[1].value,
          PostalCode: array[2].value,
          Address: array[3].value,
          Description: array[4].value,
        });

        return $.ajax({
          url: '/profileApi/addAddress',
          type: 'POST',
          dataType: 'json',
          contentType: 'application/json',
          data: address,
        })
          .done(function (res) {
            $('#addAddressForm .button').removeClass('is-loading');
            $('#addAddressForm .button').prop('disabled', false);
            $.toast({
              heading: 'آدرس شما با موفیقت افزوده شد',
              text: '',
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'success',
              hideAfter: 2000,
              stack: 6,
            });

            setTimeout(function () {
              window.location.href = '/profile/myAddressList/';
            }, 2000);
          })
          .fail(function (err) {
            $('#addAddressForm .button').removeClass('is-loading');
            $('#addAddressForm .button').prop('disabled', false);
            $.toast({
              heading: 'خطا',
              text: !err.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : err.responseJSON.message,
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'error',
              hideAfter: 3500,
            });
          });
      }
    });

    var iseditAddressFormLoading = false;
    $('#editAddressForm').on('submit', function (e) {
      e.preventDefault();

      var array = $(this).serializeArray(),
        isFormValid = true;

      // remove form input
      $('#editAddressForm .input').removeClass('is-danger');
      $('#editAddressForm .input').parent().next().addClass('hide');
      // validate each input
      if (!array[0].value) {
        $('#editAddressForm input[name=name]').addClass('is-danger');
        $('#editAddressForm input[name=name]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[1].value && array[1].value.length !== 11) {
        $('#editAddressForm input[name=tel]').addClass('is-danger');
        $('#editAddressForm input[name=tel]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[2].value && array[2].value.length !== 10) {
        $('#editAddressForm input[name=postalCode]').addClass('is-danger');
        $('#editAddressForm input[name=postalCode]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (!array[3].value) {
        $('#editAddressForm input[name=address]').addClass('is-danger');
        $('#editAddressForm input[name=address]').parent().next().removeClass('hide');
        isFormValid = false;
      }

      if (isFormValid) {
        iseditAddressFormLoading = true;
        if (iseditAddressFormLoading) {
          $('#editAddressForm .button').addClass('is-loading');
          $('#editAddressForm .button').prop('disabled', true);
        }

        var address = JSON.stringify({
          Name: array[0].value,
          Mobile: array[1].value,
          PostalCode: array[2].value,
          Address: array[3].value,
          Description: array[4].value,
          id: parseInt(array[5].value),
        });

        return $.ajax({
          url: '/profileApi/editAddress',
          type: 'put',
          dataType: 'json',
          contentType: 'application/json',
          data: address,
        })
          .done(function (res) {
            $('#editAddressForm .button').removeClass('is-loading');
            $('#editAddressForm .button').prop('disabled', false);
            $.toast({
              heading: 'آدرس شما با موفیقت ویرایش یافت',
              text: '',
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'success',
              hideAfter: 2000,
              stack: 6,
            });

            setTimeout(function () {
              window.location.href = '/profile/myAddressList/';
            }, 2000);
          })
          .fail(function (err) {
            $('#editAddressForm .button').removeClass('is-loading');
            $('#editAddressForm .button').prop('disabled', false);
            $.toast({
              heading: 'خطا',
              text: !err.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : err.responseJSON.message,
              position: 'top-right',
              loaderBg: '#ff6849',
              icon: 'error',
              hideAfter: 3500,
            });
          });
      }
    });

    // Address
    $('.address-container .address-items').on('click', '.remove-btn', function (e) {
      e.preventDefault();
      var id = $(this).attr('data-id');
      var modalTemplate = "<div data-type='5' class='modal-container active'><div class='content'><h2>حذف آدرس</h2>";
      modalTemplate += '<p>آیا مطمئن به حذف این آدرس هستید؟</p>';
      modalTemplate += "<div class='footer'><button data-id=" + id + " class='submit-btn'>باشه</button><button class='danger-btn'>خیر</button></div></div></div>";
      $('html').append(modalTemplate);
    });

    $(document).on('click', '.modal-content .dismiss-btn', function (e) {
      $('.address-modal').removeClass('active');
    });

    $(document).on('click', '.modal-container .danger-btn', function (e) {
      $('.modal-container').removeClass('active');
    });

    $(document).on('click', '.modal-container .submit-btn', function (e) {
      var type = $('.modal-container').attr('data-type');
      $('.modal-container').remove();
      switch (Number(type)) {
        case 0:
          window.location.replace('/profile/logout');
          return window.location.forward(1);
        case 1:
          ajaxInstance('/api/remove?id=' + $(this).attr('data-id'), 'DELETE', {})
            .done(function (res) {
              console.log(res);
            })
            .fail(function (err) {
              console.log(err);
            });
        case 3:
          var id = $(this).attr('data-id');
          console.log(id);
          ajaxInstance('/site/DeleteFromCart/' + parseInt(id), 'DELETE', {})
            .done(function (res) {
              $.toast({
                heading: 'ایتم با موفقیت از سبد شما حذف شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6,
              });
              if (res.basketCount === 0) {
                window.location.reload();
              } else {
                $('#cartTable tr[data-id=' + id + ']').remove();
                $('.cart-container .total-invoice span').text(res.totalPrice.toLocaleString() + 'ریال ');
                $('header .badge').text(res.basketCount);
              }
            })
            .fail(function (err) {
              return $.toast({
                heading: 'خطا',
                text: !err.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : err.responseJSON.message,
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500,
              });
            });
          break;

        case 5:
          var id = $(this).attr('data-id');
          $.ajax({
            url: '/ProfileApi/deleteAddress/' + id,
            type: 'Delete',
            dataType: 'json',
            contentType: 'application/json',
            success: function () {
              $('.address-container .address-items[data-id=' + id + ']').remove();
              $.toast({
                heading: 'آدرس شما با حذف شد',
                text: '',
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 2000,
                stack: 6,
              });
            },
            error: function () {
              $.toast({
                heading: 'خطا',
                text: !error.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : error.responseJSON.message,
                position: 'top-right',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500,
              });
            },
          });
          break;
        default:
          return null;
      }
    });

    // Remove Order
    $('#removeOrder').click(function (e) {
      e.preventDefault();
      var id = $(this).parent().parent().attr('data-id');
      var modalTemplate = "<div data-type='1' class='modal-container active'><div class='content'><h2>خروج از سیستم</h2>";
      modalTemplate += '<p>آیا مایل به خروج از سیستم هستید ؟</p>';
      modalTemplate += "<div class='footer'><button data-id=" + id + " class='submit-btn'>باشه</button><button class='danger-btn'>خیر</button></div></div></div>";
      $('html').append(modalTemplate);
    });

    // Remove Product
    $('#cartTable').on('click', '.remove-product', function (e) {
      var id = $(this).closest('tr').attr('data-id');
      var modalTemplate = "<div data-type='3' class='modal-container active'><div class='content'><h2>حذف محصول</h2>";
      modalTemplate += '<p>آیا مایل به حذف این آیتم هستید ؟</p>';
      modalTemplate += "<div class='footer'><button data-id=" + id + " class='submit-btn'>باشه</button><button class='danger-btn'>خیر</button></div></div></div>";
      $('html').append(modalTemplate);
    });

    // Logout
    $('#logoutBtn').click(function (e) {
      e.preventDefault();
      $('.modal-container').addClass('active');
      var modalTemplate = "<div data-type='0' class='modal-container active'><div class='content'><h2>خروج از سیستم</h2>";
      modalTemplate += '<p>آیا مایل به خروج از سیستم هستید؟</p>';
      modalTemplate += "<div class='footer'><button class='submit-btn'>باشه</button><button class='danger-btn'>خیر</button></div></div></div>";
      $('html').append(modalTemplate);
    });

    //remove Address
    $('.address-container .address-items').on('click', '.remove-btn', function (e) {
      e.preventDefault();
      var id = $(this).attr('data-id');
      var modalTemplate = "<div data-type='5' class='modal-container active'><div class='content'><h2>حذف آدرس</h2>";
      modalTemplate += '<p>آیا مطمئن به حذف این آدرس هستید؟</p>';
      modalTemplate += "<div class='footer'><button data-id=" + id + " class='submit-btn'>باشه</button><button class='danger-btn'>خیر</button></div></div></div>";
      $('html').append(modalTemplate);
    });

    // Payment Method
    $('.checkout-container .payment-method .item').click(function (e) {
      $('.checkout-container .payment-method .item').removeClass('active');
      $(this).addClass('active');
    });

    // Sticky News Sidebar
    var sidebarWidth = $('.inner-news__container .sidebar').width();
    var contentHeight = $('.inner-news__container .content').height();
    $(window).scroll(function () {
      if ($(window).width() > 1024) {
        var scrollTop = $('main')[0].offsetTop;
        if ($(window).scrollTop() >= scrollTop && contentHeight > scrollTop) {
          $('.inner-news__container .sidebar').css({
            position: 'fixed',
            top: '0',
            left: ($('html').width() - $('.inner-news__container').width()) / 2 + 'px',
            width: sidebarWidth,
          });
        } else {
          $('.inner-news__container .sidebar').removeAttr('style');
        }
      }
    });

    //PRODUCT SLIDER/THUMBNAIL
    if ($('#productSlider').length > 0) {
      $('#productSlider').flexslider({
        animation: 'slide',
        controlNav: false,
        animationLoop: false,
        slideshow: false,
        itemWidth: 210,
        itemMargin: 5,
        rtl: true,
        asNavFor: '#productSlider',
      });
    }

    // Add To Cart
    $('.products-container .row .items .btn-container').on('click', '.shop-icon', function (e) {
      let productId = $(this).attr('data-id');
      var customDate = JSON.stringify({
        productVariantId: parseInt(productId),
        count: 1,
      });
      $.ajax({
        url: '/site/addToCart/',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        data: customDate,
      })
        .done((data) => {
          $('#basketCount').html(data.basketCount);

          $('#basketprice').html(`${data.totalPrice.toLocaleString()} تومان`);
          $.toast({
            heading: 'محصول مورد نظر به سبد خرید شما افزوده شد',
            text: '',
            position: 'top-right',
            loaderBg: '#ff6849',
            icon: 'success',
            hideAfter: 2000,
            stack: 6,
          });
        })
        .fail((err) => {
          $.toast({
            heading: 'خطا',
            text: !error.responseJSON ? 'در ارسال پیام شما مشکلی به وجود آمده است.' : error.responseJSON.message,
            position: 'top-right',
            loaderBg: '#ff6849',
            icon: 'error',
            hideAfter: 3500,
          });
        });
    });

    $('.single-product').on('click', '.stepper-minus', function (e) {
      var value = $('.single-product .stepper-value input').val();
      if (value > 1) {
        var value = $('.single-product .stepper-value input').val();
        count = Number(value) - 1;
        $('.single-product .stepper-value input').val(count);
      }
    });

    $('.single-product').on('click', '.stepper-plus', function (e) {
      var value = $('.single-product .stepper-value input').val();
      count = Number(value) + 1;
      $('.single-product .stepper-value input').val(count);
    });

    $('.single-product').on('keyup', '.stepper-value input', function (e) {
      count = Number($(this).val());
    });

    $('.menu-btn').on('click', function (e) {
      if ($('.close-btn').length > 0) {
        var template = '<div class="close-btn"></div>';
        $('header nav').append(template);
      }
      $('header nav').addClass('active');
    });

    $('header').on('click', '.close-btn', function (e) {
      $('header nav').removeClass('active');
    });
  });
});

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {

    $("#ddlRole").change(function () {
        if ($(this).val() === "Specialist") {
            $(this).parent().next().removeClass("hidden");

            $(".reg-field").slideUp();        }
        else {
            $(this).parent().next().addClass("hidden");

            $(".reg-field").slideDown();
        }
    });

    $("#register-form").bootstrapValidator({
    }).on("success.form.bv", function (e) {

    });

});


function cancelRegLogin() {
    window.location = new URLSearchParams(location.search).get('returnUrl');
}

function cancelLogin() {
    window.location = $("#hdnReturn").val();
}
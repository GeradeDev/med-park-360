// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$medpark_api = "http://localhost:62683/api/";

$(document).ready(function() {

    GetApiEndpoint();

    NavScrolling();

    $("#btnShowEdit").click(function () {
        $(this).prev().prev().hide();
        $(this).prev().show();
        $(this).hide();
    });
    
    $("#btnCancelSave").click(function () {
        $(this).parent().prev().show();
        $(this).parent().hide();
        $("#btnShowEdit").show();
    });

});

function GetApiEndpoint() {
    $.ajax({
        url: $medpark_api.replace("/api/", ""),
        success: function(result) {
            if (result.length !== "") {
                console.log("API is up");
            }

        }, error: function() {
            $medpark_api = 'http://localhost:62683/';
        }
    });
}

function NavScrolling() {

     // Smooth scrolling using jQuery easing
    $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: (target.offset().top - 54)
                }, 1000, "easeInOutExpo");
                return false;
            }
        }
    });

    // Closes responsive menu when a scroll trigger link is clicked
    $('.js-scroll-trigger').click(function () {
        $('.navbar-collapse').collapse('hide');
    });

    // Activate scrollspy to add active class to navbar items on scroll
    $('body').scrollspy({
        target: '#mainNav',
        offset: 56
    });

    // Collapse Navbar
    var navbarCollapse = function () {
        if ($("#mainNav").offset().top > 100) {
            $("#mainNav").addClass("navbar-shrink");
        } else {
            $("#mainNav").removeClass("navbar-shrink");
        }
    };
    // Collapse now if page is not at top
    navbarCollapse();
    // Collapse the navbar when page is scrolled
    $(window).scroll(navbarCollapse);

}

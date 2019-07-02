// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$medpark_api = "http://localhost:62683/api/";


$(document).ready(function() {

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

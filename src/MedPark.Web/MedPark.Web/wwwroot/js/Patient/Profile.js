
$(document).ready(function () {



});


function GetAddresses(){

    $.ajax({
        url: $customers_api + "/getaddresses/",
        success: function (result) {
            $("#div1").html(result);
        }
    });
}
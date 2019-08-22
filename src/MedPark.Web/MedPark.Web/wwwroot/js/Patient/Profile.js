
var appointmentTypes = [];

$(document).ready(function () {

    $("#customer-details-form").bootstrapValidator({
    }).on("success.form.bv", function (e) {
        e.preventDefault();
    });

    $("#btnUpdateCustomer").click(function () {
        UpdateCustomerDetails();
    });

    $('#BirthDate').datepicker({
        format: 'mm/dd/yyyy'
    });

    //GetAddresses();

    GetCustomerAppointments();

    LoadAppointmentTypes();
});

function GetAddresses(){

    $.ajax({
        url: $medpark_api + "customers/GetAddreses/" + userId,
        success: function (result) {
            $("#div1").html(result);
        }
    });
}


function UpdateCustomerDetails() {
    if ($("#customer-details-form").data("bootstrapValidator").validate()) {

        var details = JSON.stringify(new GetCustomerProfileUpdate());

        $.ajax({
            url: $medpark_api + "customers/UpdateCustomer/",
            type: 'POST',
            contentType: 'application/json',
            data: details,
            success: function (result) {

            }
        });
    }
}

function GetCustomerProfileUpdate() {
    this.FirstName = $("#FirstName").val();
    this.LastName = $("#LastName").val();
    this.Email = $("#Email").val();
    this.Mobile = $("#Mobile").val();
    this.DOB = $("#BirthDate").val();
    this.Id = userId;
}


function GetCustomerAppointments() {
    $.ajax({
        url: $medpark_api + "bookings/getpatientappointments/" + userId,
        success: function (result) {
            
        }
    });
}

function LoadAppointmentTypes() {
    $.ajax({
        url: $medpark_api + "specialist/appointmenttypes/",
        success: function (result) {
            appointmentTypes = result;

            $.each(appointmentTypes, function (key, value) {
                $("#ddlAppointmentType").append(new Option(value.name, value.Id));
            });
        }
    });
    
}
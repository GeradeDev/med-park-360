
var appointmentTypes = [];

$(document).ready(function () {

    $("#customer-details-form").bootstrapValidator({
    }).on("success.form.bv", function (e) {
        e.preventDefault();
    });

    $("#btnUpdateCustomer").click(function () {
        UpdateCustomerDetails();
    });

    $('#BirthDate, #appointmentDate').datepicker({
        format: 'mm/dd/yyyy'
    });

    //GetAddresses();

    GetCustomerAppointments();

    LoadAppointmentTypes();

    $("#ddlAppointmentType").change(function () {
        LoadSpecialistByAppointmentTypes($("#ddlAppointmentType").val());
    });

    $("#ddlSpecialists").change(function () {
        GerSpecialistPracticeDetails($("#ddlSpecialists option:selected").attr("prac"));
    });
        
    $("#ddlPracticeSchemes").change(function () {
        if ($(this).val() === "")
            $("#MedAidNo").val("").attr("disabled", "disabled");
        else
            $("#MedAidNo").removeAttr("disabled");
    });
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
                $("#ddlAppointmentType").append(new Option(value.name, value.id));
            });
        }
    });
}

function LoadSpecialistByAppointmentTypes(appTypeId) {
    $.ajax({
        url: $medpark_api + "specialist/specialistsLinkedToAppointmentType/" + appTypeId,
        success: function (result) {

            $.each(result.specilists, function (key, value) {
                var o = new Option(value.firstName + " " + value.surname, value.id);
                o.setAttribute("prac", value.practiceId);

                $("#ddlSpecialists").append(o);
            });
        }
    });
}

function GerSpecialistPracticeDetails(practiceId) {
    $.ajax({
        url: $medpark_api + "specialist/getacceptedschemes/" + practiceId,
        success: function (result) {

            if (result.length > 0) {

                ShowMedSchemes();

                $.each(result, function (key, value) {
                    $("#ddlPracticeSchemes").append(new Option(value.schemeName, value.id));
                });
            }
            else {
                HideMedSchemes();
            }
        }
    });
}

function ShowMedSchemes() {
    $("#addSchemeBooking").show();
}

function HideMedSchemes() {
    $("#addSchemeBooking").hide();
}
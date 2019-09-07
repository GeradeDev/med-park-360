﻿
var appointmentTypes = [];
var availableTimes = [];

$(document).ready(function () {

    $("#customer-details-form").bootstrapValidator({
    }).on("success.form.bv", function (e) {
        e.preventDefault();
    });

    $("#btnUpdateCustomer").click(function () {
        UpdateCustomerDetails();
    });

    $("#btnSubmitAppointment").click(function () {
        SubmitNewAppointment();
    });

    $('#BirthDate').datepicker({
        format: 'mm/dd/yyyy'
    });

    $('#appointmentDate').datepicker({
        format: 'mm/dd/yyyy'
    }).on('changeDate', function (ev) {

        $("#ddlAppointmentTime").find('option').remove().end();

        var dayName = moment(new Date($(this).val())).format('dddd');
        var times = _.find(availableTimes, function (d) { return d.dayOfWeek === dayName; });

        if (times.availableTimes.length > 0) {

            $.each(times.availableTimes, function (key, value) {
                $("#ddlAppointmentTime").append(new Option(value, value));
            });

            $("#bookingTime").show();
        }
    });

    //GetAddresses();

    GetCustomerAppointments();

    LoadAppointmentTypes();

    $("#ddlAppointmentType").change(function () {
        LoadSpecialistByAppointmentTypes($("#ddlAppointmentType").val());
    });

    $("#ddlSpecialists").change(function () {
        GerSpecialistPracticeDetails($("#ddlSpecialists option:selected").attr("prac"));

        LoadSpecialistAvailableTimes($(this).val());
    });
        
    $("#ddlPracticeSchemes").change(function () {
        if ($(this).val() === "")
            $("#medAidNo").val("").attr("disabled", "disabled");
        else
            $("#medAidNo").removeAttr("disabled");
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

            $("#ddlSpecialists").find('option').remove().end();

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
        url: $medpark_api + "specialist/getacceptedschemes/"  + practiceId,
        success: function (result) {
            if (result.length > 0) {

                $("#ddlPracticeSchemes").find('option').remove().end();

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

function LoadSpecialistAvailableTimes(specialistId) {
    $.ajax({
        url: $medpark_api + "specialist/specialistOperatingHours/" + specialistId,
        success: function (result) {
            availableTimes = result.appointmentTimes;
        }
    });
}


function SubmitNewAppointment() {
    var details = JSON.stringify(new NewAppointmentRequest());

    $.ajax({
        url: $medpark_api + "bookings/addappointment/",
        type: 'POST',
        contentType: 'application/json',
        data: details,
        success: function (result) {
            $("#addAppointmentModal").modal("hide");
            ClearNewAppointment();
        }
    });
}

function NewAppointmentRequest() {
    this.PatientId = userId;
    this.SpecialistId = $("#ddlSpecialists").val();
    this.AppointmentType = $("#ddlAppointmentType").val();
    this.MedicalAidMembershipNo = $("#medAidNo").val();
    this.ScheduledDate = moment($("#appointmentDate").val() + " " + $("#ddlAppointmentTime").val()).toDate();
    this.Comment = $("#additionalDetails").val();
    this.MedicalScheme = $("#ddlPracticeSchemes").val();
}

function ClearNewAppointment() {
    $("#ddlSpecialists").val("");
    $("#ddlAppointmentType").val("");
    $("#medAidNo").val("");
    $("#appointmentDate").val("");
    $("#ddlAppointmentTime").val("");
    $("#additionalDetails").val("");
}



function ShowMedSchemes() {
    $("#addSchemeBooking").show();
}

function HideMedSchemes() {
    $("#addSchemeBooking").hide();
}

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

    LoadUpcomingAppointments();

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
            $("#ddlSpecialists").append(new Option("Select Specialist","" ));

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
                $("#ddlPracticeSchemes").append(new Option("Select Medical Aid Option","" ));

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

function LoadUpcomingAppointments() {
    $.ajax({
        url: $medpark_api + "bookings/getpatientappointments/" + userId,
        success: function (result) {

            $("#tblAppointments tbody").remove();

            var today = _.filter(result.bookingDetails, function (e) {
                return moment(e.scheduledDate).format("YYYY MM DD") === moment().format("YYYY MM DD");
            });

            var tomorrow = _.filter(result.bookingDetails, function (e) {
                return moment(e.scheduledDate).format("YYYY MM DD") === moment().add(1, 'days').format("YYYY MM DD");
            });

            if (today.length === 0 && tomorrow.length === 0) {
                $('#tblAppointments').append($('<tr>')
                    .append($('<td>').append(NoAppointmentsForDay()))
                    .append($('<td>').append(NoAppointmentsForDay())));
            }
            else if (today.length > 0 && tomorrow.length === 0) {
                $('#tblAppointments').append($('<tr>')
                    .append($('<td>').append(CreateAppointmentItem(today)))
                    .append($('<td>').append(NoAppointmentsForDay())));
            }
            else if (today.length === 0 && tomorrow.length > 0) {
                $('#tblAppointments').append($('<tr>')
                    .append($('<td>').append(NoAppointmentsForDay()))
                    .append($('<td>').append(CreateAppointmentItem(tomorrow))));
            }
            else {
                $('#tblAppointments').append($('<tr>')
                    .append($('<td>').append(CreateAppointmentItem(today)))
                    .append($('<td>').append(CreateAppointmentItem(tomorrow))));
            }

            $(".booked-app").click(function (sender) {
                LoadAppointmentDetails($(this).attr("appid"));
                $("#appointmentDetail").modal("show");
            });
        }
    });
}

function CreateAppointmentItem(dayAppointments) {
    var item = "";

    for (var i = 0; i < dayAppointments.length; i++) {
        item = '<div class="p-2 shadow-sm rounded d-block mb-2 booked-app" appid="' + dayAppointments[i].id +'">' + dayAppointments[i].title + " " + dayAppointments[i].specialistInitials + " " + dayAppointments[i].specialistSurname + " - " + moment(moment.utc(dayAppointments[i].scheduledDate).toDate()).format('MMMM Do YYYY, h:mm:ss a') + '</div>';
    }

    return item;
}

function NoAppointmentsForDay() {
    return '<div class="p-2 shadow-sm rounded d-block mb-2">No appointment(s) scheduled for today</div>';
}


function LoadAppointmentDetails(appId) {
    $.ajax({
        url: $medpark_api + "bookings/" + appId + "/details/",
        success: function (result) {

            $(".loader").hide();
            $("#h4SpecialistName").text(result.specialistTitle + " " + result.specialistName + " " + result.specialistSurname);

            $("#lblAppType").text(result.appointmentType);
            $("#lblSchemeName").text(result.medicalScheme + " - " + result.medicalAidMembershipNo);
            $("#lblAppDate").text(moment(moment.utc(result.scheduledDate).toDate()).format('MMMM Do YYYY, h:mm:ss a'));
            $("#txtAppComments").text(result.comment);

            $("#lblSpecilaistName").text(result.specialistName + " " + result.specialistSurname);
            $("#lblPracticeName").text(result.practice.practiceName);
            $("#lblPracticeContactNo").text(result.specialistTel);
            $("#lblSpecialistEmail").text(result.specialistEmail);
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

            LoadUpcomingAppointments();

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
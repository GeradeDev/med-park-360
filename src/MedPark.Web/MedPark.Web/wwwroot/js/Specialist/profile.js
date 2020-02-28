
var selectedPractice;
var selectedPracticeHoursId;

$(document).ready(function () {

    $("#btnUpdateSpecialist").click(function () {
        UpdateSpecialistDetails();
    });

    $(".prac-details").click(function () {
        LoadPracticeDetails($(this).attr("practice-id"));
    });

    $("#btnDoneHourUpdate").click(function () {
        SetDayOperatingHours($(this).attr("day"));
    });

    $("#btnSubmitPracticeUpdate").click(function () {


        if (selectedPracticeHoursId === undefined)
            SubmitPracticeHours();
        else
            UpdatePracticeHours();
    });

    LoadAppointmentTypes();

    GetSpecialistAppointments();
});


function UpdateSpecialistDetails() {

    var details = JSON.stringify(new SpecialistDetails());

    $.ajax({
        url: $medpark_api + "specialist/update/",
        type: 'POST',
        contentType: 'application/json',
        data: details,
        success: function (result) {

        }
    });
}

function GetSpecialistAppointments() {
    $.ajax({
        url: $medpark_api + "bookings/getspecialistappointments/" + specialistId,
        success: function (result) {

            $("#tblSpecialistBookings tbody").remove();

            var today = _.filter(result.bookingDetails, function (e) {
                return moment(e.scheduledDate).format("YYYY MM DD") === moment().format("YYYY MM DD");
            });

            var tomorrow = _.filter(result.bookingDetails, function (e) {
                return moment(e.scheduledDate).format("YYYY MM DD") === moment().add(1, 'days').format("YYYY MM DD");
            });

            if (today.length === 0 && tomorrow.length === 0) {
                $('#tblSpecialistBookings').append($('<tr>')
                    .append($('<td>').append(NoAppointmentsForDay()))
                    .append($('<td>').append(NoAppointmentsForDay())));
            }
            else if (today.length > 0 && tomorrow.length === 0) {
                $('#tblSpecialistBookings').append($('<tr>')
                    .append($('<td>').append(CreateAppointmentItem(today)))
                    .append($('<td>').append(NoAppointmentsForDay())));
            }
            else if (today.length === 0 && tomorrow.length > 0) {
                $('#tblSpecialistBookings').append($('<tr>')
                    .append($('<td>').append(NoAppointmentsForDay()))
                    .append($('<td>').append(CreateAppointmentItem(tomorrow))));
            }
            else {
                $('#tblSpecialistBookings').append($('<tr>')
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
        item = '<div class="p-2 shadow-sm rounded d-block mb-2 booked-app" appid="' + dayAppointments[i].id + '">' + dayAppointments[i].firstName + " " + dayAppointments[i].lastName + " - " + moment(moment.utc(dayAppointments[i].scheduledDate).toDate()).format('MMMM Do YYYY, h:mm:ss a') + '</div>';
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

function LoadAppointmentTypes() {
    $.ajax({
        url: $medpark_api + "specialist/appointmenttypes/",
        success: function (result) {
            appointmentTypes = result;

            $.each(appointmentTypes, function (key, value) {
                $("#ddlAppointmentType").append(new Option(value.name, value.id));
            });

            LoadLinkedAppointmentTypes();
        }
    });
}

function LoadLinkedAppointmentTypes() {
    $.ajax({
        url: $medpark_api + "specialist/appointmenttypes/" + specialistId,
        success: function (result) {
            if (result.typesLinkedToSpecilaist.length > 0)
                $("#ddlAppointmentType").val(result.typesLinkedToSpecilaist[0].id);
        }
    });
}

function SpecialistDetails() {
    this.Id = specialistId;
    this.FirstName = $("#FirstName").val();
    this.Surname = $("#LastName").val();
    this.Email = $("#Email").val();
    this.Cellphone = $("#SpecilaistCell").val();
    this.Title = $("#Title").val();
}


function LoadPracticeDetails(practiceid) {
    $.ajax({
        url: $medpark_api + "specialist/getpractice/" + practiceid,
        success: function (result) {
            $("#PracName").val(result.practiceName);
            $("#PracEmail").val(result.email);
            $("#PPhone").val(result.telephonePrimary);
            $("#SPhone").val(result.telephoneSecondary);
            $("#Website").val(result.website);

            LoadPracticeOperatingHours(practiceid);

            $(".loader").hide();
        }
    });
}

function LoadPracticeOperatingHours(practiceid) {
    $.ajax({
        url: $medpark_api + "specialist/specialistpracticeHours/" + practiceid + "/" + specialistId,
        success: function (result) {

            $(".hours-container").append("<a class='btn btn-primary text-uppercase operating-hour mr-3 col-sm-2' href='#' id='MondayHours' onClick='ShowOperatingHoursUpdate(\"monday\")'>Monday : " + (result !== undefined ? result.mondayOpen : '--') + " - " + (result !== undefined ? result.mondayClose : '--') + "</a>");
            $(".hours-container").append("<a class='btn btn-primary text-uppercase operating-hour mr-3 col-sm-2' href='#' id='TuesdayHours' onClick='ShowOperatingHoursUpdate(\"tuesday\")'>Tuesday : " + (result !== undefined ? result.tuesdayOpen : '--') + " - " + (result !== undefined ? result.tuesdayClose : '--') + "</a>");
            $(".hours-container").append("<a class='btn btn-primary text-uppercase operating-hour mr-3 col-sm-2' href='#' id='WednesdayHours' onClick='ShowOperatingHoursUpdate(\"wednesday\")'>Wednesday : " + (result !== undefined ? result.wednesdayOpen : '--') + " - " + (result !== undefined ? result.wednesdayClose : '--') + "</a>");
            $(".hours-container").append("<a class='btn btn-primary text-uppercase operating-hour mr-3 col-sm-2' href='#' id='ThursdayHours' onClick='ShowOperatingHoursUpdate(\"thursday\")'>Thursday : " + (result !== undefined ? result.thursdayOpen : '--') + " - " + (result !== undefined ? result.thursdayClose : '--') + "</a>");
            $(".hours-container").append("<a class='btn btn-primary text-uppercase operating-hour mr-3 col-sm-2' href='#' id='FridayHours' onClick='ShowOperatingHoursUpdate(\"friday\")'>Friday : " + (result !== undefined ? result.fridayOpen : '--') + " - " + (result !== undefined ? result.fridayClose : '--') + "</a>");
            $(".hours-container").append("<a class='btn btn-primary text-uppercase operating-hour mr-3 mt-2 col-sm-2' href='#' id='SaturdayHours' onClick='ShowOperatingHoursUpdate(\"saturday\")'>Saturday : " + (result !== undefined ? result.saturdayOpen : '--') + " - " + (result !== undefined ? result.saturdayClose : '--') + "</a>");
            $(".hours-container").append("<a class='btn btn-primary text-uppercase operating-hour mr-3 mt-2 col-sm-2' href='#' id='SundayHours' onClick='ShowOperatingHoursUpdate(\"sunday\")'>Sunday : " + (result !== undefined ? result.sundayOpen : '--') + " - " + (result !== undefined ? result.sundayClose : '--') + "</a>");

            $(".loader").hide();

            selectedPractice = practiceid;

            if (result !== undefined)
                selectedPracticeHoursId = result.id;
        }
    });
}

function ShowOperatingHoursUpdate(day) {
    $("." + day + "-hours").removeClass("hide");
    $("#btnDoneHourUpdate").show();
    $("#btnDoneHourUpdate").attr("day", day);
}

function SetDayOperatingHours(day) {

    switch (day) {
        case "monday":
            $("#MondayHours").text("Monday : " + $("#hrsMonOpen").val() + " - " + $("#hrsMonClose").val());
            break;
        case "tuesday":
            $("#TuesdayHours").text("Tuesday : " + $("#hrsTueOpen").val() + " - " + $("#hrsTueClose").val());
            break;
        case "wednesday":
            $("#WednesdayHours").text("Wednesday : " + $("#hrsWedOpen").val() + " - " + $("#hrsWedClose").val());
            break;
        case "thursday":
            $("#ThursdayHours").text("Thursday : " + $("#hrsThuOpen").val() + " - " + $("#hrsThuClose").val());
            break;
        case "friday":
            $("#FridayHours").text("Friday : " + $("#hrsFriOpen").val() + " - " + $("#hrsFriClose").val());
            break;
        case "saturday":
            $("#SaturdayHours").text("Saturday : " + $("#hrsSatnOpen").val() + " - " + $("#hrsSatClose").val());
            break;
        case "sunday":
            $("#SundayHours").text("Sunday : " + $("#hrsSunOpen").val() + " - " + $("#hrsSunClose").val());
            break;
    }

    $("#btnDoneHourUpdate").hide();
    $("." + day + "-hours").addClass("hide");
}

function GetOperatingHoursUpdate(pid) {
    this.Id = selectedPracticeHoursId;
    this.PracticeId = pid;
    this.SpecialistId = specialistId;

    this.MondayOpen = $("#hrsMonOpen").val();
    this.MondayClose = $("#hrsMonClose").val();
    this.TuesdayOpen = $("#hrsTueOpen").val();
    this.TuesdayClose = $("#hrsTueClose").val();
    this.WednesdayOpen = $("#hrsWedOpen").val();
    this.WednesdayClose = $("#hrsWedClose").val();
    this.ThursdayOpen = $("#hrsThuOpen").val();
    this.ThursdayClose = $("#hrsThuClose").val();
    this.FridayOpen = $("#hrsFriOpen").val();
    this.FridayClose = $("#hrsFriClose").val();
    this.SaturdayOpen = $("#hrsSatnOpen").val();
    this.SaturdayClose = $("#hrsSatClose").val();
    this.SundayOpen = $("#hrsSunOpen").val();
    this.SundayClose = $("#hrsSunClose").val();
}

function SubmitPracticeHours() {

    var hours = JSON.stringify(new GetOperatingHoursUpdate(selectedPractice));

    $.ajax({
        url: $medpark_api + "specialist/setpracticeoperatinghours/",
        type: 'POST',
        contentType: 'application/json',
        data: hours,
        success: function (result) {
        }
    });
}

function UpdatePracticeHours() {

    var hours = JSON.stringify(new GetOperatingHoursUpdate(selectedPractice));

    $.ajax({
        url: $medpark_api + "specialist/updateoperatinghours/",
        type: 'POST',
        contentType: 'application/json',
        data: hours,
        success: function (result) {
        }
    });
}
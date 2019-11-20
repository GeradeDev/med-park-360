

$(document).ready(function () {

    $("#btnUpdateSpecialist").click(function () {
        UpdateSpecialistDetails();
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
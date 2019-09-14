

$(document).ready(function () {

    $("#btnUpdateSpecialist").click(function () {
        UpdateSpecialistDetails();
    });
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

function SpecialistDetails() {
    this.Id = specialistId;
    this.FirstName = $("#FirstName").val();
    this.Surname = $("#LastName").val();
    this.Email = $("#Email").val();
    this.Cellphone = $("#SpecilaistCell").val();
}
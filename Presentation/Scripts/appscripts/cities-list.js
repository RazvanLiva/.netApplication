function deleteCity(cityId) {

    $.ajax({
        method: "DELETE",
        url: "/api/cities/" + cityId,

        success: function () {
        
            var cityTableRow = $("#tr_" + cityId);
            cityTableRow.remove();
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function showCityDetails(cityId) {
 
    $.ajax({
        method: "GET",
        url: "/api/cities/" + cityId,
        success: function (cityViewModel) {
 
            $("#cityDetailsModal").modal("show");

            $("#cityNameInput").val(cityViewModel.Name);

            $("#cityHospitalsInput").val(cityViewModel.HospitalsCount);

            $("#cityPersonsInput").val(cityViewModel.PersonsCount);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
$(document).ready(function () {
    $("#createCityForm").on("submit", function (event) {
   
        event.preventDefault();
        var createCityModel = {};
        createCityModel.Name = $("#cityNameInput").val();
        createCityModel.CountyId = $("#cityCounty").val();

        console.log(createCityModel);

        $.ajax({
            method: "POST",
            url: "/api/cities",
            contentType: "application/json",
            data: JSON.stringify(createCityModel),
            success: function (result) {
       
                event.currentTarget.reset();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});
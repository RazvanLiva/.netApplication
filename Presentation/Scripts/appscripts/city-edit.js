$(document).ready(function () {
    $("#editCityForm").on("submit", function (event) {

        event.preventDefault();

        var editCityModel = {};
        editCityModel.Id = $("#cityId").val();
        editCityModel.Name = $("#cityNameInput").val();
        editCityModel.CountyId = $("#cityCounty").val();

        $.ajax({
            method: "PUT",
            url: "/api/cities",
            contentType: "application/json",
            data: JSON.stringify(editCityModel),
            success: function (result) {

                alert("City updated successfully");
            },
            error: function (error) {

                console.log(error);
            }
        });
    });
});

function loadCityPersons(cityId) {
    
    $.ajax({
        method: "GET",
        url: "/api/cities/" + cityId + "/Persons",
        
        success: function (cityPersons) {
          
            var personsList = $("#personsList");
            personsList.html(""); 

            
            $.each(cityPersons, (index, person) => {
                
                personsList.append("<li class='list-group-item'>" + person.FullName + "</li>");
            });
        },

        error: function (error) {
            console.log(error);
        }
    });
}
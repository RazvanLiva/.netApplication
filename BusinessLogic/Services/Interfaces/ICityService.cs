using System;
using System.Collections.Generic;
using ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICityService
    {
        List<CityViewModel> GetAllCities();
        List<PersonViewModel> GetCityPersons(Guid cityId);
        CityViewModel GetCityById(Guid id);
        Guid InsertCity(CreateCityViewModel createCityViewModel);
        void DeleteCity(Guid cityId);
        void UpdateCity(EditCityViewModel editCityViewModel);
    }
}

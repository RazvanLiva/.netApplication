using DataAccess.Context;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace BusinessLogic.Services
{
    
    
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountyRepository _countyRepository;

        public CityService(ICityRepository cityRepository, ICountyRepository countyRepository)
        {
           
            this._cityRepository = cityRepository;
            this._countyRepository = countyRepository;
        }

   
        public List<CityViewModel> GetAllCities()
        {
            List<CityViewModel> cities = this._cityRepository.Query()
                .OrderBy(city => city.Name)
                .Select(cityEntity => new CityViewModel
                {
                    Id = cityEntity.Id,
                    Name = cityEntity.Name,
                }).ToList();

            return cities;
        }
        public List<PersonViewModel> GetCityPersons(Guid cityId)
        {
            List<PersonViewModel> cityPersons = this._cityRepository.GetCityById(cityId)
                .Persons.Select(pers => new PersonViewModel
                {
                    Id = pers.Id,
                    Age = pers.Age,
                    Email = pers.Email,
                    FirstName = pers.FirstName,
                    LastName = pers.LastName,
                    InfectedWithCovid=pers.InfectedWithCovid,
                    Recovery=pers.Recovery               
                }).ToList();

            return cityPersons;
        }

        public CityViewModel GetCityById(Guid id)
        {

            City cityEntity = this._cityRepository.GetCityById(id);

            if (cityEntity == null)
            {
                throw new InvalidOperationException($"City with id {id} not found");
            }

            return new CityViewModel
            {
                Id = cityEntity.Id,
                Name = cityEntity.Name,
                County = new CountyViewModel
                {
                    Id = cityEntity.County.Id,
                    Name = cityEntity.County.Name
                },

                Hospitals = cityEntity.Hospitals.Select(hosp => new HospitalViewModel
                {
                    Id = hosp.Id,
                    Email = hosp.Email,
                    Name = hosp.Name,
                    PhoneNumber = hosp.PhoneNumber
                }).ToList(),

                Persons = cityEntity.Persons.Select(pers => new PersonViewModel
                {
                     Id = pers.Id,
                     Age = pers.Age,
                     LastName = pers.LastName,
                     FirstName = pers.FirstName,
                     Email = pers.Email,
                     InfectedWithCovid=pers.InfectedWithCovid,
                     Recovery=pers.Recovery
                }).ToList()
            };
        }

        
        public Guid InsertCity(CreateCityViewModel createCityViewModel)
        {
        
            City cityEntity = new City
            {
                Id = Guid.NewGuid(),
#pragma warning disable CA1062 // Validate arguments of public methods
                Name = createCityViewModel.Name,
#pragma warning restore CA1062 // Validate arguments of public methods

            };

           
            County cityCounty = this._countyRepository.Query()
                    .Where(county => county.Id == createCityViewModel.CountyId)
                    .FirstOrDefault();

            cityEntity.County = cityCounty;
            this._cityRepository.AddCity(cityEntity);

            this._cityRepository.SaveChanges();
            return cityEntity.Id;
        }


        public void DeleteCity(Guid cityId)
        {
           
            City cityToDelete = this._cityRepository.Query().Where(city => city.Id == cityId).FirstOrDefault();

            if (cityToDelete == null)
            {
                throw new InvalidOperationException($"City with id {cityId} not found.");
            }

            this._cityRepository.DeleteCity(cityToDelete);
            this._cityRepository.SaveChanges();
        }
        public void UpdateCity(EditCityViewModel editCityViewModel)
        {
        
            City cityEntityToUpdate = this._cityRepository.Query().Where(city => city.Id == editCityViewModel.Id).FirstOrDefault();

            if (cityEntityToUpdate == null)
            {
#pragma warning disable CA1062 // Validate arguments of public methods
                throw new InvalidOperationException($"City with id {editCityViewModel.Id} not found.");
#pragma warning restore CA1062 // Validate arguments of public methods
            }

            cityEntityToUpdate.Name = editCityViewModel.Name;

            County cityCounty = this._countyRepository.Query()
                   .Where(county => county.Id == editCityViewModel.CountyId)
                   .FirstOrDefault();

            cityEntityToUpdate.County = cityCounty;
            this._cityRepository.SaveChanges();
        }

    }
}

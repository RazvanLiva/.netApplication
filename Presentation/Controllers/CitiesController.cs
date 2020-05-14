using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels;

namespace Presentation.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;
        public CitiesController(ICityService cityService, ICountyService countyService)
        {
            this._cityService = cityService;
            this._countyService = countyService;
        }

        [HttpGet]
        public ActionResult CitiesList()
        {
            List<CityViewModel> cities = this._cityService.GetAllCities();
            return View(cities);
        }

        [HttpGet]
        public ActionResult CreateCity()
        {
            List<CountyViewModel> allCounties = this._countyService.GetAllCounties();
            ViewBag.Counties = allCounties;

            return View();
        }

        [HttpGet]
        public ActionResult EditCity(Guid id)
        {
            CityViewModel cityViewModel = this._cityService.GetCityById(id);
            EditCityViewModel editViewModel = new EditCityViewModel
            {
                Id = cityViewModel.Id,
                Name = cityViewModel.Name,
                CountyId = cityViewModel.County.Id
            };
            List<CountyViewModel> allCounties = this._countyService.GetAllCounties();
            ViewBag.Counties = allCounties;
            return View(editViewModel);
        }
    }
}
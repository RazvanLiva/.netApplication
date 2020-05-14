using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels;

namespace Presentation.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ICityService _cityService;
        public PersonsController(IPersonService personService, ICityService cityService)
        {
            this._personService = personService;
            this._cityService = cityService;
        }

        [HttpGet]
        public ActionResult PersonsList()
        {
            List<PersonViewModel> persons = this._personService.GetAllPersons();
            return View(persons);
        }

        [HttpGet]
        public ActionResult PersonDetails(Guid id)
        {
            PersonViewModel personViewModel = this._personService.GetPersonDetails(id);
            return View(personViewModel);
        }

        [HttpGet]
        public ActionResult EditPerson(Guid id)
        {
            PersonViewModel personViewModel = this._personService.GetPersonDetails(id);
            EditPersonViewModel editViewModel = new EditPersonViewModel
            {
                Id = personViewModel.Id,
                Age = personViewModel.Age,
                Email = personViewModel.Email,
                CityId = personViewModel.CityId,
                FirstName = personViewModel.FirstName,
                LastName = personViewModel.LastName,
                InfectedWithCovid = personViewModel.InfectedWithCovid,
                Recovery=personViewModel.Recovery
            };

            List<CityViewModel> allCities = this._cityService.GetAllCities();
            ViewBag.Cities = allCities;
            return View(editViewModel);
        }

        [HttpPost]
#pragma warning disable CA3147 // Mark Verb Handlers With Validate Antiforgery Token
        public ActionResult EditPerson(EditPersonViewModel person)
#pragma warning restore CA3147 // Mark Verb Handlers With Validate Antiforgery Token
        {
            this._personService.UpdatePerson(person);
            return RedirectToAction("PersonsList");
        }

        [HttpGet]
        public ActionResult CreatePerson()
        {
            List<CityViewModel> allCities = this._cityService.GetAllCities();
            ViewBag.Cities = allCities;
            return View();
        }

        [HttpPost]
#pragma warning disable CA3147 // Mark Verb Handlers With Validate Antiforgery Token
        public ActionResult CreatePerson(CreatePersonViewModel person)
#pragma warning restore CA3147 // Mark Verb Handlers With Validate Antiforgery Token
        {
            if(!ModelState.IsValid)
            {
                List<CityViewModel> allCities = this._cityService.GetAllCities();
                ViewBag.Cities = allCities;
                return View();
            }
            Guid personId = this._personService.InsertPerson(person);
            return RedirectToAction("PersonsList");
        }

        [HttpPost]
#pragma warning disable CA3147 // Mark Verb Handlers With Validate Antiforgery Token
        public ActionResult DeletePerson(Guid id)
#pragma warning restore CA3147 // Mark Verb Handlers With Validate Antiforgery Token
        {
            this._personService.DeletePerson(id);
            return RedirectToAction("PersonsList");
        }
    }
}
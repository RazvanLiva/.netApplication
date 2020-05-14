using BusinessLogic.Services.Interfaces;
using System;
using System.Web.Http;
using ViewModels;
using System.Collections.Generic;

namespace Presentation.Controllers.API
{
    public class CitiesController : ApiController
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            this._cityService = cityService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            
            CityViewModel cityModel = this._cityService.GetCityById(id);
            CityDetailsViewModel detailsModel = new CityDetailsViewModel
            {
                Name = cityModel.Name,
                HospitalsCount = cityModel.Hospitals.Count,
                PersonsCount = cityModel.Persons.Count
            };
            return Ok(detailsModel);
        }

        [HttpGet]
        [Route("api/cities/{cityId}/persons")]
        public IHttpActionResult GetCiyPersons(Guid cityId)
        {
            List<PersonViewModel> cityPersons = this._cityService.GetCityPersons(cityId);

            return Ok(cityPersons);
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]EditCityViewModel editCityViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                this._cityService.UpdateCity(editCityViewModel);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateCityViewModel cityModel)
        {
            try
            {
                Guid id = this._cityService.InsertCity(cityModel);
                string cityDetailsLocation = $"{Request.RequestUri}/{id}";
                CityDetailsViewModel detailsModel = new CityDetailsViewModel
                {
#pragma warning disable CA1062 // Validate arguments of public methods
                    Name = cityModel.Name,
#pragma warning restore CA1062 // Validate arguments of public methods
                };
                return Created(cityDetailsLocation, detailsModel);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                this._cityService.DeleteCity(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return InternalServerError(ex);
            }
        }
    }
}
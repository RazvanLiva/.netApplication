using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModels;

namespace Presentation.Controllers.API
{
    public class PersonsController : ApiController
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            this._personService = personService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<PersonViewModel> persons = this._personService.GetAllPersons();

            return Ok(persons);
        }
    }
}

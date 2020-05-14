using System;
using System.Collections.Generic;
using ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface IPersonService
    {
        List<PersonViewModel> GetAllPersons();
        Guid InsertPerson(CreatePersonViewModel createPersonViewModel);
        void DeletePerson(Guid personId);
        void UpdatePerson(EditPersonViewModel personViewModel);
        PersonViewModel GetPersonById(Guid id);
        PersonViewModel GetPersonDetails(Guid personId);
    }
}

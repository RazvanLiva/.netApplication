using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels;
using BusinessLogic.Services.Interfaces;

namespace BusinessLogic.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICityRepository _cityRepository;
        public PersonService(IPersonRepository personRepository, ICityRepository cityRepository)
        {
            
            this._personRepository = personRepository;
            this._cityRepository = cityRepository;
        }

        public List<PersonViewModel> GetAllPersons()
        {

            List<PersonViewModel> persons = this._personRepository.Query()
                .OrderBy(person => person.FirstName)
                .Select(personEntity => new PersonViewModel { 
                    Id = personEntity.Id,
                    Age = personEntity.Age,
                    Email = personEntity.Email,
                    FirstName = personEntity.FirstName,
                    LastName = personEntity.LastName,
                    InfectedWithCovid = personEntity.InfectedWithCovid,
                    Recovery = personEntity.Recovery
                }).ToList();

            return persons;
        }

        public Guid InsertPerson(CreatePersonViewModel createPersonViewModel)
        {

            Person personEntity = new Person
            {
                Id = Guid.NewGuid(),
                Age = createPersonViewModel.Age,
                LastName = createPersonViewModel.LastName,
                FirstName = createPersonViewModel.FirstName,
                Email = createPersonViewModel.Email,
                InfectedWithCovid=createPersonViewModel.InfectedWithCovid,
                Recovery=createPersonViewModel.Recovery
            };

            City personCity = this._cityRepository.Query()
                    .Where(city => city.Id == createPersonViewModel.CityId)
                    .FirstOrDefault();

            personEntity.City = personCity;
            this._personRepository.AddPerson(personEntity);

            this._personRepository.SaveChanges();

            return personEntity.Id;
        }


        public void DeletePerson(Guid personId)
        {
    
            Person personToDelete = this._personRepository.Query().Where(person => person.Id == personId).FirstOrDefault();

            if (personToDelete == null)
            {
                throw new InvalidOperationException($"Person with id {personId} not found.");
            }
            
   
            this._personRepository.DeletePerson(personToDelete);
            this._personRepository.SaveChanges();
        }


        public void UpdatePerson(EditPersonViewModel personViewModel)
        {
  
            Person personEntityToUpdate = this._personRepository.Query().Where(person => person.Id == personViewModel.Id).FirstOrDefault();

            if (personEntityToUpdate == null)
            {
#pragma warning disable CA1062 // Validate arguments of public methods
                throw new InvalidOperationException($"Person with id {personViewModel.Id} not found.");
#pragma warning restore CA1062 // Validate arguments of public methods
            }

            personEntityToUpdate.FirstName = personViewModel.FirstName;
            personEntityToUpdate.LastName = personViewModel.LastName;
            personEntityToUpdate.Email = personViewModel.Email;
            personEntityToUpdate.Age = personViewModel.Age;
            personEntityToUpdate.InfectedWithCovid = personViewModel.InfectedWithCovid;
            personEntityToUpdate.Recovery = personViewModel.Recovery;

            City personCity = this._cityRepository.Query()
                   .Where(city => city.Id == personViewModel.CityId)
                   .FirstOrDefault();

            personEntityToUpdate.City = personCity;
            this._personRepository.SaveChanges();
        }


        public PersonViewModel GetPersonById(Guid id)
        {
            
            Person personEntity = this._personRepository.Query().Where(person => person.Id == id).FirstOrDefault();

            if(personEntity == null)
            {
                throw new InvalidOperationException($"Person with id {id} not found");
            }

            return new PersonViewModel
            {
                Id = personEntity.Id,
                Age = personEntity.Age,
                Email = personEntity.Email,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                InfectedWithCovid=personEntity.InfectedWithCovid,
                Recovery=personEntity.Recovery
            };
        }

 
        public PersonViewModel GetPersonDetails(Guid personId)
        {
            Person person = this._personRepository.GetPersonById(personId);

            return new PersonViewModel
            {
                Id = person.Id,
                Age = person.Age,
                Email = person.Email,
                CityId = person.City.Id,
                CityName = person.City.Name,
                FirstName = person.FirstName,
                LastName = person.LastName,
                InfectedWithCovid=person.InfectedWithCovid,
                Recovery=person.Recovery,
                BloodTypes = person.BloodTypes.Select(bloodType => new BloodTypeViewModel
                {
                    Id = bloodType.Id,
                    Name = bloodType.Name
                }).ToList()
            };
        }
    }
}

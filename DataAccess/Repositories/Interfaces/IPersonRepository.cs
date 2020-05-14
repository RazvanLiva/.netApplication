using DataAccess.Entities;
using System;
using System.Linq;

namespace DataAccess.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> Query();
        Person GetPersonById(Guid id);
        void AddPerson(Person person);
        void DeletePerson(Person person);
        void SaveChanges();
    }
}

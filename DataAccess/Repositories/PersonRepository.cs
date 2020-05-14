using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly RazvanLivadariuDbContext _dbContext;
        public PersonRepository(RazvanLivadariuDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<Person> Query()
        {
            return this._dbContext.Persons.AsQueryable();
        }
        public Person GetPersonById(Guid id)
        {
            Person person = this._dbContext.Persons
                .Include(pers => pers.City)
                .Include(pers => pers.BloodTypes)
                .Where(pers => pers.Id == id)
                .FirstOrDefault();

            return person;
        }
        public void AddPerson(Person person)
        {
            this._dbContext.Persons.Add(person);
        }
        public void DeletePerson(Person person)
        {
            this._dbContext.Persons.Remove(person);
        }
        public void SaveChanges()
        {
            this._dbContext.SaveChanges();
           
        }
    }
}

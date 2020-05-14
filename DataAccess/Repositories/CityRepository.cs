using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Linq;
using System.Data.Entity;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly RazvanLivadariuDbContext _dbContext;
        public CityRepository(RazvanLivadariuDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IQueryable<City> Query()
        {
            return this._dbContext.Cities.AsQueryable();
        }
        public City GetCityById(Guid id)
        {
            City city = this._dbContext.Cities
                .Include(fc => fc.Hospitals)
                .Include(fc => fc.Persons)
                .Include(fc => fc.County)
                .Where(fc => fc.Id == id)
                .FirstOrDefault();

            return city;
        }

        public void AddCity(City city)
        {
            this._dbContext.Cities.Add(city);
        }

        public void DeleteCity(City city)
        {
            this._dbContext.Cities.Remove(city);
        }

        public void SaveChanges()
        {
            this._dbContext.SaveChanges();
           
        }
    }
}

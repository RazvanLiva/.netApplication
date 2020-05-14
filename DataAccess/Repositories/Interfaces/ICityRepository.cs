using DataAccess.Entities;
using System;
using System.Linq;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICityRepository
    {
        IQueryable<City> Query();
        City GetCityById(Guid id);
        void AddCity(City city);
        void DeleteCity(City city);
        void SaveChanges();
    }
}

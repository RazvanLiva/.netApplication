using DataAccess.Context;
using DataAccess.Entities;
using System.Linq;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class CountyRepository : ICountyRepository
    {
        private readonly RazvanLivadariuDbContext _dbContext;
        public CountyRepository(RazvanLivadariuDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IQueryable<County> Query()
        {
            return this._dbContext.Counties.AsQueryable();
        }
    }
}

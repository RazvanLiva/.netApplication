using DataAccess.Entities;
using System.Linq;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICountyRepository
    {
        IQueryable<County> Query();
    }
}

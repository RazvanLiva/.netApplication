using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using ViewModels;
using BusinessLogic.Services.Interfaces;
namespace BusinessLogic.Services
{
    public class CountyService : ICountyService
    {
        private readonly ICountyRepository _countyRepository;
        public CountyService(ICountyRepository countyRepository)
        {
            this._countyRepository = countyRepository;
        }

        public List<CountyViewModel> GetAllCounties()
        {
            List<CountyViewModel> counties = this._countyRepository.Query()
                .OrderBy(county => county.Name)
                .Select(countyEntity => new CountyViewModel
                {
                    Id = countyEntity.Id,
                    Name = countyEntity.Name
                }).ToList();

            return counties;
        }
    }
}

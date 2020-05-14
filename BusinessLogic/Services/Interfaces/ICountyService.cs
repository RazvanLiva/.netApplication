using System.Collections.Generic;
using ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICountyService
    {
        List<CountyViewModel> GetAllCounties();
    }
}

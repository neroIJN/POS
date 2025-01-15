using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;

namespace Client11.Services
{ 
    public interface IAppService
    {
        Task<List<AppServiceModel>> GetAllUser();

        Task<AppServiceModel> GetUserByID(int UserID);

        Task<int> AddUser(AppServiceModel appServiceModel);

        Task<int> UpdateUser(AppServiceModel appServiceModel);

        Task<int> DeleteUser(AppServiceModel appServiceModel);

    }
}

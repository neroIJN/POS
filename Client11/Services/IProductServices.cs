using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;

namespace Client11.Services
{
    public interface IProductServices
    {
        Task<List<ProductServicesModel>> GetAllUser();

        Task<ProductServicesModel> GetUserByID(int UserID);

        Task<int> AddUser(ProductServicesModel productServicesModel);

        Task<int> UpdateUser(ProductServicesModel productServicesModel);

        Task<int> DeleteUser(ProductServicesModel productServicesModel);
       
    }
}

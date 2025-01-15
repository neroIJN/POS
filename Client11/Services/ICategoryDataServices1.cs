using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;
namespace Client11.Services
{
    public interface ICategoryDataServices1
    {
        Task<List<CategoryModel1>> GetAllUser();

        Task<CategoryModel1> GetUserByID(int UserID);

        Task<int> AddUser(CategoryModel1 categoryModel1);

        Task<int> UpdateUser(CategoryModel1 categoryModel1);

        Task<int> DeleteUser(CategoryModel1 categoryModel1);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;

namespace Client11.Services
{
    public interface IProductServices1
    {
        Task<List<ProductServiceModel1>> GetAllProducts();
        Task<ProductServiceModel1> GetProductByID(int ProductId);
       // Task<List<ProductServiceModel1>> GetProductsByCategory(CategoryModel1 category);
    }
}

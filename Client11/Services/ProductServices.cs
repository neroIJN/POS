using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;

namespace Client11.Services
{
    public class ProductServices : IProductServices
    {
        private SQLiteAsyncConnection _dbConnection;
        public ProductServices() {
            SetUpDb();
        }
        public async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                //string customPath = @"D:\Semester 3\SoftwareProject\myProject\POS\Client11\ProductsImAGE.db3";
                //string dbPath = customPath;
                //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProductsImAGE.db3");
                //string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "ProductsImAGE.db3");
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Data", "ProductsImAGE.db3");


                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ProductServicesModel>();

            }
        }
        public async Task<int> AddUser(ProductServicesModel productServicesModel)
        {
            return await _dbConnection.InsertAsync(productServicesModel);
        }

        public async Task<int> DeleteUser(ProductServicesModel productServicesModel)
        {
            if (productServicesModel != null)
            {
                return await _dbConnection.DeleteAsync<ProductServicesModel>(productServicesModel.UserID);
            }
            return -1; // Indicate failure
        }

        public async Task<int> UpdateUser(ProductServicesModel productServicesModel)
        {
            return await _dbConnection.UpdateAsync(productServicesModel);
        }
        public async Task<List<ProductServicesModel>> GetAllUser()
        {
            return await _dbConnection.Table< ProductServicesModel > ().ToListAsync();
        }

        public async Task<ProductServicesModel> GetUserByID(int UserID)
        {
            var user = await _dbConnection.QueryAsync< ProductServicesModel > ($"Select * From {nameof(ProductServicesModel)} where UserID={UserID} ");
            return user.FirstOrDefault();
        }
    }


    
}

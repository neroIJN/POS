using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;
using SQLite;

namespace Client11.Services
{
    public class ProductServices1 : IProductServices1
    {
        private SQLiteAsyncConnection _dbConnection;
        public ProductServices1()
        {
            SetUpDb();
        }
        public async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                //string customPath = @"D:\Semester 3\SoftwareProject\myProject\POS\Client11\Products111.db3";
                //string dbPath1 = customPath;
                //string dbPath1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Products111.db3");
                //string dbPath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Products111.db3");
                string dbPath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Data", "Products111.db3");

                _dbConnection = new SQLiteAsyncConnection(dbPath1);
                await _dbConnection.CreateTableAsync<ProductServiceModel1>();

            }
        }


        public async Task<List<ProductServiceModel1>> GetAllProducts()
        {
            return await _dbConnection.Table<ProductServiceModel1>().ToListAsync();
        }



        public async Task<ProductServiceModel1> GetProductByID(int ProductID)
        {
            var Product = await _dbConnection.QueryAsync<ProductServiceModel1>($"Select * From {nameof(ProductServiceModel1)} where ProductID={ProductID} ");
            return Product.FirstOrDefault();

        }

        /*
        public async Task<List<ProductServicesModel>> GetProductsByCategory(CategoryModel1 category)
        {
            try
            {
                // Query the database to get products by category
                var products = await _dbConnection.Table<ProductServiceModel1>()
                                                 .Where(p => p.CategoryID == category.CategoryID)
                                                 .ToListAsync();

                // Convert ProductServiceModel1 objects to ProductServicesModel objects
                List<ProductServicesModel> convertedProducts = products
                    .Select(p => new ProductServicesModel
                    {
                        
                        ProductName = p.ProductName,
                        Price = p.Price,
                        Stock = p.Stock
                    })
                    .ToList();

                return convertedProducts;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error retrieving products by category: {ex.Message}");
                return new List<ProductServicesModel>(); // Return an empty list in case of an error
            }
        }

        */
    }
}
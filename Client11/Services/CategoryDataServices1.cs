using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;
using SQLite;

namespace Client11.Services
{
    public class CategoryDataServices1: ICategoryDataServices1
    {
        private SQLiteAsyncConnection _dbConnection;
        public CategoryDataServices1()
        {
            SetUpDb();
        }
        public async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                //string customPath = @"D:\Semester 3\SoftwareProject\myProject\POS\Client11\Category1.db3";
                //string dbPath = customPath;
                //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Category1.db3");
                //string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Category1.db3");
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Data", "Category1.db3");


                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<CategoryModel1>();

            }
        }
        public async Task<int> AddUser(CategoryModel1 categoryModel1)
        {
            return await _dbConnection.InsertAsync(categoryModel1);
        }

        public async Task<int> DeleteUser(CategoryModel1 categoryModel1)
        {
            return await _dbConnection.DeleteAsync(categoryModel1);

        }
        public async Task<int> UpdateUser(CategoryModel1 categoryModel1)
        {
            return await _dbConnection.UpdateAsync(categoryModel1);
        }
        public async Task<List<CategoryModel1>> GetAllUser()
        {
            return await _dbConnection.Table<CategoryModel1>().ToListAsync();
        }

        public async Task<CategoryModel1> GetUserByID(int UserID)
        {
            var user = await _dbConnection.QueryAsync<CategoryModel1>($"Select * From {nameof(CategoryModel1)} where UserID={UserID} ");
            return user.FirstOrDefault();
        }

    }
}

using Client11.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Client11.Services
{
    public class AppService : IAppService
    {
        private SQLiteAsyncConnection _dbConnection;

        public AppService()
        {
            SetUpDb();
        }
        public async void SetUpDb()
        {
            if(_dbConnection == null)
            {
                //string customPath = @"D:\Semester 3\SoftwareProject\myProject\POS\Client11\Student.db3";
                //string dbPath = customPath;
                //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                //string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Student.db3");
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Data", "Student.db3");

                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<AppServiceModel>();

            }
        }
        public async Task<int> AddUser(AppServiceModel appServiceModel)
        {
            return await _dbConnection.InsertAsync(appServiceModel);
        }

        public async Task<int> DeleteUser(AppServiceModel appServiceModel)
        {
            return await _dbConnection.DeleteAsync(appServiceModel);

        }
        public async Task<int> UpdateUser(AppServiceModel appServiceModel)
        {
            return await _dbConnection.UpdateAsync(appServiceModel);
        }
        public async Task<List<AppServiceModel>> GetAllUser()
        {
            return await _dbConnection.Table<AppServiceModel>().ToListAsync();
        }

        public async Task<AppServiceModel> GetUserByID(int UserID)
        {
            var user = await _dbConnection.QueryAsync<AppServiceModel>($"Select * From {nameof(AppServiceModel)} where UserID={UserID} ");
            return user.FirstOrDefault();
        }

    }
}

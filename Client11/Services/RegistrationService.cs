using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;

using SQLite;

namespace Client11.Services
{
    public class RegistrationService : IRegistrationService
    {
        private SQLiteAsyncConnection _dbConnection;
        public RegistrationService()
        {
            SetUpDb();
        }
        public async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                //string customPath = @"D:\Semester 3\SoftwareProject\myProject\POS\Client11\Registration.db3";
                //string dbPath = customPath;
                //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserRegistration.db3");
                //string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "UserRegistration.db3");
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Data", "UserRegistration.db3");


                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<RegistrationModel>();

            }
        }
        public async Task<int> AddUser(RegistrationModel registrationModel)
        {
            return await _dbConnection.InsertAsync(registrationModel);
        }



        public async Task<List<RegistrationModel>> GetAllUser()
        {
            return await _dbConnection.Table<RegistrationModel>().ToListAsync();
        }

        public async Task<RegistrationModel> GetUserByID(int UserID)
        {
            var user = await _dbConnection.QueryAsync<RegistrationModel>($"Select * From {nameof(RegistrationModel)} where UserID={UserID} ");
            return user.FirstOrDefault();
        }
        public async Task<int> DeleteUser(RegistrationModel registrationModel)
        {
            return await _dbConnection.DeleteAsync(registrationModel);

        }
        public async Task<int> UpdateUser(RegistrationModel registrationModel)
        {
            return await _dbConnection.UpdateAsync(registrationModel);
        }

        public async Task<RegistrationModel> GetUserByEmailAndPassword(string email, string password)
        {
            
            var user = await _dbConnection.Table<RegistrationModel>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
            return user;
        }


    }



}

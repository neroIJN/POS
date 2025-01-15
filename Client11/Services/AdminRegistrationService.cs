using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;
using SQLite;

namespace Client11.Services
{
    public class AdminRegistrationService : IAdminRegistrationService
    {
        private SQLiteAsyncConnection _dbConnection;
        public AdminRegistrationService()
        {
            SetUpDb();
        }
        public async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                //string customPath = @"D:\Semester 3\SoftwareProject\myProject\POS\Client11\AdminRegistration.db3";
                //string dbPath = customPath;
                //string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "AdminRegistration.db3");
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Data", "AdminRegistration.db3");
                //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdminRegistration.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<AdminRegistrationModel>();

            }
        }
        public async Task<int> AddAdmin(AdminRegistrationModel adminRegistrationModel)
        {
            return await _dbConnection.InsertAsync(adminRegistrationModel);
        }



        public async Task<List<AdminRegistrationModel>> GetAllAdmin()
        {
            return await _dbConnection.Table<AdminRegistrationModel>().ToListAsync();
        }

        public async Task<AdminRegistrationModel> GetAdminByID(int AdminID)
        {
            var admin = await _dbConnection.QueryAsync<AdminRegistrationModel>($"Select * From {nameof(AdminRegistrationModel)} where AdminID={AdminID} ");
            return admin.FirstOrDefault();
        }
        public async Task<int> DeleteAdmin(AdminRegistrationModel adminRegistrationModel)
        {
            return await _dbConnection.DeleteAsync(adminRegistrationModel);

        }
        public async Task<int> UpdateAdmin(AdminRegistrationModel adminRegistrationModel)
        {
            return await _dbConnection.UpdateAsync(adminRegistrationModel);
        }

        public async Task<AdminRegistrationModel> GetAdminByEmailAndPassword(string email, string password)
        {

            var admin = await _dbConnection.Table<AdminRegistrationModel>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
            return admin;
        }
        public async Task<AdminRegistrationModel> GetAdminByEmail(string email)
        {
            var admin = await _dbConnection.Table<AdminRegistrationModel>().Where(u => u.Email == email).FirstOrDefaultAsync();
            return admin;
        }
        public AdminRegistrationModel LoggedInAmin { get; set; }
        public void SetLoggedInAdmin(AdminRegistrationModel admin)
        {
            LoggedInAmin = admin;

        }
    }
}

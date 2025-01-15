using System;
using System.IO;
using System.Threading.Tasks;
using Client11.Models;
using SQLite;

namespace Client11.Services
{
    public class AppStateService : IAppStateService
    {
        private SQLiteAsyncConnection _dbConnection;

        public AppStateService()
        {
            SetUpDb();
        }

        public async Task SetUpDb()
        {
            try
            {
                if (_dbConnection == null)
                {
                    //string customPath = @"D:\Semester 3\SoftwareProject\myProject\POS\Client11\Registration.db3";
                    //string dbPath = customPath;
                    //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Registration.db3");
                    //string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Registration.db3");
                    string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Data", "Registration.db3");


                    _dbConnection = new SQLiteAsyncConnection(dbPath);
                    await _dbConnection.CreateTableAsync<RegistrationModel>();
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error setting up the database: {ex.Message}");
            }
        }

        public RegistrationModel LoggedInUser { get; set; }
        public AdminRegistrationModel LoggedInAmin { get; set; }

        public void SetLoggedInUser(RegistrationModel user)
        {
            LoggedInUser = user;

        }
        public void SetLoggedInAdmin(AdminRegistrationModel admin)
        {
            LoggedInAmin = admin;

        }

        public async Task<RegistrationModel> GetUserByEmail(string email)
        {
            var user = await _dbConnection.Table<RegistrationModel>().Where(u => u.Email == email).FirstOrDefaultAsync();
            return user;
        }
        public string GetUserRole()
        {

            if (LoggedInAmin is AdminRegistrationModel)
            {
                return "Admin";

            }
            if (LoggedInUser is RegistrationModel)
            {
                return "User";
            }

            else
            {
                return "Guest";
            }

        }
    }
}
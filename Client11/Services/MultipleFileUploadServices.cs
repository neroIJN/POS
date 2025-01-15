using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Client11.Models;

namespace Client11.Services
{
    public class MultipleFileUploadServices : IMultipleFileUploadServices
    {
        private SQLiteAsyncConnection _dbConnection;
        public MultipleFileUploadServices()
        {
            SetUpDb();
        }
        public async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                //string customPath = @"D:\Semester 3\SoftwareProject\myProject\POS\Client11\Products.db3";
                //string dbPath = customPath;
                //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Products.db3");
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Products.db3");

                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<MultipleFileUploadModel>();

            }
        }

        public async Task<int> AddImage(MultipleFileUploadModel multipleFileUploadModel)
        {
            return await _dbConnection.InsertAsync(multipleFileUploadModel);

        }

        public async Task<List<MultipleFileUploadModel>> GetAllImages()
        {
            return await _dbConnection.Table<MultipleFileUploadModel>().ToListAsync();
        }

        public async Task DeleteImage(string fileId)
        {
            await _dbConnection.DeleteAsync<MultipleFileUploadModel>(fileId);
        }

    }
}

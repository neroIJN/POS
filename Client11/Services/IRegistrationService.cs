using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;

namespace Client11.Services
{
    public interface IRegistrationService
    {
        Task<List<RegistrationModel>> GetAllUser();

        Task<RegistrationModel> GetUserByID(int UserID);

        Task<int> AddUser(RegistrationModel registrationModel);

        Task<int> UpdateUser(RegistrationModel registrationModel);

        Task<int> DeleteUser(RegistrationModel registrationModel);

        Task<RegistrationModel> GetUserByEmailAndPassword(string email, string password);


    }
}

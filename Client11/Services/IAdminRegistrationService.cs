using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;

namespace Client11.Services
{
    public interface IAdminRegistrationService
    {
        Task<List<AdminRegistrationModel>> GetAllAdmin();

        Task<AdminRegistrationModel> GetAdminByID(int AdminID);

        Task<int> AddAdmin(AdminRegistrationModel adminRegistrationModel);

        Task<int> UpdateAdmin(AdminRegistrationModel adminRegistrationModel);

        Task<int> DeleteAdmin(AdminRegistrationModel adminRegistrationModel);

        Task<AdminRegistrationModel> GetAdminByEmailAndPassword(string email, string password);
        Task<AdminRegistrationModel> GetAdminByEmail(string email);
        AdminRegistrationModel LoggedInAmin { get; }
        void SetLoggedInAdmin(AdminRegistrationModel admin);
    }
}

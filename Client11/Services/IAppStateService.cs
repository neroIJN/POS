using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;

namespace Client11.Services
{
    public interface IAppStateService
    {
        
        Task<RegistrationModel> GetUserByEmail(string email);
        
        RegistrationModel LoggedInUser { get; }
        AdminRegistrationModel LoggedInAmin { get; set; }

        void SetLoggedInUser(RegistrationModel user);
        void SetLoggedInAdmin(AdminRegistrationModel admin);

        string GetUserRole();

    }
}

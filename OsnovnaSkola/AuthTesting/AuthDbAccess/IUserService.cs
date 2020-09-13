using AuthTesting.AuthDbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AuthTesting.AuthDbAccess
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Task SeedData();
        [OperationContract]
        bool CreateUser(string ime, string prezime, string kIme, bool ucitelj);
        [OperationContract]
        ApplicationUserIM Login(string korisnickoIme, string lozinka);
        [OperationContract]
        List<ApplicationUserIM> GetUsers();
        [OperationContract]
        ApplicationUserIM GetUser(string email);
        [OperationContract]
        bool ChangeUser(ApplicationUserIM user);
        [OperationContract]
        bool DeleteUser(string email);
        [OperationContract]
        bool ChangePassword(ApplicationUserIM user, string novaLozinka);
        
    }
}

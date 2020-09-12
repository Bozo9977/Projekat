using AuthTesting.AuthDbAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace AuthTesting.AuthDbAccess
{
    public class UserService: IUserService
    {
        public readonly UserManager<ApplicationUser> userManager;
        public readonly RoleManager<Roles> roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<Roles> _roleManager)
        {
            this.userManager = userManager;
            this.roleManager = _roleManager;
        }

        public UserService()
        {
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AuthDbContext()));
            this.roleManager = new RoleManager<Roles>(new RoleStore<Roles>(new AuthDbContext()));

            userManager.PasswordValidator = new PasswordValidator();
            (userManager.PasswordValidator as PasswordValidator).RequireDigit = false;
            (userManager.PasswordValidator as PasswordValidator).RequiredLength = 4;
            (userManager.PasswordValidator as PasswordValidator).RequireLowercase = false;
            (userManager.PasswordValidator as PasswordValidator).RequireNonLetterOrDigit = false;
            (userManager.PasswordValidator as PasswordValidator).RequireUppercase = false;
        }

        public bool CreateUser(string ime, string prezime, string kIme, string lozinka, bool ucitelj)
        {
            var user = new ApplicationUser { ime = ime, prezime = prezime, UserName = kIme };
            var result =  this.userManager.Create(user, lozinka);
            var createdUser =  userManager.FindByName(kIme);

            if (result.Succeeded == false)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error);
                }
                return result.Succeeded;
            }
            else
            {
                if (ucitelj)
                {
                    result =  userManager.AddToRole(createdUser.Id, "Ucitelj");
                }
                else
                {
                    result =  userManager.AddToRole(createdUser.Id, "Nastavnik");
                }

                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                        Console.WriteLine(error);
                }
                else
                {
                    Console.WriteLine("Done");
                }

                return result.Succeeded;
            }
        }

        public bool Exists(string username, string lozinka)
        {
            if (userManager.FindByNameAsync("admin@gmail.com") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ApplicationUserIM Login(string email, string lozinka)
        {
            ApplicationUserIM retVal = new ApplicationUserIM();
            try
            {
                

                ApplicationUser user = userManager.FindByName(email);

                if(user != null && userManager.CheckPassword(user, lozinka))
                {

                    var roles =  userManager.GetRoles(user.Id);
                    if(roles.Count > 0)
                    {
                        retVal.ime = user.ime;
                        retVal.prezime = user.prezime;
                        retVal.Email = user.UserName;
                        retVal.Uloga = roles[0];
                        
                    }
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retVal;
        }

        public async Task SeedData()
        {
            await InitializeAuthDb.GenerateRoles(roleManager);
            await InitializeAuthDb.InitializeData(userManager);
        }

        public List<ApplicationUserIM> GetUsers()
        {
            List<ApplicationUserIM> retVal = new List<ApplicationUserIM>();
            var listUsers = userManager.Users.ToList();

            foreach(var user in listUsers)
            {
                retVal.Add(new ApplicationUserIM()
                {
                    ime = user.ime,
                    prezime = user.prezime,
                    Email = user.UserName,
                    Uloga =  userManager.GetRoles(user.Id)[0]
                });
            }

            return retVal;
        }

        public ApplicationUserIM GetUser(string email)
        {
            ApplicationUser user = userManager.FindByName(email);
            ApplicationUserIM retVal = new ApplicationUserIM()
            {
                ime = user.ime,
                prezime = user.prezime,
                Email = user.UserName,
                Uloga = userManager.GetRoles(user.Id)[0]
            };

            return retVal;
        }

        public bool ChangeUser(ApplicationUserIM user)
        {
            ApplicationUser toChange = userManager.FindByEmail(user.Email);

            if(toChange!= null)
            {
                toChange.ime = user.ime;
                toChange.prezime = user.prezime;

                var res = userManager.Update(toChange);
                return res.Succeeded;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(string email)
        {
            ApplicationUser user = userManager.FindByEmail(email);
            var res = userManager.Delete(user);
            return res.Succeeded;
        }
    }
}

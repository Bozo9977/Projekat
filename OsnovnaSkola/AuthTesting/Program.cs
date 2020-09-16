using AuthTesting.AuthDbAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AuthDbContext()));
            RoleManager<Roles> roleManager = new RoleManager<Roles>(new RoleStore<Roles>(new AuthDbContext()));

            userManager.PasswordValidator = new PasswordValidator();
            (userManager.PasswordValidator as PasswordValidator).RequireDigit = false;
            (userManager.PasswordValidator as PasswordValidator).RequiredLength = 4;
            (userManager.PasswordValidator as PasswordValidator).RequireLowercase = false;
            (userManager.PasswordValidator as PasswordValidator).RequireNonLetterOrDigit = false;
            (userManager.PasswordValidator as PasswordValidator).RequireUppercase = false;


            UserService service = new UserService(userManager, roleManager);
            
            service.SeedData();

            //Console.WriteLine("Check if data is seeded.");

            AuthService aService = new AuthService();
            aService.Open();
            Console.ReadLine();
            aService.Close();

        }
    }
}

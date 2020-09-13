using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTesting.AuthDbAccess
{
    public class InitializeAuthDb
    {
        public static async Task GenerateRoles(RoleManager<Roles> roleManager)
        {
            try
            {
                if (!roleManager.RoleExistsAsync("Ucitelj").Result)
                {
                    Roles role = new Roles();
                    role.Name = "Ucitelj";

                    IdentityResult roleResult = await roleManager.CreateAsync(role);
                }
                if (!roleManager.RoleExistsAsync("Nastavnik").Result)
                {
                    Roles role = new Roles();
                    role.Name = "Nastavnik";
                    IdentityResult roleResult = await roleManager.CreateAsync(role);
                }
                if (!roleManager.RoleExistsAsync("Administrator").Result)
                {
                    Roles role = new Roles();
                    role.Name = "Administrator";
                    IdentityResult roleResult = await roleManager.CreateAsync(role);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
            


        }



        public static async Task InitializeData(UserManager<ApplicationUser> userManager)
        {

            try
            {
                if (userManager.FindByNameAsync("admin").Result == null)
                {
                    ApplicationUser user = new ApplicationUser();
                    user.ime = "Admin";
                    user.prezime = "Admin";
                    user.UserName = "admin";
                    user.Email = "admin@gmail.com";

                    IdentityResult result = await userManager.CreateAsync(user, "admin");

                    if (result.Succeeded)
                    {
                        var userId = await userManager.FindByEmailAsync("admin@gmail.com");
                        userManager.AddToRoleAsync(userId.Id, "Administrator").Wait();
                    }
                    else
                    {
                        foreach(var err in result.Errors)
                            Console.WriteLine(err);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }

        }
    }
}

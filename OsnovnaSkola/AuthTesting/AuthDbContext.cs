using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace AuthTesting
{
    public class AuthDbContext: IdentityDbContext<ApplicationUser>
    {

        static string connString = ConfigurationManager.ConnectionStrings["AuthTesting.Properties.Settings.Setting"].ConnectionString;

        public AuthDbContext(): base(connString)
        {

        }

        //public DbSet<ApplicationUser> MyProperty { get; set; }
        
    }
}

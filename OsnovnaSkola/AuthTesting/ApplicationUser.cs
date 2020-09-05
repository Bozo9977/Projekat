using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTesting
{
    public class ApplicationUser: IdentityUser
    {
        public string ime { get; set; }
        public string prezime { get; set; }
    }
}

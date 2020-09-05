using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AuthTesting
{
    public class AuthService
    {
        private static ServiceHost UserServiceHost;

        public AuthService()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.None;

            UserServiceHost = new ServiceHost(typeof(UserService));
            UserServiceHost.AddServiceEndpoint(typeof(IUserService), binding, new Uri("net.tcp://localhost:11002/IUserService"));
        }


        public void Open()
        {
            UserServiceHost.Open();
            Console.WriteLine("Auth service opened at: "+ DateTime.Now);
        }

        public void Close()
        {
            UserServiceHost.Close();
            Console.WriteLine("Auth service closed at: "+DateTime.Now);
        }
    }
}

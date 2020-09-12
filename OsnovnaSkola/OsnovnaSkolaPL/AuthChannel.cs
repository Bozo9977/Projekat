using AuthTesting.AuthDbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OsnovnaSkolaPL
{
    public class AuthChannel
    {
        public IUserService UserProxy { get; set; }

        private static AuthChannel instance;

        public static AuthChannel Instance
        {
            get
            {
                if (instance == null)
                    instance = new AuthChannel();
                return instance;
            }
        }

        public AuthChannel()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.None;


            ChannelFactory<IUserService> channelFactoryZaposleni = new ChannelFactory<IUserService>(binding, new EndpointAddress("net.tcp://localhost:11002/IUserService"));
            UserProxy = channelFactoryZaposleni.CreateChannel();
        }



        
    }
}

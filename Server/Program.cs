using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerFunctions;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            TcpChannel myChannel = new TcpChannel(9090);
            ChannelServices.RegisterChannel(myChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                   typeof(ServerToClient),
                   "ServerToClient", WellKnownObjectMode.Singleton);
                Console.WriteLine("Started Server");
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine(); Console.WriteLine("Bye");
        }
    }
}

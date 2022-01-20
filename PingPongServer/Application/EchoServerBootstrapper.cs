using Server;
using Listeners;
using ClientHandelingStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Application
{
    class EchoServerBootstrapper
    {
        public Server<string> GetServer(int port)
        {
            var listener = new SocketListener(port);
            var serverStrategy = new EchoStrategy();
        }
    }
}

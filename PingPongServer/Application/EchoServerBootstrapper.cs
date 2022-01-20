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
using DataHandlers.Decoders;
using DataHandlers.Encoders;

namespace Application
{
    class EchoServerBootstrapper
    {
        public Server<string> GetServer(int port)
        {
            var listener = new SocketListener(port);
            var serverStrategy = new EchoStrategy();
            var decoder = new StringDecoder();
            var encoder = new StringEncoder();
            return new Server<string>(listener, serverStrategy, encoder, decoder);
        }
    }
}

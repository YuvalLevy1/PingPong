using Communicators.ProtocolEnforcers.Abstractions;
using Connectors.Abstractions;
using ProtocolEnforcerFactories.Abstractions;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Communicators;

namespace Connectors
{
    public class SocketConnector : IConnector
    {
        public IProtocolEnforcer Connect(IPAddress address, int port, IProtocolEnforcerFactory factory)
        {
            
            var serverAddress = new IPEndPoint(address, port);
            var socket = new Socket(serverAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(serverAddress);
            return factory.Create(new SocketCommunicator(socket));
        }
    }
}

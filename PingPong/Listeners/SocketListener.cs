using Communicators;
using Communicators.ProtocolEnforcers;
using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using Listeners.Abstractions;
using ProtocolEnforcerFactories.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace Listeners
{
    public class SocketListener : IListener
    {
        private Socket _listener;
        private readonly IProtocolEnforcerFactory _factory;

        public SocketListener(int port, IProtocolEnforcerFactory factory)
        {
            var ip = IPAddress.Parse("192.168.56.1");
            var localEndpoint = new IPEndPoint(ip, port);
            _listener = new Socket(localEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(localEndpoint);
            _factory = factory;
        }

        public IProtocolEnforcer Listen()
        {
            _listener.Listen();
            var socket = _listener.Accept();
            var socketCommunicator = new SocketCommunicator(socket);
            return _factory.Create(socketCommunicator);
        }

        public void Close()
        {
            _listener.Close();
        }
    }
}

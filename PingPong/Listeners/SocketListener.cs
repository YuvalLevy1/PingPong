using Communicators;
using Communicators.Abstractions;
using Listeners.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace Listeners
{
    public class SocketListener : IListener
    {
        private Socket _listener;

        public SocketListener(int port)
        {
            var ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            var localEndpoint = new IPEndPoint(ip, port);
            _listener = new Socket(localEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(localEndpoint);
        }

        public ICommunicator Listen()
        {
            _listener.Listen();
            var socket = _listener.Accept();
            return new SocketCommunicator(socket);
        }

        public void Close()
        {
            _listener.Close();
        }
    }
}

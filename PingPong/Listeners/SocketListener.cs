using Communicators;
using Communicators.Abstractions;
using Communicators.ProtocolEnforcers;
using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using Listeners.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace Listeners
{
    public class SocketListener : IListener
    {
        private Socket _listener;
        private readonly IEncoder<string> _encoder;
        private readonly IDecoder<string> _decoder;
        private readonly int _bufferSize;
        private readonly int _sizeOfLength;

        public SocketListener(int port, IEncoder<string> encoder, IDecoder<string> decoder, int bufferSize, int sizeOfLength)
        {
            var ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            var localEndpoint = new IPEndPoint(ip, port);
            _listener = new Socket(localEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(localEndpoint);
            _encoder = encoder;
            _decoder = decoder;
            _bufferSize = bufferSize;
            _sizeOfLength = sizeOfLength;
        }

        public ProtocolEnforcer Listen()
        {
            _listener.Listen();
            var socket = _listener.Accept();
            var socketCommunicator = new SocketCommunicator(socket);
            return new SizeProtocolEnforcer(socketCommunicator, _encoder, _decoder, 4, 1024);
        }

        public void Close()
        {
            _listener.Close();
        }
    }
}

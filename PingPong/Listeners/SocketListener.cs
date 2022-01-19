using Communicators;
using Communicators.Abstractions;
using Listeners.Abstractions;
using System;
using System.Net.Sockets;

namespace Listeners
{
    class SocketListener : IListener
    {
        private Socket _listener;

        public SocketListener(Socket listener)
        {
            _listener = listener;
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

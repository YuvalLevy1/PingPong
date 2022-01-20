using Communicators.Abstractions;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Communicators
{
    public class SocketCommunicator : ICommunicator
    {

        private Socket _socket;

        public SocketCommunicator(Socket socket)
        {
            _socket = socket;
        }

        public int Receive(byte[] buffer)
        {
            return _socket.Receive(buffer);
        }

        public void Send(byte[] infoToSend)
        {
            _socket.Send(infoToSend);
        }

        public void Close()
        {
            _socket.Close();
        }
    }
}

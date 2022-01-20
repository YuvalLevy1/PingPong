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

        public byte[] Receive(int size)
        {
            byte[] buffer = new byte[size];
            _socket.Receive(buffer);
            return buffer;
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

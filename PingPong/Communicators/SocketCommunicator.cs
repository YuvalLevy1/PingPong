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
            List<byte> output = new List<byte>();
            byte[] buffer = new byte[1024];
            while (output.Count < size)
            {
                int sizeOfData = _socket.Receive(buffer);
                for (int i = 0; i < sizeOfData; i++)
                {
                    output.Add(buffer[i]);
                }
            }
            return buffer;
        }

        public void Send(byte[] infoToSend)
        {
            _socket.Send(infoToSend);
        }
    }
}

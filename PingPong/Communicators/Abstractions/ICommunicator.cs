
namespace Communicators.Abstractions
{
    public interface ICommunicator
    {
        public void Send(byte[] infoToSend);

        public byte[] Receive(int size);
    }
}

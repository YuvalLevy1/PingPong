
namespace Communicators.Abstractions
{
    public interface ICommunicator
    {
        public void Send(byte[] infoToSend);

        public int Receive(byte[] buffer);

        public void Close();
    }
}

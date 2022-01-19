using Communicators.Abstractions;

namespace Listeners.Abstractions
{
    public interface IListener
    {
        public ICommunicator Listen();

        public void Close();
    }
}

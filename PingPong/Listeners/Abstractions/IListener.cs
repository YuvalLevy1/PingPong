using Communicators.ProtocolEnforcers.Abstractions;

namespace Listeners.Abstractions
{
    public interface IListener
    {
        public IProtocolEnforcer Listen();

        public void Close();
    }
}

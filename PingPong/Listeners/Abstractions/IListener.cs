using Communicators.ProtocolEnforcers.Abstractions;

namespace Listeners.Abstractions
{
    public interface IListener
    {
        public ProtocolEnforcer Listen();

        public void Close();
    }
}

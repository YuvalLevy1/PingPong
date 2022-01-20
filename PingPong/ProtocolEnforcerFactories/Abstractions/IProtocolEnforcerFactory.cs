using Communicators.Abstractions;
using Communicators.ProtocolEnforcers.Abstractions;

namespace ProtocolEnforcerFactories.Abstractions
{
    public interface IProtocolEnforcerFactory
    {
        public IProtocolEnforcer Create(ICommunicator communicator);
    }
}

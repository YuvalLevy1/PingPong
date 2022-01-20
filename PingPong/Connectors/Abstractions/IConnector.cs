using Communicators.ProtocolEnforcers.Abstractions;
using ProtocolEnforcerFactories.Abstractions;
using System.Net;

namespace Connectors.Abstractions
{
    public interface IConnector
    {
        public IProtocolEnforcer Connect(IPAddress address, int port, IProtocolEnforcerFactory factory);
    }
}

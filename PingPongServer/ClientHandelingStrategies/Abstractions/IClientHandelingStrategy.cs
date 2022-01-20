using Communicators.Abstractions;
using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using Utils;

namespace ClientHandelingStrategies.Abstractions
{
    public interface IClientHandelingStrategy<T>
    {
        public void Run(IProtocolEnforcer client, ConcurrentHashSet<IProtocolEnforcer> clients, IEncoder<T> encoder, IDecoder<T> decoder);
    }
}

using Communicators.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using Utils;

namespace ClientHandelingStrategies.Abstractions
{
    public interface IClientHandelingStrategy<T>
    {
        public void Run(ICommunicator client, ConcurrentHashSet<ICommunicator> clients, IEncoder<T> encoder, IDecoder<T> decoder);
    }
}

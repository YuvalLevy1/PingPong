using Communicators.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;

namespace ClientHandelingStrategies.Abstractions
{
    public interface IClientHandelingStrategy<T>
    {
        public void Run(ICommunicator client, IEncoder<T> encoder, IDecoder<T> decoder);
    }
}

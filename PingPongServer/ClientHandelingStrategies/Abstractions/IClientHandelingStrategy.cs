using Communicators.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using System.Collections.Generic;

namespace ClientHandelingStrategies.Abstractions
{
    public interface IClientHandelingStrategy<T>
    {
        public void Run(ICommunicator client, ICollection<ICommunicator> clients, IEncoder<T> encoder, IDecoder<T> decoder);
    }
}

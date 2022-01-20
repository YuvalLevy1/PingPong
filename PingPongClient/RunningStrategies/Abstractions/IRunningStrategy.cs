using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;

namespace RunningStrategies.Abstractions
{
    public interface IRunningStrategy<T>
    {
        public void Run(IProtocolEnforcer client, IEncoder<T> encoder, IDecoder<T> decoder);
    }
}

using Communicators.Abstractions;
using Communicators.ProtocolEnforcers;
using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using ProtocolEnforcerFactories.Abstractions;

namespace ProtocolEnforcerFactories
{
    class SizeProtocolFactory : IProtocolEnforcerFactory
    {
        public readonly int BufferSize;
        public readonly int LengthSize;
        public readonly IEncoder<string> _encoder;
        public readonly IDecoder<string> _decoder;

        public SizeProtocolFactory(int bufferSize, int lengthSize, IEncoder<string> encoder, IDecoder<string> decoder)
        {
            BufferSize = bufferSize;
            LengthSize = lengthSize;
            _encoder = encoder;
            _decoder = decoder;
        }

        public IProtocolEnforcer Create(ICommunicator communicator)
        {
            return new SizeProtocolEnforcer(communicator, _encoder, _decoder, LengthSize, BufferSize);
        }
    }
}

using Communicators.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicators.ProtocolEnforcers.Abstractions
{
    public abstract class ProtocolEnforcer
    {
        protected readonly ICommunicator _communicator;
        protected readonly IEncoder<string> _encoder;
        protected readonly IDecoder<string> _decoder;

        protected ProtocolEnforcer(ICommunicator communicator, IEncoder<string> encoder, IDecoder<string> decoder)
        {
            _communicator = communicator;
            _encoder = encoder;
            _decoder = decoder;
        }

        public abstract void Send(byte[] info);

        public abstract byte[] Receive();
    }
}

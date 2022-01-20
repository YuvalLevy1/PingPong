using Communicators.Abstractions;
using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicators.ProtocolEnforcers
{
    class SizeProtocolEnforcer : ProtocolEnforcer
    {
        public SizeProtocolEnforcer(ICommunicator communicator, IEncoder<string> encoder, IDecoder<string> decoder) 
            : base(communicator, encoder, decoder)
        {

        }

        public override byte[] Receive()
        {
            throw new NotImplementedException();
        }

        public override void Send(byte[] info)
        {
            throw new NotImplementedException();
        }
    }
}

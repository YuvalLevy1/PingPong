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

        protected ProtocolEnforcer(ICommunicator communicator)
        {
            _communicator = communicator;
        }

        public abstract void Send(byte[] info);
        
        public abstract byte[] Receive();
    }
}

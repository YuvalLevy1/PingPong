using Communicators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicators.ProtocolEnforcers.Abstractions
{
    public abstract class ProtocolEnforcer
    {
        private ICommunicator _communicator;

        protected ProtocolEnforcer(ICommunicator communicator)
        {
            _communicator = communicator;
        }

        public abstract void Send(byte[] info);

        public abstract byte[] Receive();
    }
}

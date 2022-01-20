using Communicators.Abstractions;

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

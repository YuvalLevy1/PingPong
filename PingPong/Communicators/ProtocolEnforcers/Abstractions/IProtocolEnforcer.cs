using Communicators.Abstractions;

namespace Communicators.ProtocolEnforcers.Abstractions
{
    public abstract class IProtocolEnforcer
    {
        protected readonly ICommunicator _communicator;

        protected IProtocolEnforcer(ICommunicator communicator)
        {
            _communicator = communicator;
        }

        public abstract void Send(byte[] info);
        
        public abstract byte[] Receive();
    }
}

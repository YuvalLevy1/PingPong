using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;

namespace Server
{
    public class Client<T>
    {
        private bool _running;
        private readonly IProtocolEnforcer _communicator;
        private IEncoder<T> _encoder;
        private IDecoder<T> _decoder;

        public Client(IProtocolEnforcer communicator, IEncoder<T> encoder, IDecoder<T> decoder)
        {
            _communicator = communicator;
            _encoder = encoder;
            _decoder = decoder;
            _running = false;
        }

        public void Start()
        {
            _running = true;

        }

        public void Connect()
        {

        }

        public void Close()
        {
            _communicator.Close();
            _running = false;
        }
    }
}

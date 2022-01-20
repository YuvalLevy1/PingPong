using Communicators.ProtocolEnforcers.Abstractions;
using Connectors.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using ProtocolEnforcerFactories.Abstractions;
using RunningStrategies.Abstractions;
using System.Net;

namespace Server
{
    public class Client<T>
    {
        private bool _running;
        private readonly IConnector _connector;
        private readonly IEncoder<T> _encoder;
        private readonly IDecoder<T> _decoder;
        private readonly IProtocolEnforcerFactory _factory;
        private readonly IRunningStrategy<T> strategy;
        private IProtocolEnforcer _server;

        public Client(
            IConnector connector,
            IEncoder<T> encoder,
            IDecoder<T> decoder,
            IProtocolEnforcerFactory factory,
            IRunningStrategy<T> strategy)
        {
            _connector = connector;
            _encoder = encoder;
            _decoder = decoder;
            _factory = factory;
            this.strategy = strategy;
            _running = false;
        }
        
        public void Start(IPAddress address, int port)
        {
            _running = true;
            Connect(address, port);
            strategy.Run(_server, _encoder, _decoder);
        }

        private void Connect(IPAddress address, int port)
        {
            _server = _connector.Connect(address, port, _factory);
        }

        public void Close()
        {
            _server.Close();
            _running = false;
        }
    }
}

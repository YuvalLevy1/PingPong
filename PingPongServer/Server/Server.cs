using ClientHandelingStrategies.Abstractions;
using Communicators.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using Listeners.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server
{
    public class Server<T>
    {
        private bool _running;
        private readonly IListener _listener;
        private readonly IClientHandelingStrategy<T> _strategy;
        private List<ICommunicator> _clients;
        private IEncoder<T> _encoder;
        private IDecoder<T> _decoder;

        public Server(IListener listener, IClientHandelingStrategy<T> strategy, IEncoder<T> encoder, IDecoder<T> decoder)
        {
            _listener = listener;
            _strategy = strategy;
            _encoder = encoder;
            _decoder = decoder;
            _running = false;
            _clients = new List<ICommunicator>();
        }

        private ICommunicator Listen()
        {
            return _listener.Listen();
        }

        public void Start()
        {
            while (_running)
            {
                var client = Listen();
                _clients.Add(client);
                Task.Run(() => _strategy.Run(client, _clients, _encoder, _decoder));
            }
        }

        public void Close()
        {
            _listener.Close();
            _running = false;
            foreach (var client in _clients)
            {
                client.Close();
            }
        }
    }
}

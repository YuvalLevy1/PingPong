using Connectors;
using DataHandlers.Decoders;
using DataHandlers.Encoders;
using ProtocolEnforcerFactories;
using RunningStrategies;
using Server;

namespace Application
{
    public class EchoClientBootstrapper
    {
        public Client<string> GetClient()
        {
            var decoder = new StringDecoder();
            var encoder = new StringEncoder();
            var protocolFactory = new SizeProtocolFactory(1024, 4, encoder, decoder);
            var strategy = new EchoStrategy();
            var connector = new SocketConnector();
            return new Client<string>(connector, encoder, decoder, protocolFactory, strategy);
        }
    }
}

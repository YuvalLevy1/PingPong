using Connectors;
using DataHandlers.Decoders;
using DataHandlers.Encoders;
using ProtocolEnforcerFactories;
using RunningStrategies;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

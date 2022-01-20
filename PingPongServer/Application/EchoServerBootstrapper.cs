using ClientHandelingStrategies;
using DataHandlers.Decoders;
using DataHandlers.Encoders;
using Listeners;
using Server;

namespace Application
{
    class EchoServerBootstrapper
    {
        public Server<string> GetServer(int port)
        {
            var listener = new SocketListener(port);
            var serverStrategy = new EchoStrategy();
            var decoder = new StringDecoder();
            var encoder = new StringEncoder();
            return new Server<string>(listener, serverStrategy, encoder, decoder);
        }
    }
}

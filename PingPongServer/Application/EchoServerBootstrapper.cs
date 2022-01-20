﻿using ClientHandelingStrategies;
using ProtocolEnforcerFactories;
using DataHandlers.Decoders;
using DataHandlers.Encoders;
using Listeners;
using Server;
using Utils;
using Communicators.ProtocolEnforcers.Abstractions;

namespace Application
{
    class EchoServerBootstrapper
    {
        public Server<string> GetServer(int port)
        {
            var decoder = new StringDecoder();
            var encoder = new StringEncoder();
            var protocolFactory = new SizeProtocolFactory(1024, 4, encoder, decoder);
            var listener = new SocketListener(port, protocolFactory);
            var serverStrategy = new EchoStrategy();
            return new Server<string>(listener, serverStrategy, encoder, decoder, new ConcurrentHashSet<IProtocolEnforcer>());
        }
    }
}

using ClientHandelingStrategies.Abstractions;
using Communicators.Abstractions;
using System;

namespace ClientHandelingStrategies
{
    class EchoStrategy : IClientHandelingStrategy
    {
        public void Run(ICommunicator client)
        {
            throw new NotImplementedException();
        }
    }
}

using Communicators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientHandelingStrategies.Abstractions
{
    public interface IClientHandelingStrategy
    {
        public void Run(ICommunicator client);
    }
}

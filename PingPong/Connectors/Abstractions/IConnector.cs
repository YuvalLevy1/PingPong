using Communicators.ProtocolEnforcers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Connectors.Abstractions
{
    interface IConnector
    {
        public IProtocolEnforcer Connect(IPAddress address, int port);
    }
}

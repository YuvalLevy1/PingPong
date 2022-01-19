using Communicators.Abstractions;
using Listeners.Abstractions;
using System;

namespace Server
{
    public class Server
    {
        private IListener listener;

        public Server(IListener listener)
        {
            this.listener = listener;
        }
    }
}

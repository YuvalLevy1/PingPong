using Communicators.Abstractions;
using Listeners.Abstractions;
using System.Collections.Generic;

namespace Server
{
    public class Server
    {
        private IListener _listener;
        private bool _running;
        private List<ICommunicator> clients;

        public Server(IListener listener)
        {
            _listener = listener;
            _running = false;
        }
        
        private ICommunicator Listen()
        {
            return _listener.Listen();
        }

        public void Start()
        {

        }

        public void Close()
        {
            _listener.Close();
            _running = false;
            foreach (var client in clients)
            {
                client.Close();
            }
        }
    }
}

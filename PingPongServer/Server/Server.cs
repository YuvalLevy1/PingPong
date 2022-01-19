using Communicators.Abstractions;
using Listeners.Abstractions;

namespace Server
{
    public class Server
    {
        private IListener _listener;
        private bool _running;

        public Server(IListener listener)
        {
            _listener = listener;
            _running = false;
        }
        
        private ICommunicator Listen()
        {
            return _listener.Listen();
        }

        public void Close()
        {
            _listener.Close();
            _running = false;
        }
    }
}


using System.Net;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            EchoClientBootstrapper bootstrapper = new EchoClientBootstrapper();
            var client = bootstrapper.GetClient();
            client.Start(IPAddress.Parse("192.168.56.1"), 7070);
        }
    }
}

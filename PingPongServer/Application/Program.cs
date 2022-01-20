
namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new EchoServerBootstrapper().GetServer(7070);
            server.Start();
        }
    }
}

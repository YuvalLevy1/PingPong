using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new EchoServerBootstrapper().GetServer(int.Parse(args[0]));
            server.Start();
        }
    }
}

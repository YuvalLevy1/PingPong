using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using RunningStrategies.Abstractions;
using System;

namespace RunningStrategies
{
    public class EchoStrategy : IRunningStrategy<string>
    {
        public void Run(IProtocolEnforcer server, IEncoder<string> encoder, IDecoder<string> decoder)
        {
            string data;
            while (true)
            {
                try
                {
                    Console.WriteLine("enter string to echo: ");
                    data = Console.ReadLine();
                    server.Send(encoder.Encode(data));
                    if (data.Equals("end"))
                    {
                        Console.WriteLine("");
                        server.Close();
                        break;
                    }
                    data = decoder.Decode(server.Receive());
                    Console.WriteLine($"received data:{data}");
                    
                }
                catch (Exception)
                {
                    server.Close();
                    break;
                }
            }
        }
    }
}

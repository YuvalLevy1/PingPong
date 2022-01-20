using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using RunningStrategies.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStrategies
{
    public class EchoStrategy : IRunningStrategy<string>
    {
        public void Run(IProtocolEnforcer client, IEncoder<string> encoder, IDecoder<string> decoder)
        {
            string data;
            while (true)
            {
                try
                {
                    Console.WriteLine("enter string to echo: ");
                    data = Console.ReadLine();
                    client.Send(encoder.Encode(data));

                    data = decoder.Decode(client.Receive());
                    Console.WriteLine($"received data:{data}");
                    if (data.Equals("end"))
                    {
                        Console.WriteLine("closing program");
                        client.Close();
                        break;
                    }
                    client.Send(encoder.Encode(data));
                }
                catch (Exception)
                {
                    client.Close();
                    break;
                }
            }
        }
    }
}

using ClientHandelingStrategies.Abstractions;
using Communicators.Abstractions;
using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using System;
using Utils;

namespace ClientHandelingStrategies
{
    public class EchoStrategy : IClientHandelingStrategy<string>
    {
        public void Run(IProtocolEnforcer client, ConcurrentHashSet<IProtocolEnforcer> clients, IEncoder<string> encoder, IDecoder<string> decoder)
        {
            string data;
            while (true)
            {
                try
                {
                    data = decoder.Decode(client.Receive());
                    Console.WriteLine($"received data:{data}");
                    if (data.Equals("end"))
                    {
                        client.Close();
                        clients.Remove(client);
                        break;
                    }
                    client.Send(encoder.Encode(data));
                    data = string.Empty;
                }
                catch (Exception)
                {
                    clients.Remove(client);
                    client.Close();
                    break;
                }
            }
        }
    }
}

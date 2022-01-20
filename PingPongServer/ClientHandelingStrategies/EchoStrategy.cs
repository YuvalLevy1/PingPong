using ClientHandelingStrategies.Abstractions;
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
                    client.Send(encoder.Encode(data));
                    data = string.Empty;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    clients.Remove(client);
                    client.Close();
                    break;
                }
            }
        }
    }
}

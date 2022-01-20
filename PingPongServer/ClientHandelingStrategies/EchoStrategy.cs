using ClientHandelingStrategies.Abstractions;
using Communicators.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using System;
using Utils;

namespace ClientHandelingStrategies
{
    class EchoStrategy : IClientHandelingStrategy<string>
    {
        public void Run(ICommunicator client, ConcurrentHashSet<ICommunicator> clients, IEncoder<string> encoder, IDecoder<string> decoder)
        {
            string data;
            byte[] encodedData;
            while (true)
            {
                try
                {
                    data = decoder.Decode(client.Receive(4));
                    data = decoder.Decode(client.Receive(int.Parse(data)));
                    Console.WriteLine($"data received: {data}");
                    if (data == "end")
                    {
                        client.Send(encoder.Encode("end"));
                        clients.Remove(client);
                        client.Close();
                        break;
                    }
                    encodedData = encoder.Encode(data);
                    client.Send(encoder.Encode($"{encodedData.Length}"));
                    client.Send(encodedData);
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

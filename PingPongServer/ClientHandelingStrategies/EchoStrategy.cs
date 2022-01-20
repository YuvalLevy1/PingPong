using ClientHandelingStrategies.Abstractions;
using Communicators.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientHandelingStrategies
{
    class EchoStrategy : IClientHandelingStrategy<string>
    {
        public void Run(ICommunicator client, ICollection<ICommunicator> clients, IEncoder<string> encoder, IDecoder<string> decoder)
        {
            string data;
            byte[] encodedData;
            while (true)
            {
                data = decoder.Decode(client.Receive(4));
                data = decoder.Decode(client.Receive(int.Parse(data)));
                Console.WriteLine($"data received: {data}");
                if (data == "end")
                {
                    client.Send(encoder.Encode("end"));
                    client.Close();
                    clients.Remove(client);
                    break;
                }
                encodedData = encoder.Encode(data);
                client.Send(encoder.Encode($"{encodedData.Length}"));
                client.Send(encodedData);
            }
        }
    }
}

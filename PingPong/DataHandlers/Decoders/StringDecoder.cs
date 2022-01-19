using DataHandlers.Decoders.Abstractions;
using System;

namespace DataHandlers.Decoders
{
    public class StringDecoder : IDecoder<string>
    {
        public string Decode(byte[] info)
        {
            return System.Text.Encoding.Default.GetString(info);
        }
    }
}

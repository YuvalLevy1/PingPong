using DataHandlers.Decoders.Abstractions;

namespace DataHandlers.Decoders
{
    public class StringDecoder : IDecoder<string>
    {
        public string Decode(byte[] info)
        {
            return System.Text.Encoding.UTF8.GetString(info);
        }
    }
}

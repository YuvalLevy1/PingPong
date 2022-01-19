using DataHandlers.Encoders.Abstractions;

namespace DataHandlers.Encoders
{
    public class StringEncoder : IEncoder<string>
    {
        public byte[] Encode(string info)
        {
            return System.Text.Encoding.Default.GetBytes(info);
        }

    }
}

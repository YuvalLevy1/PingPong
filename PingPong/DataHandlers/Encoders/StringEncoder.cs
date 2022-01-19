
using DataHandlers.Encoders.Abstractions;

namespace DataHandlers.Encoders
{
    public class StringEncoder : IEncoder<string>
    {
        public string Translate(byte[] info)
        {
            return System.Text.Encoding.Default.GetString(info);
        }
    }
}

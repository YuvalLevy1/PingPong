
namespace DataHandlers.Encoders.Abstractions
{
    public interface IEncoder<T>
    {
        public byte[] Encode(T info);
    }
}

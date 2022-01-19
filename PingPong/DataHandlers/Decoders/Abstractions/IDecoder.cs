
namespace DataHandlers.Decoders.Abstractions
{
    public interface IDecoder<T>
    {
        public T Decode(byte[] info);
    }
}

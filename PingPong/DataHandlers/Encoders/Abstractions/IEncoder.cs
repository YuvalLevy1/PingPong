
namespace DataHandlers.Encoders.Abstractions
{
    public interface IEncoder<T>
    {
        public T Translate(byte[] info);
    }
}

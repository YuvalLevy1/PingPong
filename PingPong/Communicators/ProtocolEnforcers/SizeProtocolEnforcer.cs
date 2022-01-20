using Communicators.Abstractions;
using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Communicators.ProtocolEnforcers
{
    public class SizeProtocolEnforcer : IProtocolEnforcer
    {
        private readonly IEncoder<string> _encoder;
        private readonly IDecoder<string> _decoder;
        private readonly int _sizeOfLength;
        private readonly int _sizeOfBuffer;

        public SizeProtocolEnforcer(
            ICommunicator communicator,
            IEncoder<string> encoder,
            IDecoder<string> decoder,
            int sizeOfLength,
            int sizeOfBuffer)
            : base(communicator)
        {
            _encoder = encoder;
            _decoder = decoder;
            _sizeOfLength = sizeOfLength;
            _sizeOfBuffer = sizeOfBuffer;
        }

        public override void Close()
        {
            _communicator.Close();
        }

        public override byte[] Receive()
        {
            List<byte> data = new List<byte>();
            byte[] bufferLength = new byte[_sizeOfLength];
            byte[] buffer = new byte[_sizeOfBuffer];
            var dataLength = _communicator.Receive(bufferLength);
            System.Console.WriteLine(_decoder.Decode(bufferLength.Take(dataLength).ToArray()));
            var length = int.Parse(_decoder.Decode(bufferLength.Take(dataLength).ToArray()));
            while (data.Count < length)
            {
                dataLength = _communicator.Receive(buffer);
                data.AddRange(buffer.Take(dataLength));
            }
            return data.ToArray();
        }

        public override void Send(byte[] info)
        {
            byte[][] slicedInfo = ArraySlicer(info, _sizeOfBuffer);
            byte[] infoLength = new byte[_sizeOfLength];
            byte[] encodedLength = _encoder.Encode($"{info.Length}");
            for (int i = 0; i < encodedLength.Length; i++)
            {
                infoLength[i] = encodedLength[i];
            }
            _communicator.Send(infoLength);
            for (int i = 0; i < slicedInfo.Length; i++)
            {
                _communicator.Send(slicedInfo[i]);
            }
        }

        private byte[][] ArraySlicer(byte[] info, int sizeOfPacket)
        {
            byte[][] slicedInfo = new byte[info.Length / sizeOfPacket + 1][];
            for (int i = 0; i < slicedInfo.Length; i++)
            {
                var buffer = info.Take(sizeOfPacket).ToArray();
                slicedInfo[i] = buffer;
                info.CopyTo(info, i * sizeOfPacket);
            }
            return slicedInfo;
        }
    }
}

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
            Send(_encoder.Encode("end"));
            _communicator.Close();
        }

        public override byte[] Receive()
        {
            List<byte> data = new List<byte>();
            byte[] buffer;
            var length = int.Parse(_decoder.Decode(_communicator.Receive(_sizeOfLength)));
            while (data.Count < length)
            {
                buffer = _communicator.Receive(_sizeOfBuffer);
                data.AddRange(buffer);
            }
            return data.ToArray();
        }

        public override void Send(byte[] info)
        {
            byte[][] slicedInfo = ArraySlicer(info, _sizeOfBuffer);
            _communicator.Send(_encoder.Encode($"{info.Length}"));
            for (int i = 0; i < slicedInfo.Length; i++)
            {
                _communicator.Send(slicedInfo[i]);
            }
        }

        private byte[][] ArraySlicer(byte[] info, int sizeOfPacket)
        {
            byte[][] slicedInfo = new byte[info.Length / sizeOfPacket][];
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

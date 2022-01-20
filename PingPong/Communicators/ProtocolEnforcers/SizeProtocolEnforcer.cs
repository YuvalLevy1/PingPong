using Communicators.Abstractions;
using Communicators.ProtocolEnforcers.Abstractions;
using DataHandlers.Decoders.Abstractions;
using DataHandlers.Encoders.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicators.ProtocolEnforcers
{
    class SizeProtocolEnforcer : ProtocolEnforcer
    {
        public SizeProtocolEnforcer(ICommunicator communicator, IEncoder<string> encoder, IDecoder<string> decoder)
            : base(communicator, encoder, decoder)
        {

        }

        public override byte[] Receive()
        {
            List<byte> data = new List<byte>();
            byte[] buffer;
            var length = int.Parse(_decoder.Decode(_communicator.Receive(4)));
            while (data.Count < length)
            {
                buffer = _communicator.Receive(1024);
                data.AddRange(buffer);
            }
            return data.ToArray();
        }

        public override void Send(byte[] info)
        {
            byte[][] slicedInfo = ArraySlicer(info, 1024);
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

using System.IO;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbEncryptionKeyRequest : CbPacket
    {
        private string ServerId;
        private byte[] EncodedKey;
        private byte[] VerifyToken;

        public CbEncryptionKeyRequest(string serverId, byte[] encodedKey, byte[] verifyToken)
        {
            ServerId = serverId;
            EncodedKey = encodedKey;
            VerifyToken = verifyToken;
        }
        protected override void Write(BinaryWriter writer)
        {
            WriteString(writer, ServerId);
            WriteBytes(writer, EncodedKey);
            WriteBytes(writer, VerifyToken);
            
        }
    }
}

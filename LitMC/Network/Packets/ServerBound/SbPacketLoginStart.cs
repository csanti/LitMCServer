using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Utils;
using LitMC.Network;
using LitMC.Network.Packets.ClientBound;
using System.Security.Cryptography;
using LitMC.Network.Security;

namespace LitMC.Network.Packets.ServerBound
{
    public class SbPacketLoginStart : SbPacket
    {
        string username;

        public override void Process()
        {
            Log.Debug("[PACKET] LoginStart - Username: {0}", username);

            var verifyToken = new byte[4];
            var csp = new RNGCryptoServiceProvider();
            csp.GetBytes(verifyToken);
            Connection.VerificationToken = verifyToken;

            var encodedKey = AsnKeyBuilder.PublicKeyToX509(TcpServer.ServerKey);

            string serverId = "";
            var random = RandomNumberGenerator.Create();
            byte[] data = new byte[8];
            random.GetBytes(data);            
            foreach (byte b in data)
                serverId += b.ToString("X2");

            new CbEncryptionKeyRequest(serverId, encodedKey.GetBytes(), verifyToken).Send(Connection);
        }

        public override void Read()
        {
            username = ReadString();

        }
    }
}

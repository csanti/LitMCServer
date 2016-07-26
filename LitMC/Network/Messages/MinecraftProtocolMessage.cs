using Hik.Communication.Scs.Communication.Messages;

namespace LitMC.Network.Messages
{
    class MinecraftProtocolMessage : ScsMessage
    {
        public byte PacketId;
        public byte[] Data;

    }
}

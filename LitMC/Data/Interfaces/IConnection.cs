using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Data.Interfaces
{
    public interface IConnection
    {
        Player Player { get; set; }

        void Close();
        void PushPacket(byte[] data);
        long Ping();
    }
}

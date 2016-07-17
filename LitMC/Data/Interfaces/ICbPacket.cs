using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Data.Interfaces
{
    public interface ICbPacket
    {
        void Send(IConnection connection);
    }
}

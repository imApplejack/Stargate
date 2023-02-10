using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{
    public class StargateEventArgs : EventArgs
    {
        public override string ToString()
        {
            return "StargateEventArgs call handler kikoo";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate
{



    public enum EventType
    {
        PLAYCARD
    }


    public class StargateEvent
    {

        public EventType Type { get; set; }

        
    }
}

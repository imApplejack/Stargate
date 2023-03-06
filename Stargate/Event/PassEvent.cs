using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{

  
    public class PassEvent : StargateEvent
    {

        public PassEvent()
        {
            Type = EventType.PASS;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{

    public enum EventType
    {
        PLAYCARD,
        DRAWCARD
    }


    public class StargateEvent
    {

        public EventType Type { get; set; }

        public List<Object> Data { get; set; } 


    }
}

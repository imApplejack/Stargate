using Stargate.Stargate.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate
{
    public class NetworkEvent : Godot.Object
    {

        public NetworkEvent(StargateEvent _stargateEvent)
        {
            stargateEvent = _stargateEvent;
        }

        public StargateEvent stargateEvent { get; set; }

    }
}

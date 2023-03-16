using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{



    public class NetworkPassEvent : NetworkStargateEvent
    {

        public NetworkPassEvent(int senderId)
        {
            Sender = senderId;
        }

        public NetworkPassEvent()
        {
        }


        public override StargateEvent GenerateStargateEvent(params object[] list)
        {
            return new PassEvent() { SenderId = (int)list[0] };
        }
        public override object[] RPCAttr(StargateEvent eEvent)
        {
            PassEvent e = eEvent as PassEvent;
            return new object[] { e.SenderId };
        }


        public static new string RPCMethod()
        {
            return nameof(NetworkPassEvent);
        }

    }

    public class PassEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new NetworkPassEvent((int)SenderId);
        }

        public PassEvent()
        {
            Type = EventType.PASS;

        }

      
    }
}

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


        public override StargateEvent GenerateStargateEvent()
        {
            return new PassEvent() { SenderId = Sender };
        }
        public override object[] RPCAttr()
        {
            return new object[] { Sender };
        }


        public override string RPCMethod()
        {
            return "NetworkPassEvent";
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

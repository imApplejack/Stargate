using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{

  
    public enum ContinueQuestEventResponse
    {
        YES,
        NO
    }

    public class NetworkContinueQuestEvent : NetworkStargateEvent
    {
        public ContinueQuestEventResponse response;

        public NetworkContinueQuestEvent(int senderId, ContinueQuestEventResponse _response)
        {
            response = _response;
            Sender = senderId;
        }

        public NetworkContinueQuestEvent()
        {
        }

        public override StargateEvent GenerateStargateEvent(params object[] list)
        {
            return new ContinueQuestEvent() { SenderId = (int)list[0], response = (ContinueQuestEventResponse)list[1] };
        }

        public override object[] RPCAttr(StargateEvent eEvent)
        {

            ContinueQuestEvent e = eEvent as ContinueQuestEvent;
            return new object[] { e.SenderId, e.response };
        }

        public static new string RPCMethod()
        {
            return nameof(NetworkContinueQuestEvent);
        }
    }

    public class ContinueQuestEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new NetworkContinueQuestEvent((int)SenderId, response);
        }

        public ContinueQuestEventResponse response;

        public ContinueQuestEvent()
        {
            Type = EventType.CONTINUEQUEST;
        }

        

        public override string ToString()
        {
            return base.ToString() + " " + response;
        }
    }
}

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

    public class NetworkContinueQuestCardEvent : NetworkStargateEvent
    {
        public ContinueQuestEventResponse response;

        public NetworkContinueQuestCardEvent(int senderId, ContinueQuestEventResponse _response)
        {
            response = _response;
            Sender = senderId;
        }

        public override StargateEvent GenerateStargateEvent()
        {
            return new ContinueQuestEvent() { response = response, SenderId = Sender };
        }

        public override object[] RPCAttr()
        {
            return new object[] { Sender, response };
        }

        public override string RPCMethod()
        {
            return "NetworkContinueQuestCardEvent";
        }
    }

    public class ContinueQuestEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new NetworkContinueQuestCardEvent((int)SenderId, response);
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

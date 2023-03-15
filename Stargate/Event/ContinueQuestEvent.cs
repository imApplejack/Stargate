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

    public class ContinueQuestCardEvent : NetworkStargateEvent
    {
        public ContinueQuestEventResponse response;

        public ContinueQuestCardEvent(int senderId, ContinueQuestEventResponse _response)
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
            throw new NotImplementedException();
        }

        public override string RPCMethod()
        {
            return "ContinueQuestCardEvent";
        }
    }

    public class ContinueQuestEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new ContinueQuestCardEvent((int)SenderId, response);
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

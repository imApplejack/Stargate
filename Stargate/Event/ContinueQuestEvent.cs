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
        public override StargateEvent GenerateStargateEvent()
        {
            return new ContinueQuestEvent() { response = response, SenderId = Sender };
        }

        public override object[] RPCAttr()
        {
            throw new NotImplementedException();
        }
    }

    public class ContinueQuestEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new ContinueQuestCardEvent() { response = response, Sender = (int)SenderId };
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

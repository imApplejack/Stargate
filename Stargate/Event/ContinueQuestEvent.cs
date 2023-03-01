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

    public class ContinueQuestEvent : StargateEvent
    {

        public ContinueQuestEventResponse response;

        public ContinueQuestEvent()
        {
            Type = EventType.CONTINUEQUEST;
        }
    }
}

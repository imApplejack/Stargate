using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{

  
    public class SelectCardEvent : StargateEvent
    {

        public CardModel cardModel { get; set; }

        public SelectCardEvent()
        {
            Type = EventType.SELECTCARD;

        }

        public override string ToString()
        {
            return base.ToString() + " " + cardModel;
        }



    }
}

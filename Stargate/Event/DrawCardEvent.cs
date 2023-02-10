using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{

  


    public class DrawCardEvent : StargateEvent
    {

        Player p;

        CardModel cardModel;


        public DrawCardEvent()
        {
            Type = EventType.DRAWCARD;

        }



    }
}

using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{

  


    public class PlayCardEvent : StargateEvent
    {

        public Player player  { get; set; }

        public CardModel cardModel { get; set; }


        public PlayCardEvent()
        {
            Type = EventType.PLAYCARD;

        }

        public override string ToString()
        {
            return base.ToString() + " " + player + " " + cardModel;
        }



    }
}

using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{


    public class AssignCharEvent : StargateEvent
    {


        public CardModel cardModel { get; set; }

        public int? CardModelId { get; set; }

        public AssignCharEvent()
        {
            Type = EventType.ASSIGNCHAR;

        }


        public override void Hydrate(StargateGame game)
        {
            base.Hydrate(game);
            if (CardModelId != null)
            {
                cardModel = game.GameState.CardRepository.GetCardModelFromId((int)CardModelId);
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + cardModel;
        }



    }
}

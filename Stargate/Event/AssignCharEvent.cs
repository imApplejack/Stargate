using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{


    public class NetworkAssignCharEvent : NetworkStargateEvent
    {
        public int cardModel;
        public override StargateEvent GenerateStargateEvent()
        {
            return new AssignCharEvent() { CardModelId = cardModel, SenderId = Sender };
        }

        public override object[] RPCAttr()
        {
            throw new NotImplementedException();
        }
    }


    public class AssignCharEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return  new NetworkAssignCharEvent() { cardModel = (int)CardModelId, Sender = (int)SenderId } ;
        }


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
            return base.ToString() + " CardModel " + CardModelId + " " + cardModel;
        }

       
    }
}

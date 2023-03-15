using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{


    public class NetworkBoostCharEvent : NetworkStargateEvent
    {
        public int cardModel;
        public override StargateEvent GenerateStargateEvent()
        {
            return new BoostCharEvent() { CardModelId = cardModel, SenderId = Sender };
        }
        public override object[] RPCAttr()
        {
            throw new NotImplementedException();
        }

    }


    public class BoostCharEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new NetworkBoostCharEvent() { cardModel = (int)CardModelId, Sender = (int)SenderId };
        }

        public CardModel cardModel { get; set; }

        public int? CardModelId { get; set; }

        public BoostCharEvent()
        {
            Type = EventType.BOOSTCHAR;
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
            return base.ToString() +  " CardModel " + CardModelId + " " + cardModel;
        }

        
    }
}

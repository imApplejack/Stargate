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


    public class NetworkPlayCardEvent : NetworkStargateEvent
    {
        public int cardModel;
        public override StargateEvent GenerateStargateEvent()
        {
            return new PlayCardEvent() { CardModelId = cardModel, SenderId = Sender };
        }
    }

    public class PlayCardEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new NetworkPlayCardEvent() { cardModel = (int)CardModelId, Sender = (int)SenderId };
        }

        public CardModel cardModel { get; set; }

        public int? CardModelId { get; set; }

        public PlayCardEvent()
        {
            Type = EventType.PLAYCARD;

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

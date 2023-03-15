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


    public class BoostCharEvent : StargateEvent
    {


        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            throw new NotImplementedException();
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

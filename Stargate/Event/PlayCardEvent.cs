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

        public NetworkPlayCardEvent(int senderId, int CardModelId)
        {
            cardModel = CardModelId;
            Sender = senderId;
        }

        public override StargateEvent GenerateStargateEvent()
        {
            return new PlayCardEvent() { CardModelId = cardModel, SenderId = Sender };
        }

        public override object[] RPCAttr()
        {
            throw new NotImplementedException();
        }


        public override string RPCMethod()
        {
            return "NetworkPlayCardEvent";
        }

    }

    public class PlayCardEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new NetworkPlayCardEvent((int)SenderId, (int)CardModelId);
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

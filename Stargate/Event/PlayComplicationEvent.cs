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



    public class NetworkPlayComplicationEvent : NetworkStargateEvent
    {
        public int cardModel;


        public NetworkPlayComplicationEvent(int senderId, int CardModelId)
        {
            cardModel = CardModelId;
            Sender = senderId;
        }

        public NetworkPlayComplicationEvent()
        {
        }

        public override StargateEvent GenerateStargateEvent(params object[] list)
        {
            return new PlayComplicationEvent() { SenderId = (int)list[0], CardModelId = (int)list[1] };
        }

        public override object[] RPCAttr(StargateEvent eEvent)
        {
            PlayCardEvent e = eEvent as PlayCardEvent;
            return new object[] { e.Sender, e.cardModel };
        }

        public static new string RPCMethod()
        {
            return nameof(NetworkPlayComplicationEvent);
        }
    }


    public class PlayComplicationEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new NetworkPlayComplicationEvent((int)SenderId, (int)CardModelId);
        }


        public CardModel cardModel { get; set; }

        public int? CardModelId { get; set; }

        public PlayComplicationEvent()
        {
            Type = EventType.PLAYCOMPLICATION;

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

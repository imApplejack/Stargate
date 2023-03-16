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

        public NetworkBoostCharEvent(int senderId, int CardModelId)
        {
            cardModel = CardModelId;
            Sender = senderId;
        }

        public NetworkBoostCharEvent()
        {
        }

        public override StargateEvent GenerateStargateEvent(params object[] list)
        {
            return new BoostCharEvent() { SenderId = (int)list[0], CardModelId = (int)list[1] };
        }
        public override object[] RPCAttr(StargateEvent eEvent)
        {
            BoostCharEvent e = eEvent as BoostCharEvent;
            return new object[] { e.SenderId, e.CardModelId };
        }

         public static new string RPCMethod()
        {
            return nameof(NetworkAssignCharEvent);
        }
    }


    public class BoostCharEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new NetworkBoostCharEvent((int)SenderId, (int)CardModelId );
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

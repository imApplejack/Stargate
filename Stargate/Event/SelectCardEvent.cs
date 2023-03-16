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

    public class NetworkSelectCardEvent : NetworkStargateEvent {


        public Godot.Collections.Array<int> cardModels = new Godot.Collections.Array<int>();

        public NetworkSelectCardEvent(int senderId, List<int> CardModelIds)
        {
            Sender = senderId;
            cardModels = new Godot.Collections.Array<int>(CardModelIds);
        }

        public NetworkSelectCardEvent()
        {
        }

        public override object[] RPCAttr(StargateEvent eEvent)
        {
            SelectCardEvent e = eEvent as SelectCardEvent;
            return new object[] { e.SenderId, new Godot.Collections.Array<int>(e.CardModelId) };
        }

        public override StargateEvent GenerateStargateEvent(params object[] list)
        {
            Godot.Collections.Array<int> e = new Godot.Collections.Array<int>((Godot.Collections.Array)list[1]);
            List<int> tiit = new List<int>(e);
            return new SelectCardEvent() { SenderId = (int)list[0], CardModelId = tiit };
        }

        public static new string RPCMethod()
        {
            return nameof(NetworkSelectCardEvent);
        }
    }


    public class SelectCardEvent : StargateEvent
    {

        public override NetworkStargateEvent GenerateNetworkStargateEvent()
        {
            return new NetworkSelectCardEvent((int)SenderId, CardModelId);
        }


        public List<CardModel> cardModel { get; set; } = new List<CardModel>();

        public List<int> CardModelId { get; set; } = new List<int>();    

        public SelectCardEvent()
        {
            Type = EventType.SELECTCARD;

        }

        public override string ToString()
        {
            return base.ToString() + " CardModel " + CardModelId + " " + cardModel;
        }

        public override void Hydrate(StargateGame game)
        {
            base.Hydrate(game);

            foreach (int cardId in CardModelId) {
                cardModel.Add(game.GameState.CardRepository.GetCardModelFromId(cardId));
            }
        }

       
    }
}

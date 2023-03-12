using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{


    public class SelectCardEvent : StargateEvent
    {

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

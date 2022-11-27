using Stargate.Stargate;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Repository
{
    public class CardRepository
    {


        private List<CardModel> Cards = new List<CardModel>();

        // librairie à part pour des raisons de cassecouilleness shuffle ect...
        public Dictionary<Player, CardModel> Libraries = new Dictionary<Player, CardModel>();


        public CardModel AddCard(CardModel card)
        {
            int id = Cards.Count;
            this.Cards.Add(card);
            card.Id = id;
            return card;
        }

        public void InitPlayersLibrary()
        {
            Libraries = new Dictionary<Player, CardModel>();

            foreach (CardModel card in this.Cards)
            {
                if(card.State == CardState.Library && card.Owner is Player)
                {
                    Libraries.Add(card.Owner, card);
                }
            }
        }



        public List<CardModel> GetCall()
        {
            return this.Cards;
        }

        public CardModel findById(int id)
        {
            return this.Cards[id];
        }

    }
}

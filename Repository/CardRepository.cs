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

        public List<CardModel> Cards = new List<CardModel>();

        // librairie à part pour des raisons de cassecouilleness shuffle ect...
        public Dictionary<Player, List<CardModel>> Libraries = new Dictionary<Player, List<CardModel>>();


        public CardModel AddCard(CardModel card)
        {
            int id = Cards.Count;
            this.Cards.Add(card);
            card.Id = id;
            return card;
        }

        public void InitPlayersLibrary()
        {
            Libraries = new Dictionary<Player, List<CardModel>>();

            foreach (CardModel card in this.Cards)
            {
                if(card.State == CardState.Library && card.Owner is Player)
                {
                    if(Libraries.ContainsKey(card.Owner))
                    {
                        Libraries[card.Owner].Add(card);
                    }
                    else
                    {
                        Libraries.Add(card.Owner, new List<CardModel>());
                        Libraries[card.Owner].Add(card);
                    }
                }
            }
        }

        public List<CardModel> GetAll()
        {
            return this.Cards;
        }

        public CardModel findById(int id)
        {
            return this.Cards[id];
        }

    }
}

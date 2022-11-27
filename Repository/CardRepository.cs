using Stargate.Stargate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Repository
{
    public class CardRepository
    {
        private List<CardModel> Cards= new List<CardModel>();

        public CardModel AddCard(CardModel card)
        {
            int id = Cards.Count;
            Cards.Add(card);
            card.Id = id;
            return card;
        }

    }
}

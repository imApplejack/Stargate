using Stargate.Repository;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Service
{
    public class CardService
    {

        public CardRepository CardRepository { get; set; } = new CardRepository();

        public CardModel CreateCardModel(SGCard card)
        {
            return new CardModel(card);
        }


        /** 
         * generate deck from card template for player
         */
        public void CreatePlayerLibrary(Player player, List<SGCard> cards)
        {
            foreach(SGCard card in cards)
            {
                CardModel cl = new CardModel(card) { Owner = player, State = CardState.Library };
                this.CardRepository.AddCard(cl);
            }
        }
    }
}

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
        public void CreatePlayerDeck(Player player, List<SGCard> cards)
        {
            foreach(SGCard card in cards)
            {
                // faire des if pour verifier la pertinance IsNotTeam
                CardModel cl = new CardModel(card) { Owner = player, State = CardState.Library };
                this.CardRepository.AddCard(cl);
            }
        }

        public void CreatePlayerTeam(Player player, List<SGCard> cards)
        {
            foreach (SGCard card in cards)
            {
                // faire des if pour verifier la pertinance Isteam
                CardModel cl = new CardModel(card) { Owner = player, State = CardState.Team };
                this.CardRepository.AddCard(cl);
            }
        }

        public void InitPlayersLibrary()
        {
            this.CardRepository.InitPlayersLibrary();
        }
    }
}

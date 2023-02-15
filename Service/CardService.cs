using Stargate.Repository;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
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

        public List<CardModel> GetAllCards()
        {
            return this.CardRepository.GetAll();
        }


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
                // faire des if pour verifier la pertinance IsTeam
                CardModel cl = new CardModel(card) { Owner = player, State = CardState.Team };
                this.CardRepository.AddCard(cl);
            }
        }

        public void CreatePlayerMissions(Player player, List<SGCard> cards)
        {
            foreach (SGCard card in cards)
            {
                // faire des if pour verifier la pertinance isMission
                CardModel cl = new CardModel(card) { Owner = player, State = CardState.MissionPile };
                this.CardRepository.AddCard(cl);
            }
        }


        public StargateResult PlayCard(PlayCardEvent playCardEvent){
            if (CardRepository.IsInHand(playCardEvent.player, playCardEvent.cardModel) && playCardEvent.player.Energy >= playCardEvent.cardModel.Card.Cost)
            {
                playCardEvent.player.Energy -= playCardEvent.cardModel.Card.Cost;
                playCardEvent.cardModel.State = CardState.Ready; // probablement passer par le repository pour faire ca
                return new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = playCardEvent.cardModel };
            }
            else
            {
                return new StargateResult() { actionResult = ActionResult.Failure };
            }
        }

        public StargateResult AssignChar(AssignCharEvent assignCardEvent)
        {
            if (assignCardEvent.cardModel.State == CardState.Ready || assignCardEvent.cardModel.State == CardState.Team)
            {
                assignCardEvent.cardModel.State = CardState.Mission; 
                return new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = assignCardEvent.cardModel };
            }
            else
            {
                return new StargateResult() { actionResult = ActionResult.Failure };
            }
        }


            public void InitPlayersLibraryAndMissions()
        {
            this.CardRepository.InitPlayersLibrary();
            this.CardRepository.InitPlayersMissions();
        }

        public StargateResult Draw(Player player)
        {
            return (this.CardRepository.Draw(player));
        }

        public StargateResult PlayMission(Player player)
        {
            return (this.CardRepository.PlayMission(player));
        }
    }
}

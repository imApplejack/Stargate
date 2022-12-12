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

        public Dictionary<Player, List<CardModel>> Missions = new Dictionary<Player, List<CardModel>>();


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

        public void InitPlayersMissions()
        {
            Missions = new Dictionary<Player, List<CardModel>>();

            foreach (CardModel card in this.Cards)
            {
                if (card.State == CardState.MissionPile && card.Owner is Player)
                {
                    if (Missions.ContainsKey(card.Owner))
                    {
                        Missions[card.Owner].Add(card);
                    }
                    else
                    {
                        Missions.Add(card.Owner, new List<CardModel>());
                        Missions[card.Owner].Add(card);
                    }
                }
            }
        }


        public List<CardModel> getPlayerCards(Player player)
        {
            return Cards.FindAll(cardModel => cardModel.Owner == player);
        }




        public List<CardModel> GetAll()
        {
            return this.Cards;
        }

        public CardModel findById(int id)
        {
            return this.Cards[id];
        }

        public StargateResult Draw(Player player)
        {
            /// TODO faire les cas bibliotheque vide ect... 
            try
            {
                CardModel topCardLibrary = Libraries[player][Libraries[player].Count - 1];
                topCardLibrary.State = CardState.Hand;
                Libraries[player].Remove(topCardLibrary);
                return new StargateResult { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = topCardLibrary };
            }
            catch(Exception e)
            {
                return new StargateResult { actionResult = ActionResult.Failure};
            }
        }


        public StargateResult PlayMission(Player player)
        {
            /// TODO faire les cas bibliotheque vide ect... 
            try
            {
                CardModel topCardMission = Missions[player][Missions[player].Count - 1];
                topCardMission.State = CardState.Mission;
                Libraries[player].Remove(topCardMission);
                return new StargateResult { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = topCardMission };
            }
            catch (Exception e)
            {
                return new StargateResult { actionResult = ActionResult.Failure };
            }
        }

    }
}

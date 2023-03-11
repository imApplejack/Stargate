using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using Stargate.Stargate.StargateException;
using Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Repository
{
    public class CardRepository
    {

        public List<CardModel> Cards = new List<CardModel>();

        // librairie à part pour des raisons de cassecouilleness shuffle ect...
        public Dictionary<Player, Queue<CardModel>> Libraries = new Dictionary<Player, Queue<CardModel>>();

        public Dictionary<Player, Queue<CardModel>> Missions = new Dictionary<Player, Queue<CardModel>>();

        public CardModel AddCard(CardModel card)
        {
            int id = Cards.Count;
            this.Cards.Add(card);
            card.Id = id;
            return card;
        }

        public int GetIdFromCardModel(CardModel card)
        {
            CardModel cm =  Cards.Find(cardModel => cardModel == card);
            if(cm != null)
            {
                return cm.Id;
            }
            else { return 0; }
        }

        public CardModel GetCardModelFromId(int id)
        {
            CardModel cm = Cards.Find(cardModel => cardModel.Id == id);
            if (cm != null)
            {
                //Debug.Print("trouve le bonhomme" + cm);
                return cm;
            }
            else {
                //Debug.Print("bonheomme inconnu");
                return null; }
        }


        public void InitPlayersLibrary()
        {
            Libraries = new Dictionary<Player, Queue<CardModel>>();

            foreach (CardModel card in this.Cards)
            {
                if(card.State == CardState.Library && card.Owner is Player)
                {
                    if(Libraries.ContainsKey(card.Owner))
                    {
                        Libraries[card.Owner].Enqueue(card);
                    }
                    else
                    {
                        Libraries.Add(card.Owner, new Queue<CardModel>());
                        Libraries[card.Owner].Enqueue(card);
                    }
                }
            }
        }

        public void InitPlayersMissions()
        {
            Missions = new Dictionary<Player, Queue<CardModel>>();

            foreach (CardModel card in this.Cards)
            {
                if (card.State == CardState.MissionPile && card.Owner is Player)
                {
                    if (Missions.ContainsKey(card.Owner))
                    {
                        Missions[card.Owner].Enqueue(card);
                    }
                    else
                    {
                        Missions.Add(card.Owner, new Queue<CardModel>());
                        Missions[card.Owner].Enqueue(card);
                    }
                }
            }
        }


        public List<CardModel> getPlayerCards(Player player)
        {
            return Cards.FindAll(cardModel => cardModel.Owner == player);
        }

        public List<CardModel> getPlayerCardsByState(Player player, CardState state)
        {
            return Cards.FindAll(cardModel => cardModel.Owner == player && cardModel.State == state);
        }

        public List<CardModel> getCardsByState(CardState state)
        {
            return Cards.FindAll(cardModel => cardModel.State == state);
        }


        public List<CardModel> GetAll()
        {
            return this.Cards;
        }

        public CardModel findById(int id)
        {
            return this.Cards[id];
        }



        public List<CardModel> GetPlayerTeamCharacters(Player player)
        {
            return Cards.FindAll(cardModel => cardModel.Owner == player && cardModel.Card.Type == CardType.TeamCharacter);
        }

        public List<CardModel> GetPlayerTeamCharactersReady(Player player)
        {
            return Cards.FindAll(cardModel => cardModel.Owner == player && cardModel.Card.Type == CardType.TeamCharacter && cardModel.State == CardState.Ready);
        }

        public List<CardModel> GetPlayerTeamCharactersWithGlyph(Player player)
        {
            return Cards.FindAll(cardModel => cardModel.Owner == player && ((cardModel.Card.Type & CardType.HeroPlayerCharacter) != 0) && ((HeroCharacterModel)cardModel).glyphsEarned.Count > 0  );
        }


        public bool IsInHand(Player player, CardModel card)
        {
            return Cards.Exists(cardModel => cardModel.Owner == player && cardModel.State == CardState.Hand && cardModel == card);
        }

        public List<CardModel> GetCardsInMission(Player player, CardType cardType)
        {
            return Cards.FindAll(cardModel => cardModel.State == CardState.Mission && cardModel.Owner == player && (cardModel.Card.Type & cardType) != 0); //TODO revoir cette methode

            //return Cards.FindAll(cardModel => cardModel.State == CardState.Mission && cardModel.Owner == player && cardModel.Card.Type == cardType); //TODO revoir cette methode
        }

        public List<CardModel> GetPlayerHand(Player player)
        {
            return Cards.FindAll(cardModel => cardModel.Owner == player && cardModel.State == CardState.Hand);
        }


        public List<CardModel> GetAllFailedQuest()
        {
            return Cards.FindAll(cardModel => cardModel.State == CardState.FailedQuest && cardModel.Card.Type == CardType.Mission);
        }

        public MissionModel GetCurrentMission()
        {
            return (MissionModel)Cards.Find(cardModel => cardModel.State == CardState.Mission && cardModel.Card.Type == CardType.Mission);
        }

      
        public List<CardModel> GetMissionCharacters()
        {
            return Cards.FindAll(cardModel => (cardModel.Card.Type & CardType.Character) != 0 && cardModel.State == CardState.Mission);
        }

        public AdversaryModel GetAdversaryInMissionWithSubtitle(string subtitle)
        {
            return (AdversaryModel)Cards.Find(cardModel => cardModel.State == CardState.Mission && cardModel.Card.Type == CardType.Adversary && cardModel.Card.Subtitle == subtitle);
        }

        public List<CardModel> GetCharsWithBoost()
        {
            return Cards.FindAll(cardModel =>  (cardModel.Card.Type & CardType.Character ) != 0 && ((CharacterModel)cardModel).HasBoost() );
        }



        public CardModel Draw(Player player)
        {
            /// TODO faire les cas bibliotheque vide ect... 
            try
            {
                CardModel topCardLibrary = Libraries[player].Peek();
                topCardLibrary.State = CardState.Hand;
                Libraries[player].Dequeue();

                return topCardLibrary;
               // return new StargateResult { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = topCardLibrary };
            }
            catch(Exception e)
            {
                throw new EmptyLibraryException();
            }
        }


        public CardModel PlayMission(Player player)
        {
            /// TODO faire les cas bibliotheque vide ect... 
            try
            {
                CardModel topCardMission = Missions[player].Peek();
                topCardMission.State = CardState.Mission;
                Missions[player].Dequeue();
                return topCardMission;
            }
            catch (Exception e)
            {
                throw new EmptyMissionPileException();
            }
        }

    }
}

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

    public static class Shuffler
    {
        public static void Shuffle<T>(this IList<T> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

  


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

        public void ShuffleMission(Player player, Random rng)
        {
            //Missions[player].ToList();
            List<CardModel> a = Missions[player].ToList();
            a.Shuffle(rng);
            Missions[player] = new Queue<CardModel>(a);
        }

        public void ShuffleLibrary(Player player, Random rng)
        {
            //Missions[player].ToList();
            List<CardModel> a = Libraries[player].ToList();
            a.Shuffle(rng);
            Libraries[player] = new Queue<CardModel>(a);
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

        public HeroCharacterModel GetHeroCharacterInMissionWithSubtitle(string subtitle)
        {
            return (HeroCharacterModel)Cards.Find(cardModel => cardModel.State == CardState.Mission && (cardModel.Card.Type & CardType.HeroPlayerCharacter) != 0 && cardModel.Card.Subtitle == subtitle);
        }

        public List<CardModel> GetCharsWithBoost()
        {
            return Cards.FindAll(cardModel =>  (cardModel.Card.Type & CardType.Character ) != 0 && ((CharacterModel)cardModel).HasBoost() );
        }



        public CardModel PeekLibrary(Player player, CardState cardState)
        {
            try
            {
                CardModel topCardLibrary = Libraries[player].Peek();
                topCardLibrary.State = cardState;
                Libraries[player].Dequeue();

                return topCardLibrary;
                // return new StargateResult { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = topCardLibrary };
            }
            catch (Exception e)
            {
                throw new EmptyLibraryException();
            }
        }

        public CardModel Draw(Player player)
        {
            return PeekLibrary(player, CardState.Hand);
        }

        public CardModel Meule(Player player)
        {
            return PeekLibrary(player, CardState.Destroy);
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

using Godot;
using Stargate.Repository;
using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.StargateException;
using Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate
{


    public class GameState
    {

        public Random random = null;
        public Player CurrentPlayer { get; set; } = null;
        public Player player1 { get; set; } = null;
        public Player player2 { get; set; } = null;

        public StateAction GameStack { get; set; }

        public event EventHandler StargateResultHandler;

        public CardRepository CardRepository { get; set; } = new CardRepository();

        public GameState()
        {
            player1 = new Player() { id = 1, gameState = this};
            player2 = new Player() { id = 2, gameState = this };
        }


        public List<CardModel> GetAllCards()
        {
            return this.CardRepository.GetAll();
        }


        public CardModel CreateCardModel(SGCard card)
        {
         
            
            if(card.Type == CardType.Mission)
            {
                return new MissionModel() { Card = card };
            }
            else if ((card.Type & CardType.Character) != 0)
            {

                switch (card.Type)
                {
                    case (CardType.SupportCharacter):
                        return new HeroCharacterModel() { Card = card};
                    case (CardType.TeamCharacter):
                        return new HeroCharacterModel() { Card = card };
                    case (CardType.Adversary):
                        return new AdversaryModel() { Card = card };
                }
                
                //return new CharacterModel() { Card = card };
            }

            return new CardModel(card);

        }

        /** 
         * generate deck from card template for player
         */
        public void CreatePlayerDeck(Player player, List<SGCard> cards)
        {
            foreach (SGCard card in cards)
            {
                // faire des if pour verifier la pertinance IsNotTeam
                CardModel cl = CreateCardModel(card);
                cl.Owner = player;
                cl.State = CardState.Library;
                this.CardRepository.AddCard(cl);
            }
        }

        public void CreatePlayerTeam(Player player, List<SGCard> cards)
        {
            foreach (SGCard card in cards)
            {
                // faire des if pour verifier la pertinance IsTeam
                CardModel cl = CreateCardModel(card);
                cl.Owner = player;
                cl.State = CardState.Ready;
                this.CardRepository.AddCard(cl);
            }
        }



        public MissionModel GetCurrentMission()
        {
            return CardRepository.GetCurrentMission();
        }

        public void CreatePlayerMissions(Player player, List<SGCard> cards)
        {
            foreach (SGCard card in cards)
            {
                // faire des if pour verifier la pertinance isMission
                CardModel cl = CreateCardModel(card);
                cl.Owner = player;
                cl.State = CardState.MissionPile;
                this.CardRepository.AddCard(cl);
            }
        }


        public StargateResult PlayHeroCard(PlayCardEvent playCardEvent)
        {
            if ((playCardEvent.cardModel.Card.Type & CardType.HeroPlayerAction) != 0)
            {
                return PlayCard(playCardEvent);
            }

            return new StargateResult() { actionResult = ActionResult.Failure };
        }


        public StargateResult PlayMonsterBoss(PlayCardEvent playCardEvent)
        {
            if ((playCardEvent.cardModel.Card.Type & CardType.VillanPlayerAction) != 0)
            {
                return PlayCard(playCardEvent);
            }

            return new StargateResult() { actionResult = ActionResult.Failure };
        }

        public StargateResult PlayCard(PlayCardEvent playCardEvent)
        {
            if (CardRepository.IsInHand(playCardEvent.Sender, playCardEvent.cardModel) && playCardEvent.Sender.Energy >= playCardEvent.cardModel.Card.Cost)
            {
                playCardEvent.Sender.Energy -= playCardEvent.cardModel.Card.Cost;
                playCardEvent.cardModel.State = CardState.Ready; // probablement passer par le repository pour faire ca
                return new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = playCardEvent.cardModel };
            }
            else
            {
                return new StargateResult() { actionResult = ActionResult.Failure };
            }
        }



        public StargateResult AssignHeroChar(AssignCharEvent assignCardEvent)
        {
            if ((assignCardEvent.cardModel.Card.Type & CardType.HeroPlayerAction) != 0)
            {
                return AssignChar(assignCardEvent);
            }
            return new StargateResult() { actionResult = ActionResult.Failure };
        }

        public StargateResult AssignVillanChar(AssignCharEvent assignCardEvent)
        {
            if ((assignCardEvent.cardModel.Card.Type & CardType.VillanPlayerAction) != 0)
            {
                return AssignChar(assignCardEvent);
            }
            return new StargateResult() { actionResult = ActionResult.Failure };
        }


        public StargateResult AssignChar(AssignCharEvent assignCardEvent)
        {
            if (assignCardEvent.cardModel.State == CardState.Ready)
            {
                assignCardEvent.cardModel.State = CardState.Mission;
                return new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = assignCardEvent.cardModel };
            }
            else
            {
                return new StargateResult() { actionResult = ActionResult.Failure };
            }
        }


        public void StopAllAssignedCharacterAndBoss()
        {
            List<CardModel> charactersInMission = CardRepository.GetMissionCharacters();

            Debug.WriteLine("characther in mission : " + charactersInMission.Count);

            charactersInMission.ForEach(character => { 
                character.State = CardState.Stop;

                //Debug.Print(new StargateResult().ToString() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = character });

                StargateResult r = new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = character };
                //Debug.WriteLine(r);
                ForwardEvent(r);
            });

        }


        public int TotalExperience(Player player)
        {
            int retour = 0;
            foreach (HeroCharacterModel item in CardRepository.GetPlayerTeamCharacters(player))
            {
                retour += item.Card.Cost;
            }
            return retour;
        }


        public void ReadyAllStoppedCardsAndStopAllKOCards()
        {
            foreach (CardModel item in CardRepository.getCardsByState(CardState.Stop))
            {
                item.State = CardState.Ready;
                ForwardEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = item });
            }
            foreach (CardModel item in CardRepository.getCardsByState(CardState.KO))
            {
                item.State = CardState.Stop;
                ForwardEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = item });
            }
        }


        public int GlyphCount(Player player)
        {
            int retour = 0;
            foreach (HeroCharacterModel item in CardRepository.GetPlayerTeamCharactersWithGlyph(player))
            {
                retour += item.CountGlyph();
            }
            return retour;
        }

        public int VictoryTotal(Player player)
        {
            int retour = 0;
            foreach (HeroCharacterModel item in CardRepository.GetPlayerTeamCharactersWithGlyph(player))
            {
                retour += item.GetVictoryTotal();
            }
            return retour;
            //return CardRepository.GetPlayerTeamCharacters(player).Count;
        }


        public List<CardModel> GetHeroPlayerCardsInMission()
        {
            return CardRepository.GetCardsInMission(GetHeroPlayer(), CardType.HeroPlayerMissionObjets);
        }


        public bool CheckQuestVictory()
        {
            MissionModel mission = CardRepository.GetCurrentMission();
            List<CardModel> heros = CardRepository.GetCardsInMission(GetHeroPlayer(), CardType.HeroPlayerMissionObjets);
            List<CardModel> peripeties = CardRepository.GetCardsInMission(GetEnemyPlayer(), CardType.VIllanPlayerMissionObjects);

            int difficulty = (int)mission.getMissionDifficulty();


            foreach (CharacterModel card in peripeties)
            {
                if(card.GetSkill(mission.GetMissionSkill()) != null)
                {
                    difficulty += (int)card.GetSkill(mission.GetMissionSkill());
                }
            }


            int totalStats = 0;
            foreach (CharacterModel card in heros)
            {
                if(card.GetSkill(mission.GetMissionSkill()) != null)
                {
                    totalStats += (int)card.GetSkill(mission.GetMissionSkill());
                }
            }

            return totalStats >= difficulty;
        }


        public void InitPlayersLibraryAndMissions()
        {
            this.CardRepository.InitPlayersLibrary();
            this.CardRepository.InitPlayersMissions();
        }

        public void Draw(Player player)
        {
            try
            {
                ForwardEvent(new StargateResult { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = CardRepository.Draw(player) });
            }
            catch (EmptyLibraryException e)
            {
                throw e;
            }
        }

        public void DrawUpTo(Player player, int upTo)
        {
            try
            {
                while (CardRepository.GetPlayerHand(player).Count < upTo)
                {
                    Draw(player);
                }
            }
            catch (EmptyLibraryException e)
            {

            }
        }


        public void PlayMission(Player player)
        {
            try
            {
                ForwardEvent(new StargateResult { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = CardRepository.PlayMission(player) });
            }
            catch (EmptyMissionPileException e)
            {
             
            } 
        }


        /* public void SetQuestAside()
         {
             MissionModel m = CardRepository.GetCurrentMission();
             m.State = CardState.Aside;
             ForwardEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = m });
         }
        */


        public void ChangeCardState(CardModel model, CardState state)
        {
            model.State = state;
            ForwardEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = model });
        }

        public void SetQuestFailed()
        {
            MissionModel m = CardRepository.GetCurrentMission();
            ChangeCardState(m, CardState.FailedQuest);
        }

        public void SetQuestAffinity()
        {
            MissionModel m = CardRepository.GetCurrentMission();
            ChangeCardState(m, CardState.Affinity);
        }


        public void PlaceAllFailedQuestInBottomOfLibrary()
        {
            foreach (MissionModel item in CardRepository.GetAllFailedQuest().Cast<MissionModel>())
            {
                item.State = CardState.MissionPile;
                CardRepository.Missions[item.Owner].Enqueue(item);
                ForwardEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = item });
            }
        }

        public void ClearAllBoosts()
        {
            foreach (CharacterModel item in CardRepository.GetCharsWithBoost())
            {
                item.ClearBoosts();
                ForwardEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = item });
            }
        }


        public void BoostBossMonster(BoostCharEvent myEvent)
        {
            AdversaryModel m  =  CardRepository.GetAdversaryInMissionWithSubtitle(myEvent.cardModel.Card.Subtitle);
            if(m != null)
            {
                m.AddBoost((CharacterModel)myEvent.cardModel);
                ForwardEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = m });
            }
        }


        public Player GetOtherPlayer(Player player)
        {
            if (player == GetHeroPlayer())
            {
                return GetEnemyPlayer();
            }
            return GetHeroPlayer();

        }

        public Player GetEnemyPlayer()
        {
            if (CurrentPlayer == player1)
            {
                return player2;
            }
            else
            {
                return player1;
            }
        }



        public void SwitchPlayersRole()
        {
            CurrentPlayer = GetEnemyPlayer();
        }

        public Player GetHeroPlayer()
        {
            return CurrentPlayer;
        }


        public void InitGame(int seed)
        {
            random = new Random(seed);
            CurrentPlayer = player1;
            GameStack = new InitPhase(this);

            try
            {
                GameStack.Play();
            }
            catch (StateResultException e)
            {

            }
        }


        public void ProcessEvent(StargateEvent myEvent)
        {
            //Godot.GD.Print(myEvent);
            try
            {
                GameStack.Play(myEvent);
            }
            catch (StateResultException e)
            {

            }


        }

        public void ForwardEvent(StargateResult e)
        {
            if (e.actionResult == ActionResult.Success)
            {
                StargateResultHandler?.Invoke(this, e);
            }

        }

     
    }



}







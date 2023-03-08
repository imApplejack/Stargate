using Godot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.Result;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class Defeat : StargatePhase
    {


        public Defeat(GameState gs) : base(gs)
        {
            AddAction(ScoreReviveorDestroyBoss).
                    AddAction(DestroyAllMonsterAndComplications).
                    AddAction(new StopAllAssignedCharacterAndBoss(gs)).
                    AddAction(ContinueToNextQuest);
                    ;
        }


        public void ScoreReviveorDestroyBoss(StateEvent e = null)
        {
            //Debug.WriteLine("DEFEAT ScoreReviveorDestroyBoss");
        }


        public void DestroyAllMonsterAndComplications(StateEvent e = null)
        {
            //Debug.WriteLine("DEFEAT DestroyAllMonsterAndComplications");
        }



        public void SetQuestAside(StateEvent e = null)
        {
            //Debug.WriteLine("DEFEAT SetQuestAside");
        }

        public void GiveEnnemy1MPForEachFailedQuest(StateEvent e = null)
        {
            //Debug.WriteLine("DEFEAT GiveEnnemy1MPForEachFailedQuest");
        }

        public void ContinueToNextQuest(StateEvent e = null)
        {

            //Debug.WriteLine("DEFEAT ContinueToNextQuest stateevent " + e);
            
            try
            {

                ContinueQuestEvent theevent = (ContinueQuestEvent)e;
                if (theevent != null && theevent.Sender == gameState.GetHeroPlayer() && theevent.Type == EventType.CONTINUEQUEST)
                {

                    //Debug.WriteLine("BON SENDER ContinueToNextQuest" + e);

                    if (theevent.response == ContinueQuestEventResponse.YES)
                    {
                       // Debug.WriteLine("BON SENDER ContinueToNextQuest RESPONSE YES");
                        //AddAction(SetQuestAside).AddAction(GiveEnnemy1MPForEachFailedQuest) ; 
                        QueueAction(new SetQuestAside(gameState)).QueueAction(new GiveEnemy1MPForEachFailedQuest(gameState)).QueueAction(new QuestLoop(gameState));
                    }
                    else
                    {
                        QueueAction(new SetQuestAside(gameState))
                        // Debug.WriteLine("BON SENDER ContinueToNextQuest RESPONSE NO");
                        ;
                    }
                }
                else
                {
                    throw new StateResultException(StateResult.STOP);
                }
            }catch
            {
                SendEvent(new ContinueQuestResult() { player = gameState.CurrentPlayer });
                throw new StateResultException(StateResult.STOP);
            }
          
        }



       


    }
    
    
}

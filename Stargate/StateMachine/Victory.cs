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
    public class Victory : StargatePhase
    {


        public Victory(GameState gs) : base(gs)
        {
            AddAction(ReviveorDestroyBoss).
                AddAction(DestroyAllMonsterAndComplications).
                AddAction(AttacheAffinityToAssignedCharacter)
            .AddAction(ActivateEarnAffinityAbilities).
            AddAction(new StopAllAssignedCharacterAndBoss(gs))
            .AddAction(ContinueToNextQuest);
        }


        public void ReviveorDestroyBoss(StateEvent e = null)
        {
            //Debug.WriteLine("VICTORY ReviveorDestroyBoss");
        }


        public void DestroyAllMonsterAndComplications(StateEvent e = null)
        {
            //Debug.WriteLine("VICTORY DestroyAllMonsterAndComplications");
        }

        public void AttacheAffinityToAssignedCharacter(StateEvent e = null)
        {
            //Debug.WriteLine("VICTORY AttacheAffinityToAssignedCharacter");
        }

        public void ActivateEarnAffinityAbilities(StateEvent e = null)
        {
            //Debug.WriteLine("VICTORY ActivateEarnAffinityAbilities");
        }



        public void ContinueToNextQuest(StateEvent e = null)
        {
            //throw new StateResultException(StateResult.STOP);
            try
            {
                ContinueQuestEvent theevent = (ContinueQuestEvent)e;
                if (theevent != null && theevent.Sender == gameState.GetHeroPlayer() && theevent.Type == EventType.CONTINUEQUEST)
                {

                    if (theevent.response == ContinueQuestEventResponse.YES)
                    {
                        QueueAction(new SetQuestAside(gameState)).QueueAction(new QuestLoop(gameState));
                    }
                }
                else
                {
                    throw new StateResultException(StateResult.STOP);
                }
            }
            catch
            {
                SendEvent(new ContinueQuestResult() { player = gameState.CurrentPlayer });
                throw new StateResultException(StateResult.STOP);
            }

        }








    }
    
    
}

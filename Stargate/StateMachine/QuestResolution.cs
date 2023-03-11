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
    public class QuestResolution : StargatePhase
    {


        public QuestResolution(GameState gs) : base(gs)
        {
         
        }



        public override void InitSG()
        {
            AddAction(QuestResolutionAbilities)
           .AddAction(CheckQuestResolution)
          ;
        }


        public void QuestResolutionAbilities(StateEvent e = null)
        {
            
        }

       

        public void CheckQuestResolution(StateEvent e = null)
        {

            if (gameState.CheckQuestVictory())
            {
                //gameState.GetCurrentMission().State = CardState.Affinity;
                //gameState.SetQuestAffinity();
                QueueAction(new Victory(gameState));
            }
            else
            {
                //gameState.SetQuestFailed();
                QueueAction(new Defeat(gameState));
            }

            //SendEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = gameState.GetCurrentMission() });

           // gameState.F


        }

      


    }
    
    
}

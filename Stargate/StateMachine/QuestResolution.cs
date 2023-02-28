using Godot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
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
            .AddAction(CheckQuestResolution)
             .AddAction(ContinueToNextQuest)
          ;
        }


        public void QuestResolutionAbilities(StateEvent e = null)
        {
            
        }

        public void CheckQuestResolution(StateEvent e = null)
        {

            if (gameState.CheckQuestVictory())
            {
                QueueAction(new Victory(gameState));
            }
            else
            {
                QueueAction(new Defeat(gameState));
            }

        }

        public void ContinueToNextQuest(StateEvent e = null) {
            //((QuestLoop)parent).RestartPhase();
            //((QuestLoop)parent).InitSG();

            Debug.WriteLine("");
        }


    }
    
    
}

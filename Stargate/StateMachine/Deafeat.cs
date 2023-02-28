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
    public class Defeat : StargatePhase
    {


        public Defeat(GameState gs) : base(gs)
        {
            AddAction(ScoreReviveorDestroyBoss).
                    AddAction(DestroyAllMonsterAndComplications).
                    AddAction(StopAllAssignedCharacterAndBoss)
                    ;
        }


        public void ScoreReviveorDestroyBoss(StateEvent e = null)
        {
            Debug.WriteLine("DEFEAT ScoreReviveorDestroyBoss");
        }


        public void DestroyAllMonsterAndComplications(StateEvent e = null)
        {
            Debug.WriteLine("DEFEAT DestroyAllMonsterAndComplications");
        }

        public void StopAllAssignedCharacterAndBoss(StateEvent e = null)
        {
            Debug.WriteLine("DEFEAT StopAllAssignedCharacterAndBoss");
        }

    }
    
    
}

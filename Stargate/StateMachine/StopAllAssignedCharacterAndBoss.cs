using Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.StateMachine
{
    public class StopAllAssignedCharacterAndBoss : StargatePhase
    {
        public StopAllAssignedCharacterAndBoss(GameState gs) : base(gs)
        {
            AddAction(StopAllAssignedCharacterAndBossMethod);

        }

        public void StopAllAssignedCharacterAndBossMethod(StateEvent e = null)
        {
            Debug.Print("StopAllAssignedCharacterAndBoss");
        }

    }
}

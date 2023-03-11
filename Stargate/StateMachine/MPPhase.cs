using Stargate.Stargate;
using Stargate.Stargate.Enum;
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
    public class MPPhase :StargatePhase
    {

        public MPPhase(GameState gs) : base(gs)
        {
            AddAction(Energy);
        }


        public void Energy(StateEvent e = null)
        {
            int energy = 3 + gameState.GlyphCount(gameState.CurrentPlayer);
            gameState.CurrentPlayer.Energy = energy;
            gameState.GetEnemyPlayer().Energy  = energy;
            SendEvent(new StargateResult() { StargateResultType = StargateResultType.ChangePlayerAttr, attr = gameState.CurrentPlayer });
        }
    }
}

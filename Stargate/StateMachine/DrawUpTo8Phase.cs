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
    public class DrawUpTo8Phase : StargatePhase
    {

        public DrawUpTo8Phase(GameState gs) : base(gs)
        {
            AddAction(DrawUpTo8Method);
        }


        public void DrawUpTo8Method(StateEvent e = null)
        {
            gameState.DrawUpTo(gameState.GetHeroPlayer(), 8);
            gameState.DrawUpTo(gameState.GetEnemyPlayer(), 8);
        }

      
    }
}

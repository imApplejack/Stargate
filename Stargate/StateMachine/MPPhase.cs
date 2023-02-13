using Stargate.Stargate;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class MPPhase : Phase, IPhase
    {
        public MPPhase(GameState gameState = null) : base(gameState)
        {

        }

        public override void Run() {

            gameState.CurrentPlayer.Energy = 3;

            PopAndNewPhase(new QuestPhase());


        }


    }

}

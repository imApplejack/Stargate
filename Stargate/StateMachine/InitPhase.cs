using Stargate.Stargate;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class InitPhase : Phase , IPhase
    {
        public InitPhase(GameState gameState) : base(gameState)
        {
        }

        public new void Run()
        {


            GameState.CardService.Draw(GameState.GetHeroPlayer());
            GameState.CardService.Draw(GameState.GetHeroPlayer());


        }

    }

}

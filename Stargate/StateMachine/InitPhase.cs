using Stargate.Stargate;
using Stargate.Stargate.Event;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class InitPhase : Phase , IPhase
    {

       // public event EventHandler StargateResultHandler;


        public InitPhase(GameState gameState = null ) : base(gameState)
        {
        }

        public override void Run()
        {

            SendEvent(gameState.CardService.Draw(gameState.GetHeroPlayer()));
            SendEvent(gameState.CardService.Draw(gameState.GetHeroPlayer()));





            PopAndNewPhase(new MPPhase());
        }

    }

}

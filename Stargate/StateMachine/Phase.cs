using Stargate.Stargate;
using Stargate.Stargate.Event;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public  class Phase : IPhase
        {
            protected GameState GameState = null;

            public Phase(GameState gameState)
            {
                GameState = gameState;
            
            }

       

        public void ProcessEvent(StargateEvent myEvent)
        {

        }

        public void Init()
        {
            //throw new NotImplementedException();
        }

        public void Run()
        {
            //throw new NotImplementedException();
        }
    }

}

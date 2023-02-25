using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class StargatePhase : StatePhase 
    {

        public StargatePhase(GameState gs) {
            gameState = gs;
            InitSG();
        }

        public virtual void InitSG() { }

        public GameState gameState = null;

        public void SendEvent(StargateResult r)
        {
            gameState.ForwardEvent(r);
        }
    }
}

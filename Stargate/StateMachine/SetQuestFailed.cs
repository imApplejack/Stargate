using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class SetQuestFailed : StargatePhase
    {

        public SetQuestFailed(GameState gs) : base(gs)
        {
           
        }


        public override void InitSG()
        {
            AddAction(SetQuestFailedMethod);
        }


        public void SetQuestFailedMethod(StateEvent e = null)
        {
            gameState.SetQuestFailed();
        }


    }
}

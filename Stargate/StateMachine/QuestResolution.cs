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
    public class QuestResolution : StargatePhase
    {


        public QuestResolution(GameState gs) : base(gs)
        {
            AddAction(new StateAction());
        }



        public override void InitSG()
        {
          
        }


        }
    
    
}

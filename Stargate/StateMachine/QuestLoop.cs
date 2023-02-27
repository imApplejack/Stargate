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
    public class QuestLoop : StargatePhase
    {


        public QuestLoop(GameState gs) : base(gs)
        {
           AddAction(new QuestPhase(gs))
           .AddAction(new QuestResolution(gs)); 
        }


 

        
    }
}

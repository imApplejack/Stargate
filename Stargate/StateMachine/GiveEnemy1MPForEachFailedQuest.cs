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
    public class GiveEnemy1MPForEachFailedQuest : StargatePhase
    {

        public GiveEnemy1MPForEachFailedQuest(GameState gs) : base(gs)
        {
           
        }


        public override void InitSG()
        {
            AddAction(GiveEnnemyMP);
        }


        public void GiveEnnemyMP(StateEvent e = null)
        {
            //Debug.Print("GiveEnemy1MPForEachFailedQuest");
        }


    }
}

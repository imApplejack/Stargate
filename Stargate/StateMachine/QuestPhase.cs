using Stargate.Stargate;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class QuestPhase : Phase, IPhase
    {
        public QuestPhase(GameState gameState = null) : base(gameState)
        {
        }

    }

}

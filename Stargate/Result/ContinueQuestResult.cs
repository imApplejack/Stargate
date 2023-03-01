using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Result
{
    public class ContinueQuestResult : StargateResult
    {
        public ContinueQuestResult()
        {
            StargateResultType = StargateResultType.ContinueQuest;
        }

        public Player player;
    }
}

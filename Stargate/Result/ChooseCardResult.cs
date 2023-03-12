using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Result
{
    public class ChooseCardResult : StargateResult
    {

        public SelectCardEnum Range { get; set; } = SelectCardEnum.One;

        public ChooseCardResult()
        {
            StargateResultType = StargateResultType.ChooseCard;
        }

        public Player player;

        public List<CardModel> cards;

        public int count = 1;



    }
}

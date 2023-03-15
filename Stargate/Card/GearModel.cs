using Stargate.Stargate.Card.Interface;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Card
{
    public  class GearModel : CardModel
    {
      

        public override void PlayCardAction()
        {
            base.PlayCardAction();
            State = CardState.Board;
        }


    }
}

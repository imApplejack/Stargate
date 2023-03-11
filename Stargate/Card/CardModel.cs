using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Card
{

    public class CardModel
    {


        public int Id { get; set; } // unique id 
        public CardState State { get; set; }
        public Player Owner { get; set; }
        public SGCard Card { get; set; }


        public CardModel()
        {

        }
        public CardModel(SGCard card)
        {
            Card = card;
        }




        public override string ToString()
        {
            return "Id : " + Id + "  State : " + State;
        }

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate
{

    public enum CardState
    {
        Hand,
        Library,
        Ready,
        Mission,
        Stop,
        Disabled,
        Destroy
    };


    public class CardModel
    {

        public int Id { get; set; }

        public CardModel()
        {
        }

        public CardState State { get; set; }

        public Player Owner { get; set; }

        public SGCard Card { get; set; }

    }
}

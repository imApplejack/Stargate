using Stargate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate
{
    public class GameState
    {

        public Random random = null;

        public SGMissionEvent Mission { get; set; } = null;
        public Player CurrentPlayer { get; set; } = null;

        public Player player1 { get; set; } = null;
        public Player player2 { get; set; } = null;

        public CardService CardService { get; set; }


        public GameState(int seed)
        {
            random= new Random(seed);
        }

       




    }
}

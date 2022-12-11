using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stargate
{
    public class StargateGame
    {


        Player player1= null;
        Player player2= null;
        
        public SGMissionEvent Mission { get; set; } = null;
        public Player CurrentPlayer { get; set; } = null;


        public StargateGame()
        {
        }

        public StargateGame(Player player1, Player player2)
        {
        }



    }
}

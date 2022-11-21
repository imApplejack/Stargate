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
            Player player1 = new Player();
            Player player2 = new Player();
            this.CurrentPlayer = player1;
            Console.WriteLine("coucou");
        }

        public StargateGame(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            Console.WriteLine("coucou");
        }



    }
}

using Stargate.Service;
using Stargate.Stargate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stargate
{
    public class StargateGame
    {


        public Player player1= null;
        public Player player2 = null;

        public CardService cardService = new CardService();

        public Library Library = new Library();
        
        public SGMissionEvent Mission { get; set; } = null;
        public Player CurrentPlayer { get; set; } = null;


        public StargateGame()
        {
          
        }

      



    }
}

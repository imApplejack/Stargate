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


        public Player player1 { get; set; } = null;
        public Player player2 { get; set; } = null;

        public CardService CardService { get; set; }  = new CardService();

        public Library Library { get; set; }
        
        public SGMissionEvent Mission { get; set; } = null;
        public Player CurrentPlayer { get; set; } = null;



   

        public StargateGame()
        {
           
        }

      



    }
}

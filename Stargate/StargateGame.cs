using Stargate.Service;
using Stargate.Stargate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stargate
{
    /// <summary>
    /// API
    /// </summary>
    public class StargateGame
    {


        public Player player1 { get; set; } = null;
        public Player player2 { get; set; } = null;

        public CardService CardService { get; set; }  = new CardService();

        public Library Library { get; set; }
        
        public GameState GameState { get; set; } = null;



   

        public StargateGame(int seed, Library library)
        {
            Library = library;
            player1 = new Player();
            player2 = new Player();
            GameState = new GameState() { player1 = player1, player2 = player2, CardService = CardService};
        }

      



    }
}

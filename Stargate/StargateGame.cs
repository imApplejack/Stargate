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




        public CardService CardService { get; set; }  = new CardService();

        public Library Library { get; set; }
        
        public GameState GameState { get; set; } = null;



   

        public StargateGame(Library library)
        {
            Library = library;
            GameState = new GameState() { player1 = new Player(), player2 = new Player(), CardService = CardService};
        }

      



    }
}

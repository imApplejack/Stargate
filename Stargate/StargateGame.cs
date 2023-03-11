
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


        public int GetPlayerId(Player player)
        {
            if (GameState.player1 == player) { return GameState.player1.id; }
            else if (GameState.player2 == player) { return GameState.player2.id; }
            else { return 0; }   
        }

        public Player GetPlayerById(int id)
        {
            if (GameState.player1.id == id) { return GameState.player1; }
            else if (GameState.player2.id == id) { return GameState.player2; }
            else { return null; }  
        }



        public Library Library { get; set; }

        public GameState GameState { get; set; } = null;

        public StargateGame(Library library)
        {
            Library = library;
            GameState = new GameState();  
        }

    }
}


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


        public void InitPlayersWithDeck(Decklist p1, Decklist p2)
        {
            InitPlayerWithDecklist(GameState.player1, p1);
            InitPlayerWithDecklist(GameState.player2, p2);
            GameState.InitPlayersLibraryAndMissions();
        }

        public void InitPlayerWithDecklist(Player p, Decklist deck)
        {
            GameState.CreatePlayerTeam(p, Library.GetCardsFromGuidList(deck.team));
            GameState.CreatePlayerDeck(p, Library.GetCardsFromGuidList(deck.library));
            GameState.CreatePlayerMissions(p, Library.GetCardsFromGuidList(deck.mission));
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

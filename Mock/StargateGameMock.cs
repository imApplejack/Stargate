
using Stargate.Stargate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Mock
{
    public class StargateGameMock
    {

        public static  void InitPlayersWithMock(StargateGame stargateGame)
        {
            StargateGameMock.InitPlayerWithMock(stargateGame, stargateGame.GameState.player1);
            StargateGameMock.InitPlayerWithMock(stargateGame, stargateGame.GameState.player2);
            stargateGame.GameState.InitPlayersLibraryAndMissions();
        }

      

        public static void InitPlayerWithMock(StargateGame stargateGame, Player p)
        {
            stargateGame.GameState.CreatePlayerTeam(p, stargateGame.Library.GetCardsFromGuidList(new List<string> { "4901fb59-e7cc-47d4-8f3a-4f1f2e93f78d", "c5358e72-16ac-450e-a2b8-923d4964f52c" }));
            stargateGame.GameState.CreatePlayerDeck(p, stargateGame.Library.GetCardsFromGuidList(new List<string> { "79974bc9-9b81-41e1-8868-c75f8fc58837", "79974bc9-9b81-41e1-8868-c75f8fc58837", "dd59e9ee-9cf8-4d61-b891-5477c550b2b1", "dd59e9ee-9cf8-4d61-b891-5477c550b2b1", "3c381256-8ecd-4a17-ae67-dbe4a7b5305a" , "3c381256-8ecd-4a17-ae67-dbe4a7b5305a" }));
            stargateGame.GameState.CreatePlayerMissions(p, stargateGame.Library.GetCardsFromGuidList(new List<string> {  "b73da326-be80-41c8-b201-a0e6d7bf2ec6", "c81249ce-abc2-489c-a32c-28ca0e18293b" }));
        }

    }
}

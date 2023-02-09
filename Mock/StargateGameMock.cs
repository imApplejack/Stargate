using Stargate.Service;
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

        public static  void InitPlayer1WithMock(StargateGame stargateGame)
        {

            // init player 1 avec des mocks
            stargateGame.CardService.CreatePlayerDeck(stargateGame.player1, stargateGame.Library.GetCardsFromGuidList(new List<string> { "79974bc9-9b81-41e1-8868-c75f8fc58837", "79974bc9-9b81-41e1-8868-c75f8fc58837", "dd59e9ee-9cf8-4d61-b891-5477c550b2b1", "dd59e9ee-9cf8-4d61-b891-5477c550b2b1" }));
            stargateGame.CardService.CreatePlayerTeam(stargateGame.player1, stargateGame.Library.GetCardsFromGuidList(new List<string> { "4901fb59-e7cc-47d4-8f3a-4f1f2e93f78d" }));
            stargateGame.CardService.CreatePlayerMissions(stargateGame.player1, stargateGame.Library.GetCardsFromGuidList(new List<string> { "c81249ce-abc2-489c-a32c-28ca0e18293b" }));
            stargateGame.CardService.InitPlayersLibraryAndMissions();
        }

    }
}

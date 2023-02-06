using Godot;
using Stargate;
using Stargate.Service;
using Stargate.SGGodot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;

public class Main : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";



    //  private CardModel cardmodeltest = new CardModel();

    //  private StargateGame game;


    public PlayerControl Player1Vue;

    CardService cardService = new CardService();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

      
        Player Player1 = new Player();
        Library library = new Library();
        MappingMVC mappingMVC = new MappingMVC();
        Player1Vue = (PlayerControl)this.FindNode("PlayerControl");
        Player1Vue.player = Player1;
        Player1Vue.Api = this; // :'(



        // init player 1 avec des mocks
        cardService.CreatePlayerDeck(Player1, library.GetCardsFromGuidList(new List<string> { "79974bc9-9b81-41e1-8868-c75f8fc58837", "79974bc9-9b81-41e1-8868-c75f8fc58837", "dd59e9ee-9cf8-4d61-b891-5477c550b2b1", "dd59e9ee-9cf8-4d61-b891-5477c550b2b1" }));
        cardService.CreatePlayerTeam(Player1, library.GetCardsFromGuidList(new List<string> { "4901fb59-e7cc-47d4-8f3a-4f1f2e93f78d" }));
        cardService.CreatePlayerMissions(Player1, library.GetCardsFromGuidList(new List<string> { "c81249ce-abc2-489c-a32c-28ca0e18293b" })); 
        cardService.InitPlayersLibraryAndMissions();




        //cardService.Draw(Player1);
        //StargateGame stargateGame = new StargateGame() { player1 = Player1, Library = library, cardService = cardService };




        mappingMVC.InitRessources(cardService.GetAllCards());
        Player1Vue.MappingMVC = mappingMVC;

        foreach (var item in mappingMVC.Mapping)
        {
            Player1Vue.MajCardControl(item.Key);
        }


        MajVue(cardService.PlayMission(Player1));





    }
    
    public void AskForDraw(Player player) {
        StargateResult result = this.cardService.Draw(player);
        GD.Print(result);
        if (result.actionResult == ActionResult.Success)
        {
           
            this.MajVue(result);
        }
    }



    /// <summary>
    /// Ici tout le routing de maj des vues
    /// </summary>
    /// <param name="result"></param>
    public void MajVue(StargateResult result)
    {

        GD.Print(result);
        switch (result.StargateResultType)
        {

            case StargateResultType.ChangeCard:
                {
                    CardModel card = (CardModel)result.attr;
                    if (card.Owner == Player1Vue.player)
                    {
                        Player1Vue.MajCardControl(card);
                    }
                    break;
                }
        }
    }



    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
  {
       // cardmodeltest.RefreshView();
       // GD.Print("refreshview");

  }
}

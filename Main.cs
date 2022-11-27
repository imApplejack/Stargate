using Godot;
using Stargate;
using Stargate.Service;
using Stargate.SGGodot;
using Stargate.Stargate;
using System;
using System.Collections.Generic;

public class Main : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";



  //  private CardModel cardmodeltest = new CardModel();

  //  private StargateGame game;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        CardService cardService = new CardService();
        Player Player1 = new Player();
        Library library = new Library();
        MappingMVC mappingMVC = new MappingMVC();



        cardService.CreatePlayerDeck(Player1, library.GetCardsFromHashList(new List<string> { "79974bc9-9b81-41e1-8868-c75f8fc58837", "79974bc9-9b81-41e1-8868-c75f8fc58837", "dd59e9ee-9cf8-4d61-b891-5477c550b2b1", "dd59e9ee-9cf8-4d61-b891-5477c550b2b1" }));
        cardService.CreatePlayerTeam(Player1, library.GetCardsFromHashList(new List<string> { "4901fb59-e7cc-47d4-8f3a-4f1f2e93f78d" }));
        cardService.InitPlayersLibrary();


        mappingMVC.InitRessources(cardService.GetAllCards());

    }


      private void intTeamPanel(List<SGCharacter> characters)
      {

         
          CardContainer tm = (CardContainer)this.FindNode("TeamContainer");
          tm.Team = characters;
          tm.initTeam();

          CardContainer hc = (CardContainer)this.FindNode("HandContainer");
          hc.Team = characters;
          hc.initTeam();
         

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
  {
       // cardmodeltest.RefreshView();
       // GD.Print("refreshview");

  }
}

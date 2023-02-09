using Godot;
using Stargate;
using Stargate.Mock;
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

      private StargateGame game;


    public PlayerControl Player1Vue;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        



        Library library = new Library("C:\\Projets\\Stargate\\Stargate\\Sets\\");


        //cardService.Draw(Player1);
        game = new StargateGame() { player1 = new Player(), Library = library };


        StargateGameMock.InitPlayer1WithMock(game);


        MappingMVC mappingMVC = new MappingMVC();
        Player1Vue = (PlayerControl)this.FindNode("PlayerControl");
        Player1Vue.player = game.player1;
        Player1Vue.Api = this; // :'(
        Player1Vue.MappingMVC = mappingMVC;



        mappingMVC.InitRessources(game.CardService.GetAllCards());
        
        Player1Vue.MajControl();

        GD.Print(Player1Vue.player);

        
        MajVue(game.CardService.PlayMission(game.player1));



        




    }
    
    public void AskForDraw(Player player) {
        StargateResult result = game.CardService.Draw(player);
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
        GD.Print(Player1Vue);
        GD.Print(Player1Vue.player);


        switch (result.StargateResultType)
        {

            case StargateResultType.ChangeCard:
                {
                    CardModel card = (CardModel)result.attr;

                    GD.Print(card);
                    GD.Print( card.Owner);
                    GD.Print( Player1Vue);
                    GD.Print( Player1Vue.player);

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

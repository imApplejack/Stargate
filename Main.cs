using Godot;
using Stargate;
using Stargate.Mock;
using Stargate.Service;
using Stargate.SGGodot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using System;
using System.Collections.Generic;

public class Main : Node
{
   

      private StargateGame game;


      public PlayerControl Player1Vue;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


        Library library = new Library("C:\\Users\\lolec\\Documents\\Projets\\Stargate\\Sets\\");


        //cardService.Draw(Player1);
        game = new StargateGame(library);
        game.GameState.StargateResultHandler += HandleResult;
        StargateGameMock.InitPlayer1WithMock(game);


        MappingMVC mappingMVC = new MappingMVC();
        mappingMVC.InitRessources(game.CardService.GetAllCards());




        Player1Vue = (PlayerControl)this.FindNode("PlayerControl");
        Player1Vue.player = game.player1;
        Player1Vue.Api = this; // :'(
        Player1Vue.MappingMVC = mappingMVC;



        Player1Vue.MajControl();

      

       // MajVue(game.CardService.PlayMission(game.player1));




        game.GameState.InitGame(1);


    }
    
    public void AskForDraw(Player player) {
        StargateResult result = game.CardService.Draw(player);
        GD.Print(result);
        if (result.actionResult == ActionResult.Success)
        {
           
            this.MajVue(result);
        }
    }


    public void SendEvent(StargateEvent stargateEvent){

        // caller le reseau ici ?
        game.GameState.ProcessEvent(stargateEvent);
    }


    public void HandleResult(object sender, EventArgs e)
    {
        MajVue((StargateResult)e);
    }


    /// <summary>
    /// Ici tout le routing de maj des vues
    /// </summary>
    /// <param name="result"></param>
    public void MajVue(StargateResult result)
    {

        if(result.actionResult == ActionResult.Success)
        {
            switch (result.StargateResultType)
            {

                case StargateResultType.ChangeCard:
                {
                    CardModel card = (CardModel)result.attr;
                    Player1Vue.MajCardControl(card);
                    break;
                }

                case StargateResultType.ChangePlayerAttr:
                    {
                        Player card = (Player)result.attr;
                        Player1Vue.MajPlayerAttr(card);
                        break;
                    }
            }
        }

       
    }



    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }
}

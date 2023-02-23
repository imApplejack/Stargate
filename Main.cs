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
     public PlayerControl Player2Vue;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


        Library library = new Library("C:\\Users\\lolec\\Documents\\Projets\\Stargate\\Sets\\");


        //cardService.Draw(Player1);
        game = new StargateGame(library);
        
        StargateGameMock.InitPlayersWithMock(game);


        MappingMVC mappingMVC = new MappingMVC();
        mappingMVC.InitRessources(game.CardService.GetAllCards());


        Player1Vue = (PlayerControl)this.FindNode("PlayerControl");
        Player1Vue.player = game.player1;
        Player1Vue.Api = this; // :'(
        Player1Vue.MappingMVC = mappingMVC;
        game.GameState.StargateResultHandler += Player1Vue.HandleResult;

        Player1Vue.MajControl();




        MappingMVC mappingMVC2 = new MappingMVC();
        mappingMVC2.InitRessources(game.CardService.GetAllCards());

        Player2Vue = (PlayerControl)this.FindNode("PlayerControl2");
        Player2Vue.player = game.player2;
        Player2Vue.Api = this; // :'(
        Player2Vue.MappingMVC = mappingMVC2;
        game.GameState.StargateResultHandler += Player2Vue.HandleResult;

        Player2Vue.MajControl();
        





        // MajVue(game.CardService.PlayMission(game.player1));

        game.GameState.InitGame(1);


    }
    

    public void SendEvent(StargateEvent stargateEvent){

        // caller le reseau ici ?
          game.GameState.ProcessEvent(stargateEvent);
    }



    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }
}

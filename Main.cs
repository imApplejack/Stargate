using Godot;
using Stargate;
using Stargate.Mock;
using Stargate.SGGodot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;

using System;
using System.Collections.Generic;
using System.Globalization;

public class Main : Node
{
   

      private StargateGame game;


     public PlayerControl Player1Vue;
     public PlayerControl Player2Vue;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


        Library library = new Library(ProjectSettings.GlobalizePath("res://Sets/"));

 

        //cardService.Draw(Player1);
        game = new StargateGame(library);
        StargateGameMock.InitPlayersWithMock(game);
        game.GameState.player1.id = 1;
        game.GameState.player2.id = 2;


        MappingMVC mappingMVC = new MappingMVC();
        mappingMVC.InitRessources(game.GameState.GetAllCards());
        Player1Vue = (PlayerControl)this.FindNode("PlayerControl");
        Player1Vue.Player = game.GameState.player1;
        Player1Vue.Api = this; // :'(
        Player1Vue.MappingMVC = mappingMVC;
        game.GameState.StargateResultHandler += Player1Vue.HandleResult;
        Player1Vue.Init();


        MappingMVC mappingMVC2 = new MappingMVC();
        mappingMVC2.InitRessources(game.GameState.GetAllCards());
        Player2Vue = (PlayerControl)this.FindNode("PlayerControl2");
        Player2Vue.Player = game.GameState.player2;
        Player2Vue.Api = this; // :'(
        Player2Vue.MappingMVC = mappingMVC2;
        game.GameState.StargateResultHandler += Player2Vue.HandleResult;
        Player2Vue.Init();



        game.GameState.InitGame(1);



       

    }





    public void SendEvent(StargateEvent stargateEvent){



        stargateEvent.Hydrate(game);

        GD.Print("Main:79" + stargateEvent);

        game.GameState.ProcessEvent(stargateEvent);


   


        // caller le reseau ici ?
         


        //((NetworkClient)FindNode("Client1")).Rpc("CallRemote");

    }



    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

      
    }
}

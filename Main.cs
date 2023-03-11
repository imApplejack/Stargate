using Godot;
using Stargate;
using Stargate.Mock;
using Stargate.SGGodot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

public class Main : Node
{
   

      private StargateGame game;


     public PlayerControl Player1Vue;
     public PlayerControl Player2Vue;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


        var host = new NetworkedMultiplayerENet();
        host.CreateServer(6112, 10);
        GetTree().NetworkPeer = host;
        GD.Print(GetTree().NetworkPeer);
        GD.Print(GetTree().IsNetworkServer());

        Library library = new Library(ProjectSettings.GlobalizePath("res://Sets/"));

        //cardService.Draw(Player1);
        game = new StargateGame(library);
        StargateGameMock.InitPlayersWithMock(game);

        MappingMVC mappingMVC = new MappingMVC();
        mappingMVC.InitRessources(game.GameState.GetAllCards());
        Player1Vue = (PlayerControl)this.FindNode("PlayerControl");
        Player1Vue.InitControl(game.GameState.player1, game.GameState.player2, mappingMVC, this);
        game.GameState.StargateResultHandler += Player1Vue.HandleResult;


        MappingMVC mappingMVC2 = new MappingMVC();
        mappingMVC2.InitRessources(game.GameState.GetAllCards());
        Player2Vue = (PlayerControl)this.FindNode("PlayerControl2");       
        Player2Vue.InitControl(game.GameState.player2, game.GameState.player1, mappingMVC2, this);
        game.GameState.StargateResultHandler += Player2Vue.HandleResult;

        game.GameState.InitGame(1);



      

    }

    [Sync]
    public void SendEventnetwork(NetworkEvent stargateEvent)
    {
        stargateEvent.stargateEvent.Hydrate(game);
        game.GameState.ProcessEvent(stargateEvent.stargateEvent);
    }

    public void SendEvent(StargateEvent stargateEvent){
        GD.Print(stargateEvent);


        if (GetTree().NetworkPeer.GetConnectionStatus() == NetworkedMultiplayerPeer.ConnectionStatus.Connected)
        {
            //Debug.WriteLine("RPC");
            Rpc("SendEventnetwork", new NetworkEvent() { stargateEvent = stargateEvent });
        }
        else
        {
            SendEventnetwork(new NetworkEvent() { stargateEvent = stargateEvent });
        }
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

      
    }
}

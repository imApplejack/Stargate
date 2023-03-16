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
using System.Linq;
using System.Security.Principal;
public class Main : Node
{
   

      private StargateGame game;


     public PlayerControl Player1Vue;
     public PlayerControl Player2Vue;

    public NetworkManager NetworkManager;

    [Export]
    public string ip;

    [Export]
    public int port;

    [Export]
    public int seed;



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


        NetworkManager = new NetworkManager();

        var host = new NetworkedMultiplayerENet();

        GD.Print(ip);
        if (ip == null)
        {
            GD.Print("server");
            host.CreateServer(port, 10);
        }
        else
        {
            GD.Print("client");
            host.CreateClient(ip, port);
        }
        GetTree().NetworkPeer = host;
        GD.Print(GetTree().IsNetworkServer());




        Library library = new Library(ProjectSettings.GlobalizePath("res://Sets/"));
        DeckImporter deckimporter = new DeckImporter(ProjectSettings.GlobalizePath("res://Sets/Decks/"));



        //cardService.Draw(Player1);
        game = new StargateGame(library);
        game.InitPlayersWithDeck(deckimporter.Load("o'neil.o8d"), deckimporter.Load("o'neil.o8d"));

        //StargateGameMock.InitPlayersWithMock(game);


        Player1Vue = (PlayerControl)this.FindNode("PlayerControl");
        if (Player1Vue.Visible)
        {
            MappingMVC mappingMVC = new MappingMVC();
            mappingMVC.InitRessources(game.GameState.GetAllCards());
            Player1Vue.InitControl(game.GameState.player1, game.GameState.player2, mappingMVC, this);
            game.GameState.StargateResultHandler += Player1Vue.HandleResult;
        }

     


        Player2Vue = (PlayerControl)this.FindNode("PlayerControl2");
        if (Player2Vue.Visible)
        {
            MappingMVC mappingMVC2 = new MappingMVC();
            mappingMVC2.InitRessources(game.GameState.GetAllCards());
            Player2Vue.InitControl(game.GameState.player2, game.GameState.player1, mappingMVC2, this);
            game.GameState.StargateResultHandler += Player2Vue.HandleResult;

        }


        

        game.GameState.InitGame(seed);


       // ((WindowDialog)FindNode("WindowDialog")).PopupCentered();
    }



    [Sync]
    public void Network(string a , object[] b)
    {
         StargateEvent stargateEvent =  NetworkManager.GenerateStargateEvent(a, b);
         stargateEvent.Hydrate(game);
         game.GameState.ProcessEvent(stargateEvent);
    }


    public void SendEvent(StargateEvent stargateEvent){
        GD.Print(stargateEvent);


        if (GetTree().NetworkPeer.GetConnectionStatus() == NetworkedMultiplayerPeer.ConnectionStatus.Connected)
        {
             //NetworkStargateEvent e = stargateEvent.GenerateNetworkStargateEvent();
             
            
            Rpc("Network", NetworkManager.GenerateRPCAttr(stargateEvent));
        }
        else
        {
          //  SendEventnetwork(new NetworkEvent() { stargateEvent = stargateEvent });
        }
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

      
    }
}

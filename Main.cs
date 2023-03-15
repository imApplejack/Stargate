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

    [Export]
    public string ip;

    [Export]
    public int port;

    [Export]
    public int seed;



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


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

        game.GameState.InitGame(seed);


       // ((WindowDialog)FindNode("WindowDialog")).PopupCentered();
        

      

    }

    [Sync]
    public void SendEventnetwork(NetworkEvent stargateEvent)
    {
      //  stargateEvent.stargateEvent.Hydrate(game);
       // game.GameState.ProcessEvent(stargateEvent.stargateEvent);
    }


    [Sync]
    public void Pouet(EncodedObjectAsID networkStargateEvent)
    {
        // StargateEvent e = networkStargateEvent.GenerateStargateEvent();
        // e.Hydrate(game);

        ;

        Debug.WriteLine(GD.InstanceFromId(networkStargateEvent.ObjectId));

        // game.GameState.ProcessEvent(e);
        //Debug.WriteLine("POUET" + e);
    }


    [Sync]
    public void NetworkSelectCardEvent(int Sender, Godot.Collections.Array<int> cardModels)
    {
        NetworkSelectCardEvent e = new NetworkSelectCardEvent(Sender, cardModels.ToList());
        StargateEvent muhevent = e.GenerateStargateEvent();
        muhevent.Hydrate(game);
        game.GameState.ProcessEvent(muhevent);

    }

    public void SendEvent(StargateEvent stargateEvent){
        GD.Print(stargateEvent);


        if (GetTree().NetworkPeer.GetConnectionStatus() == NetworkedMultiplayerPeer.ConnectionStatus.Connected)
        {

            //Rpc("Pouet", 45 , 55);
            //  Debug.WriteLine("RPC");
            //  Debug.WriteLine("RPC");
            //  Rpc("SendEventnetwork", new NetworkEvent() { stargateEvent = stargateEvent });

             NetworkStargateEvent e = stargateEvent.GenerateNetworkStargateEvent();

             Rpc(e.RPCMethod(), e.RPCAttr());

           // Debug.WriteLine(e.RPCMethod() + e.RPCAttr()[0] + e.RPCAttr()[1]);
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

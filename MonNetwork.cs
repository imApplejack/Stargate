using Godot;
using System;

public class MonNetwork : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        var host = new NetworkedMultiplayerENet();
        host.CreateServer(6112, 5);
        GetTree().NetworkPeer = host;
        GD.Print(GetTree().NetworkPeer);

    }

 

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

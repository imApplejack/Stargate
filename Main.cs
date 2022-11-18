using Godot;
using Stargate;
using System;

public class Main : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";



    private StargateGame game;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        game = new StargateGame();

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

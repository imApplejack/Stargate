using Godot;
using Stargate.SGGodot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using System;

public class GDCharacter : GDCard
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }


    //private TextureRect stop;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void ExtraInit()
    {
    }

    public override void Decorate(MappingMVC mvc)
    {
        TextureRect stop = (TextureRect)FindNode("Stop");
        if (Card.State == CardState.Stop)
        {
            stop.Visible = true;
        }
        else
        {
            stop.Visible = false;
        }
    }
}

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
    
    
    public override void ExtraInit()
    {

    }

    public override GDCard Decorate(MappingMVC mvc)
    {
        if (Card.State == CardState.Stop)
        {
            ((CanvasItem)FindNode("Stop")).Visible = true;
        }
        else
        {
            ((CanvasItem)FindNode("Stop")).Visible = false;
        }
        return this;
    }

}

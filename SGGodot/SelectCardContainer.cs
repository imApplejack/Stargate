using Godot;
using Stargate.Stargate.Event;
using System;
using System.Collections.Generic;

public class SelectCardContainer : CardContainer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    [Signal]
    public delegate void close_popup();

    public override void ProcessCardAction(GDCard card)
    {
        ForwardEvent(new SelectCardEvent() { CardModelId = new List<int>() { card.Card.Id } } );
        //GetParent().QueueFree();
        EmitSignal("close_popup");
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

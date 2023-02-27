using Godot;
using Stargate.Stargate.Event;
using Stargate;
using System;
using Stargate.Stargate.Enum;

public class HandContainer : CardContainer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.


    public override void ProcessCardAction(GDCard card)
    {
        if ( card.Card.State == CardState.Hand)
        {
            ForwardEvent(new PlayCardEvent() { cardModel = card.Card });
        }   
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

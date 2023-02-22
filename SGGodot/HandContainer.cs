using Godot;
using Stargate.Stargate.Event;
using Stargate;
using System;

public class HandContainer : CardContainer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.


    public override void ProcessCardAction(GDCard card)
    {
        playEvent.EmitSignal("PlaySGEvent", new SGEventContainer(new PlayCardEvent() { player = card.Card.Owner, cardModel = card.Card }));
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

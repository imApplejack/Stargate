using Godot;
using Stargate;
using Stargate.Stargate.Event;
using System;
using System.Collections.Generic;

public class CardContainer : Container
{

    protected PlayEvent playEvent { get; set; }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        playEvent = GetNode<PlayEvent>("/root/PlayEvent");
    }


    public void ForwardEvent(StargateEvent sgevent)
    {
        playEvent.EmitSignal("PlaySGEvent", new SGEventContainer(sgevent));
    }


    public virtual void ProcessCardAction(GDCard card) // d'autres attr peut etre ?
    {
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {



    }
}

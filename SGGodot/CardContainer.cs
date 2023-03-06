using Godot;
using Stargate;
using Stargate.Stargate.Event;
using System;
using System.Collections.Generic;

public class CardContainer : Node
{


    [Signal] public delegate void SendEvent(SGEventContainer myEvent);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }


    public void ForwardEvent(StargateEvent sgevent)
    {

        //GD.Print(sgevent);
        EmitSignal("SendEvent", new SGEventContainer(sgevent));
    }


    public virtual void ProcessCardAction(GDCard card) // d'autres attr peut etre ?
    {
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {



    }
}

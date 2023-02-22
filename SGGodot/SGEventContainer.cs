using Godot;
using Stargate;
using Stargate.Stargate.Event;
using System;

public class SGEventContainer : Node
{
    public StargateEvent SGEvent { get; }

    public SGEventContainer(StargateEvent stargateEvent)
    {
        SGEvent = stargateEvent;
    }


}

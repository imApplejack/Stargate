using Godot;
using Stargate;
using Stargate.Stargate.Event;
using System;

public class PlayEvent : Node
{
    [Signal]
    delegate void PlayCard(GDCard card);

    [Signal]
    delegate void PlaySGEvent(SGEventContainer container);


}

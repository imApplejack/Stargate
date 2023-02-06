using Godot;
using System;

public class ZoomEvent : Node
{
    [Signal]
    delegate void ZoomEventSignal();
}

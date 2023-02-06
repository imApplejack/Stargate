using Godot;
using System;

public class ZoomEvent : Node
{
    [Signal]
    delegate void Enter(GDCard card);

    [Signal]
    delegate void Leave(GDCard card);
}

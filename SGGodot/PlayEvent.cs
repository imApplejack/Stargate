using Godot;
using System;

public class PlayEvent : Node
{
    [Signal]
    delegate void PlayCard(GDCard card);


}

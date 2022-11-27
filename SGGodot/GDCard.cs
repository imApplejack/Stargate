using Godot;
using Stargate;
using Stargate.Stargate;
using System;
using System.Data.Common;

public class GDCard : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;

    public CardModel Card { get; set; } = null;


    public void _on_Panel_mouse_entered()
    {
        GD.Print("enter " + this);
    }

    public void _on_Panel_mouse_exited()
    {
        GD.Print("leave " + this);
    }

}

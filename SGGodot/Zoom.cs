using Godot;
using System;

public class Zoom : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }


    public void _on_Character_focus_entered()
    {
        GD.Print("focus");
    }

    public void _on_Button_mouse_entered()
    {
        GD.Print("ouver button");
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

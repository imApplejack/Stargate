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

    private ZoomEvent zoomEvent { get; set; }

    private PlayEvent playEvent { get; set; }


    public override void _Ready()
    {
        zoomEvent = GetNode<ZoomEvent>("/root/ZoomEvent");
        playEvent = GetNode<PlayEvent>("/root/PlayEvent");
    }

    public void _on_Panel_mouse_entered()
    {
        GD.Print("enter " + this);
        zoomEvent.EmitSignal("Enter", this);
    }

    public void _on_Panel_mouse_exited()
    {
        GD.Print("leave " + this);
        zoomEvent.EmitSignal("Leave", this);
    }


    public void _on_Panel_gui_input(InputEvent _event)
    {
        InputEventMouseButton myMouseEvent = _event as InputEventMouseButton;

        if (myMouseEvent != null)
        {

            //if (myMouseEvent.ButtonIndex == (int)ButtonList.Left && myMouseEvent.Pressed == true &&  !GetTree().IsInputHandled())
            if (myMouseEvent.ButtonIndex == (int)ButtonList.Left && myMouseEvent.Pressed == true)
            {
                GD.Print("bouton sur une carte");
                playEvent.EmitSignal("PlayCard", this);
            }
        }
    }




}

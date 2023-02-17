using Godot;
using Stargate;
using Stargate.Stargate;
using System;
using System.Collections.Generic;
using System.Data.Common;

public class GDCard : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;


    private CardModel card = null;

    public CardModel Card
    {
        get
        {
           if(Origin != null) { return Origin.Card; } else { return card; }
        }
        set
        {
            card = value;
        }
    }

    private ZoomEvent zoomEvent { get; set; }

    private PlayEvent playEvent { get; set; }

    private List<GDCard> IngameInstances { get; set; } = new List<GDCard>();


    // permet de connaitre la GDCard Original situe dans le mappingMVC pour simplifier le code dans les appels depuis les enfants
    private GDCard Origin { get; set; } = null; 

    public void ClearIngameInstances()
    {
        foreach (Node item in IngameInstances)
        {
            item.QueueFree();
        }
        IngameInstances = new List<GDCard>();
    }

    public GDCard GetClone()
    {
        GDCard instance;
        if (Origin == null)
        {
            instance = (GDCard)this.Duplicate();
            IngameInstances.Add(instance);
            instance.Origin = this;
            return instance;
        }
        else
        {
            return   (GDCard)Origin.GetClone();
        }
    }


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

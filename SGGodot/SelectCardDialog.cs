using Godot;
using Stargate.Stargate.Card;
using Stargate.Stargate.Event;
using System;
using System.Collections.Generic;

public class SelectCardDialog : WindowDialog
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.


    private HBoxContainer BoxContainer;

    [Signal]
    public delegate void choose_card(int cardId);


    [Signal]
    public delegate void SendEvent(SGEventContainer myEvent);

    public override void _Ready()
    {
        BoxContainer = (HBoxContainer)FindNode("HBoxContainer");
        GD.PrintErr(BoxContainer);
    }


    public void CardSelect(int cardId)
    {
        EmitSignal("SendEvent", new SGEventContainer(new SelectCardEvent() { CardModelId = cardId }) );
    }

    public void Init(List<CardModel> list, int count)
    {

        GD.PrintErr(BoxContainer);
        PackedScene scene = GD.Load<PackedScene>("res://SGGodot/TextureRect05.tscn");

        foreach (CardModel item in list)
        {
            TextureRect05 instance  = (TextureRect05)scene.Instance();
            BoxContainer.AddChild(instance);
            instance.Init(item);
            instance.Connect("choose_card", this, "CardSelect");

           // ((SelectCardContainer)FindNode("HBoxContainer")).AddChild(item.GetClone()); // attention ici il n'y a pas le decorate
        }
        


    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

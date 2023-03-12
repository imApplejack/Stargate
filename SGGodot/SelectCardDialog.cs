using Godot;
using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.Result;
using System;
using System.Collections.Generic;
using System.Linq;

public class SelectCardDialog : WindowDialog
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.


    private HBoxContainer BoxContainer;

    private Button NoneButton;

    [Signal]
    public delegate void SendEvent(SGEventContainer myEvent);

    public override void _Ready()
    {
        BoxContainer = (HBoxContainer)FindNode("HBoxContainer");
        NoneButton = (Button)FindNode("NoneButton");
        GD.PrintErr(BoxContainer);
    }



    public void _on_NoneButton_button_down()
    {
        EmitSignal("SendEvent", new SGEventContainer(new SelectCardEvent()));
        QueueFree();
    }

    public void _on_OkButton_button_down()
    {
        EmitSignal("SendEvent", new SGEventContainer(new SelectCardEvent() { CardModelId = GetSelectedCardModelIds()}));
        QueueFree();
    }

    public void CardSelect(int cardId)
    {
        //EmitSignal("SendEvent", new SGEventContainer(new SelectCardEvent() { CardModelId = new List<int>() { cardId } }) );
        //QueueFree();
    }

    public List<CardModel> GetSelectedCardModel()
    {
        List<CardModel> retour = new List<CardModel>();
        foreach (TextureRect05 item in BoxContainer.GetChildren())
        {
            if (item.IsSelected())
            {
                retour.Add(item.Card);
            }
        }
        return retour;
    }

    public List<int> GetSelectedCardModelIds()
    {
        List<int> retour = new List<int>();
        foreach (CardModel item in GetSelectedCardModel())
        {
            retour.Add(item.Id);
        }
        return retour;
    }




    public void Init(ChooseCardResult chooseCardResult)
    {
        // SelectCardEnum n'est pas vraiment utilise ici
        if(chooseCardResult.Label != String.Empty)
        {
            WindowTitle = chooseCardResult.Label;
        }
       

        GD.PrintErr(BoxContainer);
        PackedScene scene = GD.Load<PackedScene>("res://SGGodot/TextureRect05.tscn");

        foreach (CardModel item in chooseCardResult.cards)
        {
            TextureRect05 instance  = (TextureRect05)scene.Instance();
            BoxContainer.AddChild(instance);
            instance.Init(item);
            instance.Connect("choose_card", this, "CardSelect");
        }

    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

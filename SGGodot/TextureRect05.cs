using Godot;
using Stargate.SGGodot;
using Stargate.Stargate.Card;
using System;

public class TextureRect05 : Panel
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public CardModel Card;
    TextureRect texture;
    Node2D selectOutlet;


    [Signal]
    public delegate void choose_card(int cardId);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
 
    }


    public bool IsSelected()
    {
        return selectOutlet.Visible;
    }
    public void Init(CardModel card)
    {
        Card = card;
        texture = (TextureRect)FindNode("TextureRect");
        selectOutlet = (Node2D)FindNode("SelectOutlet");
        texture.Texture = ResourceLoader.Load(Const.AssetPath + "/" + card.Card.Id + ".jpg") as Texture;
    }


    public void _on_Panel_gui_input(InputEvent _event)
    {
        InputEventMouseButton myMouseEvent = _event as InputEventMouseButton;

        if (myMouseEvent != null)
        {

            if (myMouseEvent.ButtonIndex == (int)ButtonList.Left && myMouseEvent.Pressed == true)
            {
                selectOutlet.Visible = !selectOutlet.Visible;
                //EmitSignal("choose_card", Card.Id);
               
            }
        }
    }



    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

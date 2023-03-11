using Godot;
using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using System;

public class CardAction : WindowDialog
{
    // Declare member variables here. Examples:
    // private int a = 2;
     private TextureRect CardTexture;

     private Container ActionContainer;

     private GDCard Card;



    public void CardActionSignal(SGEventContainer stargateEventContainer){

       

        CardContainer parent = (CardContainer)GetParent();
        parent.ForwardEvent(stargateEventContainer.SGEvent);
        QueueFree();
    }


    private Godot.Collections.Array EventSignalUtil(StargateEvent se)
    {
        return new Godot.Collections.Array() { new SGEventContainer(se) };
    }


    private Button PlayCardButton()
    {
        Button button = new Button();
        button.Text = "Play Card";
        button.Connect("button_down", this, "CardActionSignal", EventSignalUtil(new PlayCardEvent() { CardModelId = Card.Card.Id } ));
        return button;
    }
    private Button AssignCardButton()
    {
        Button button = new Button();
        button.Text = "Assign Card";
        button.Connect("button_down", this, "CardActionSignal", EventSignalUtil(new AssignCharEvent() { CardModelId = Card.Card.Id }));
        return button;
    }


    private Button PlayComplicationButton()
    {
        Button button = new Button();
        button.Text = "Play complication";
        button.Connect("button_down", this, "CardActionSignal", EventSignalUtil(new PlayComplicationEvent() { CardModelId = Card.Card.Id }));
        return button;
    }


    private Button BoostButton()
    {
        Button button = new Button();
        button.Text = "Boost";
        button.Connect("button_down", this, "CardActionSignal", EventSignalUtil(new BoostCharEvent() { CardModelId = Card.Card.Id }));
        return button;
    }



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        CardTexture = (TextureRect)FindNode("Texture");
        ActionContainer = (Container)FindNode("ActionContainer");
        CardTexture.Texture = Card.Cardbackground.Texture;

        if(Card.Card.State == CardState.Hand)
        {
            ActionContainer.AddChild(PlayCardButton());
            ActionContainer.AddChild(PlayComplicationButton());


            if( (Card.Card.Card.Type & CardType.Character ) != 0)
            {
                ActionContainer.AddChild(BoostButton());
            }



        }


        if (Card.Card.State == CardState.Ready && (Card.Card.Card.Type & CardType.Character ) != 0)
        {
            ActionContainer.AddChild(AssignCardButton());
        }


    }

    public void Init(GDCard gdcard)
    {
        Card = gdcard;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

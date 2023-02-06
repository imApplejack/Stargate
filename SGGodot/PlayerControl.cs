using Godot;
using Stargate;
using Stargate.SGGodot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using System;

public class PlayerControl : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    public CardContainer TeamContainer;
    public CardContainer BoardContainer;
    public CardContainer HandContainer;
    public BoxContainer MissionContainer;
    public MappingMVC MappingMVC { get; set; }
    public Player player { get; set; }

    private ZoomEvent zoomEvent { get; set; }


    public Main Api { get; set; }  // api stargate en pointeur  = dirty



    public void ZoomEvent()
    {
        GD.PrintErr("zoom sur la carte");
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       
        TeamContainer = (CardContainer)this.FindNode("TeamContainer");
        BoardContainer = (CardContainer)this.FindNode("BoardContainer");
        HandContainer = (CardContainer)this.FindNode("HandContainer");
        MissionContainer = (HBoxContainer)this.FindNode("MissionContainer");
        zoomEvent = GetNode<ZoomEvent>("/root/ZoomEvent");
        zoomEvent.Connect("ZoomEventSignal", this, "ZoomEvent");

    }





    public void MajCardControl(CardModel card)
    {

        GDCard GDCard = this.GetCard(card);

        if (GDCard.GetParent() is CardContainer)
        {
            GDCard.GetParent().RemoveChild(GDCard);
        }


        if (card.Owner == this.player)
        {
            switch (GDCard.Card.State)
            {
                case CardState.Hand:
                {
                    HandContainer.AddChild(GDCard);
                    break;
                }
                case CardState.Team:
                {
                    TeamContainer.AddChild(GDCard);
                    break;
                }
                case CardState.Ready:
                {
                    BoardContainer.AddChild(GDCard);
                    break;
                }

                case CardState.Mission:
                { 
                    // ici gerer le type de carte en mission ou deleger au script de mission container
                    MissionContainer.AddChild(GDCard);
                    break;
                }
             
                default:
                    break;
            }
        }
        else
        {
            // @todo adversaire
        }
    }


    public void AskForDraw()
    {

        //GD.Print(Api);
        //GD.Print(this.player);
        Api.AskForDraw(this.player);
    }


    private GDCard GetCard(CardModel card)
    {
        return this.MappingMVC.Get(card);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

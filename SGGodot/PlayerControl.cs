using Godot;
using Stargate;
using Stargate.SGGodot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
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
    public Control ZoomContainer;
    public MappingMVC MappingMVC { get; set; }
    public Player player { get; set; }

    private ZoomEvent zoomEvent { get; set; }

    private PlayEvent playEvent { get; set; }

    public Main Api { get; set; }  // api stargate en pointeur  = dirty



    public void EnterZoom(GDCard card)
    {
        GD.PrintErr("zoom sur la carte", card);

        GDCard myZoomedCard = (GDCard)card.Duplicate();
        myZoomedCard.RectPosition = new Vector2(0,0);

        ZoomContainer.AddChild(myZoomedCard);
    }

    public void LeaveZoom(GDCard card)
    {
        GD.PrintErr("dezoom sur la carte", card);
        foreach (Node item in ZoomContainer.GetChildren())
        {
            item.QueueFree();
        }  
    }



    public void PlayCard(GDCard card)
    {
        GD.PrintErr("playCard", card);
        Api.SendEvent(new PlayCardEvent() { player = player, cardModel = card.Card });
    }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       
        TeamContainer = (CardContainer)this.FindNode("TeamContainer");
        BoardContainer = (CardContainer)this.FindNode("BoardContainer");
        HandContainer = (CardContainer)this.FindNode("HandContainer");
        MissionContainer = (HBoxContainer)this.FindNode("MissionContainer");
        ZoomContainer = (Control)this.FindNode("ZoomContainer");
        zoomEvent = GetNode<ZoomEvent>("/root/ZoomEvent");
        zoomEvent.Connect("Enter", this, "EnterZoom");
        zoomEvent.Connect("Leave", this, "LeaveZoom");

        playEvent = GetNode<PlayEvent>("/root/PlayEvent");
        playEvent.Connect("PlayCard", this, "PlayCard");
    }





    /// <summary>
    /// permet de mettre à jour tout le plateau de jeu éé
    /// </summary>
    public void MajControl()
    {
        foreach (var item in MappingMVC.Mapping)
        {
            MajCardControl(item.Key);
        }
    }

    public void MajPlayerAttr(Player _player)
    {

        if (player == _player)
        {
            ((Label)FindNode("PowerLabel")).Text = _player.Energy.ToString();
        }
        else
        {
            // @todo adversaire
        }

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

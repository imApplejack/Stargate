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

    public CardContainer EnemyTeamContainer;
    public CardContainer EnemyBoardContainer;
    public CardContainer EnemyHandContainer;

    public MissionContainer MissionContainer;
    public Control ZoomContainer;
    public MappingMVC MappingMVC { get; set; }

    private Player player;
    
    public Player Player { get { return player; } set {
            player = value; 
        } }

    private ZoomEvent zoomEvent { get; set; }

    private PlayEvent playEvent { get; set; }

    public Main Api { get; set; }  // api stargate en pointeur  = dirty




    public void _on_PassButton_button_down()
    {
        GD.Print("PASSBUTTK");
        Api.SendEvent(new PassEvent() { player = Player });
    }

    public void EnterZoom(GDCard card)
    {
       // if (card.Card.Owner == player)
        // hack nul à cause des message partagés
        {
            GD.PrintErr("zoom sur la carte", card);

            if (IsInstanceValid(card) && !card.IsQueuedForDeletion())
            {
                GDCard myZoomedCard = (GDCard)card.GetClone();
                ZoomContainer.AddChild(myZoomedCard);
            }
        }
    }

    public void LeaveZoom(GDCard card)
    {
        //if (card.Card.Owner == player)
        // hack nul à cause des message partagés
        {
            GD.PrintErr("dezoom sur la carte", card);
            foreach (Node item in ZoomContainer.GetChildren())
            {
                item.QueueFree();
            }
        }
    }



    public void PlayCard(GDCard card)
    {

        if(card.Card.Owner == Player && card.Card.State == CardState.Hand)
            // hack nul à cause des message partagés
        {
            GD.PrintErr("playCard", card);
            Api.SendEvent(new PlayCardEvent() { player = Player, cardModel = card.Card });
        }

        else if (card.Card.Owner == Player && (card.Card.State == CardState.Ready || card.Card.State == CardState.Team))
        {
            GD.PrintErr("AssignCard", card);
            Api.SendEvent(new AssignCharEvent() { player = Player, cardModel = card.Card });
        }
       
    }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       
        TeamContainer = (CardContainer)this.FindNode("TeamContainer");
        BoardContainer = (CardContainer)this.FindNode("BoardContainer");
        HandContainer = (CardContainer)this.FindNode("HandContainer");

        EnemyTeamContainer = (CardContainer)this.FindNode("EnemyTeamContainer");
        EnemyBoardContainer = (CardContainer)this.FindNode("EnemyBoardContainer");
        EnemyHandContainer = (CardContainer)this.FindNode("EnemyHandContainer");


        MissionContainer = (MissionContainer)this.FindNode("MissionContainer");


        ZoomContainer = (Control)this.FindNode("ZoomContainer");
        zoomEvent = GetNode<ZoomEvent>("/root/ZoomEvent");
        zoomEvent.Connect("Enter", this, "EnterZoom");
        zoomEvent.Connect("Leave", this, "LeaveZoom");

        playEvent = GetNode<PlayEvent>("/root/PlayEvent");
        playEvent.Connect("PlayCard", this, "PlayCard");
    }


    public void Init()
    {
        MissionContainer.player = player;
        MajControl();
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
        GDCard.ClearIngameInstances();

        if (card.Owner == this.player)
        {
            switch (GDCard.Card.State)
            {
                case CardState.Hand:
                    {
                        HandContainer.AddChild(GDCard.GetClone());
                        break;
                    }
                case CardState.Team:
                    {
                        TeamContainer.AddChild(GDCard.GetClone());
                        break;
                    }
                case CardState.Ready:
                    {
                        BoardContainer.AddChild(GDCard.GetClone());
                        break;
                    }

                case CardState.Mission:
                    {
                        MissionContainer.Assign(GDCard.GetClone());
                        break;
                    }

                default:
                    break;
            }
        }
        else
        {
            
            switch (GDCard.Card.State)
            {
                case CardState.Hand:
                    {
                        EnemyHandContainer.AddChild(GDCard.GetClone());
                        break;
                    }

                case CardState.Team:
                    {
                        EnemyTeamContainer.AddChild(GDCard.GetClone());
                        break;
                    }
                case CardState.Ready:
                    {
                        EnemyBoardContainer.AddChild(GDCard.GetClone());
                        break;
                    }

                case CardState.Mission:
                    {
                        MissionContainer.Assign(GDCard.GetClone());
                        break;
                    }

                default:
                    break;
            }
            
        }
    }


    private GDCard GetCard(CardModel card)
    {
        return this.MappingMVC.Get(card);
    }


    public void HandleResult(object sender, EventArgs e)
    {
        MajVue((StargateResult)e);
    }

    public void MajVue(StargateResult result)
    {

        if (result.actionResult == ActionResult.Success)
        {
            switch (result.StargateResultType)
            {

                case StargateResultType.ChangeCard:
                    {
                        CardModel card = (CardModel)result.attr;
                        MajCardControl(card);
                        break;
                    }

                case StargateResultType.ChangePlayerAttr:
                    {
                        Player card = (Player)result.attr;
                        MajPlayerAttr(card);
                        break;
                    }
            }
        }
    }



    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

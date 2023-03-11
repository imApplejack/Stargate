using Godot;
using Godot.Collections;
using Stargate;
using Stargate.SGGodot;
using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.Result;
using System;
using System.Collections.Generic;

public class PlayerControl : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    public Node TeamContainer;
    public Node BoardContainer;
    public Node HandContainer;

    public Node EnemyTeamContainer;
    public Node EnemyBoardContainer;
    public Node EnemyHandContainer;

    public MissionContainer MissionContainer;
    public Control ZoomContainer;
    public MappingMVC MappingMVC { get; set; }

    private Player player;

    private PlayerUX PlayerUX;

    private PlayerUX EnnemyUX;

    
    public Player Player { get { return player; } set {
            player = value; 
        } }

    private ZoomEvent zoomEvent { get; set; }

    private PlayEvent playEvent { get; set; }

    public Main Api { get; set; }  // api stargate en pointeur  = dirty




    public void _on_PassButton_button_down()
    {
        //GD.Print("PASSBUTTK");
        Api.SendEvent(new PassEvent() { SenderId = Player.id });
    }

    public void EnterZoom(GDCard card)
    {
       // if (card.Card.Owner == player)
        // hack nul à cause des message partagés
        {
            //GD.PrintErr("zoom sur la carte", card);

            if (IsInstanceValid(card) && !card.IsQueuedForDeletion())
            {
                GDCard myZoomedCard = (GDCard)card.Duplicate();
                ZoomContainer.AddChild(myZoomedCard);
            }
        }
    }

    public void LeaveZoom(GDCard card)
    {
        //if (card.Card.Owner == player)
        // hack nul à cause des message partagés
        {
            //GD.PrintErr("dezoom sur la carte", card);
            foreach (Node item in ZoomContainer.GetChildren())
            {

                 if (IsInstanceValid(item) && !item.IsQueuedForDeletion())
                 {
                   item.QueueFree();
                 }
                   
            }
        }
    }


    
    public void PlayEvent(SGEventContainer container)
    {
        //GD.Print("Reception de event " + container.SGEvent);
        StargateEvent se = container.SGEvent;
        se.SenderId = player.id;
        Api.SendEvent(container.SGEvent);
    }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       
        TeamContainer = (Node)this.FindNode("TeamContainer");
        BoardContainer = (Node)this.FindNode("BoardContainer");
        HandContainer = (Node)this.FindNode("HandContainer");

        EnemyTeamContainer = (Node)this.FindNode("EnemyTeamContainer");
        EnemyBoardContainer = (Node)this.FindNode("EnemyBoardContainer");
        EnemyHandContainer = (Node)this.FindNode("EnemyHandContainer");


        MissionContainer = (MissionContainer)this.FindNode("MissionContainer");


        ZoomContainer = (Control)this.FindNode("ZoomContainer");
        zoomEvent = GetNode<ZoomEvent>("/root/ZoomEvent");
        zoomEvent.Connect("Enter", this, "EnterZoom");
        zoomEvent.Connect("Leave", this, "LeaveZoom");

        playEvent = GetNode<PlayEvent>("/root/PlayEvent");
        playEvent.Connect("PlaySGEvent", this, "PlayEvent");

        PlayerUX = (PlayerUX)FindNode("PlayerUX");
        EnnemyUX = (PlayerUX)FindNode("EnnemyUX");

        /*
        ConfirmationDialog cg = new ConfirmationDialog();
        AddChild(cg);
        cg.Show();
        */




        try
        {
            /*  Popup p = (Popup)this.FindNode("PopupDialog");
              p.RectSize = ((HBoxContainer)p.FindNode("HBoxContainer")).RectSize;
              p.RectSize = p.RectSize + new Vector2(30.0f, 100.0f);
              p.Show();*/

        }
        catch(Exception e) { }   
    }

 

    public void InitControl(Player theplayer, Player theOtherPlayer, MappingMVC mappingMVC, Main api)
    {
        Player = theplayer;
        Api = api;
        MappingMVC = mappingMVC;

        PlayerUX.player = theplayer;
        EnnemyUX.player = theOtherPlayer;

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


    public GDCard CreateDecoratedCloneInstance(GDCard card)
    {
        GDCard Cloned = card.GetClone();
        Cloned.Decorate(MappingMVC);
        return Cloned;
    }

    public List<GDCard> CreateDecoratedCloneInstance(List<GDCard> cards)
    {
        List<GDCard> retour = new List<GDCard>();
        foreach (GDCard card in cards)
        {
            GDCard Cloned = card.GetClone();
            Cloned.Decorate(MappingMVC);
            retour.Add(Cloned);
        }
        return retour;
    }

    public void MajCardControl(CardModel card)
    {

        //GD.PrintErr("Maj card control");

        GDCard GDCard = MappingMVC.Get(card);
        GDCard.ClearIngameInstances();

       

        GDCard Cloned = CreateDecoratedCloneInstance(GDCard);
    

        //GD.Print(GDCard.Card);

        if (card.Owner == this.player)
        {

            if ((GDCard.Card.State & CardState.Hand) != 0)
                {
                    HandContainer.AddChild(Cloned);
                       
                }
            else if ( (GDCard.Card.State & CardState.Board) != 0 )
                {
               
                    if (GDCard.Card.Card.Type == CardType.TeamCharacter)
                    {
                        TeamContainer.AddChild(Cloned);
                    }
                    else
                    {
                        BoardContainer.AddChild(Cloned);
                    }
                       
                }
                else if ((GDCard.Card.State & CardState.Mission) != 0)
                {
                    MissionContainer.Assign(Cloned);    
                }

        }
        else
        {
            
            switch (GDCard.Card.State)
            {
                case CardState.Hand:
                    {
                        EnemyHandContainer.AddChild(Cloned);
                        break;
                    }

                case CardState.Ready:
                    {

                        if(GDCard.Card.Card.Type == CardType.TeamCharacter)
                        {
                            EnemyTeamContainer.AddChild(Cloned);
                        }
                        else
                        {
                            EnemyBoardContainer.AddChild(Cloned);
                        }
                        break;
                    }


                case CardState.Stop:
                    {

                        if (GDCard.Card.Card.Type == CardType.TeamCharacter)
                        {
                            EnemyTeamContainer.AddChild(Cloned);
                        }
                        else
                        {
                            EnemyBoardContainer.AddChild(Cloned);
                        }
                        break;
                    }


                case CardState.Mission:
                    {
                        MissionContainer.Assign(Cloned);
                        break;
                    }

                default:
                    break;
            }
            
        }
    }



    public void HandleResult(object sender, EventArgs e)
    {
        MajVue((StargateResult)e);
    }


    public void PopupDialog(ChooseCardResult popupdialogattr)
    {

        PackedScene scene = GD.Load<PackedScene>("res://SGGodot/SGPopupDialog.tscn");
        SGPopupDialog instance = (SGPopupDialog)scene.Instance();
        
        instance.Init(CreateDecoratedCloneInstance(MappingMVC.Get(popupdialogattr.cards)), popupdialogattr.count);
        this.AddChild(instance);
        instance.FindNode("HBoxContainer").Connect("SendEvent", this, "PlayEvent");

        instance.Show();
    }

    public void ContinueQuestDialog()
    {  
        PackedScene cg = GD.Load<PackedScene>("res://SGGodot/ContinueQuestContainer.tscn");
        ConfirmationDialog cgI = (ConfirmationDialog)cg.Instance();
        AddChild(cgI);
        cgI.Connect("confirmed", this, "PlayEvent", new Godot.Collections.Array() { new SGEventContainer(new ContinueQuestEvent() { response = ContinueQuestEventResponse.YES })});
        cgI.GetCancel().Connect("pressed", this, "PlayEvent", new Godot.Collections.Array() { new SGEventContainer(new ContinueQuestEvent() { response = ContinueQuestEventResponse.NO }) });
        cgI.Popup_();
    }


  
    public void MajVue(StargateResult result)
    {


       // GD.PrintErr("MAJ VUE " + result);

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


                 // refaire lui peut etre ?
                /*case StargateResultType.ChangePlayerAttr:
                    {
                        Player card = (Player)result.attr;
                      
                        break;
                    }*/

                case StargateResultType.ChooseCard:
                    {
                        ChooseCardResult e = (ChooseCardResult)result;
                        if(e.player == player)
                        {
                            PopupDialog(e);
                        }

                        break;
                    }


                case StargateResultType.ContinueQuest:
                    {
                        ContinueQuestResult e = (ContinueQuestResult)result;
                        if (e.player == player)
                        {
                            ContinueQuestDialog();
                        }

                        break;
                    }


            }

            PlayerUX.Update();
            EnnemyUX.Update();
        }
    }



    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

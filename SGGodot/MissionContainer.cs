using Godot;
using Stargate;
using Stargate.Stargate.Enum;
using System;

public class MissionContainer : HBoxContainer
{

    public Player player { get; set; }

    private VBoxContainer missionContainer { get; set; }

    private HBoxContainer playerContainer { get; set; }

    private HBoxContainer enemyContainer { get; set; }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        missionContainer = (VBoxContainer)FindNode("MissionCardContainer");
        playerContainer = (HBoxContainer)FindNode("PlayerMissionContainer");
        enemyContainer = (HBoxContainer)FindNode("EnemyMissionContainer");
    }

    public void Assign(GDCard card)
    {
        if(card.Card.Card.Type == CardType.Mission)
        {

            //GD.Print("mission");
            missionContainer.AddChild(card);
        }
        else if(card.Card.Owner == player)
        {
            //GD.Print("player");
            playerContainer.AddChild(card);
        }
        else
        {
            //GD.Print("enemy");
            enemyContainer.AddChild(card);
        }
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

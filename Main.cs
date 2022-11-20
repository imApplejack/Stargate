using Godot;
using Stargate;
using System;
using System.Collections.Generic;

public class Main : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";



    private StargateGame game;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        Player player1 = new Player();
        //player1.Team = new List<SGCharacter>() { new SGCharacter() { Combat = 2, Culture = 3, Ingenuity = 0, Science = 1 }, new SGCharacter(), new SGCharacter(), new SGCharacter() } ;

        player1.Team = new List<SGCharacter>() { new SGCharacter() { Combat = 2, Culture = 3, Ingenuity = 0, Science = 1 }, new SGCharacter() { Combat = 1, Culture = 0, Ingenuity = 0, Science = 1 } , };

        Player player2 = new Player();
        game = new StargateGame(player1, player2);




        this.intTeamPanel(player1.Team);
    }


    private void intTeamPanel(List<SGCharacter> characters)
    {

        TeamContainer tm = (TeamContainer)this.GetNode("TeamContainer");
        tm.Team = characters;
        tm.initTeam();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

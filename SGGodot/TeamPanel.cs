using Godot;
using Stargate;
using System;
using System.Collections.Generic;

public class TeamPanel : Container
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public List<SGCharacter> Team { get; set;}

  //  Control test = null;


   // public bool a = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    

       

       // foreach (SGCharacter item in Team)
       // {
            //var instance = scene.Instance();

           // Character newChar = new Character(item);
          //  AddChild(instance);
       // }
        

//        test = (Control)GetNode("Character");

    }


    public void initTeam()
    {
        GD.Print(Team);
        foreach (SGCharacter item in Team)
        {
            AddChild(Character.Factory(item));
        }
        
    }
    


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {


       // GD.Print(GetChildren()[0]);

       // Character c = (Character)GetChildren()[0];
       // c.SGCharacter = Team[0];
       // c.

    //    (Character)GetChildren()[0].SGC

        /*if (GetChildren().Count == 1)
        {
            this.RemoveChild(test);
        }
        else
        {
            this.AddChild(test);
        }*/

        // this.RemoveChild(GetNode("Character"));

    }
}

using Godot;
using Stargate;
using System;

public class Character : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.


    public SGCharacter SGCharacter { get; set; }  = null;

    Label Culture;
    Label Science;
    Label Combat;
    Label Ingenuity;


    public override void _Ready()
    {
        Culture = (Label)GetNode("Panel/Culture");
        Science = (Label)GetNode("Panel/Science");
        Combat = (Label)GetNode("Panel/Combat");
        Ingenuity = (Label)GetNode("Panel/Ingenuity");
        Build();
    }


    public void Build()
    {
        Culture.Text = SGCharacter.Culture.ToString();
        Science.Text = SGCharacter.Science.ToString();
        Combat.Text = SGCharacter.Combat.ToString();
        Ingenuity.Text = SGCharacter.Ingenuity.ToString();
        
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
      //  GD.Print("draw objet");
       // GD.Print(SGCharacter.ToString());

      //  Build();
    }
}

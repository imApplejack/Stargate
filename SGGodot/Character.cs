using Godot;
using Stargate;
using Stargate.Stargate;
using System;
using System.Data.Common;

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
    Label Cost;


    public override void _Ready()
    {

        GD.Print(this);

        Culture = (Label)GetNode("Panel/Culture");
        Science = (Label)GetNode("Panel/Science");
        Combat = (Label)GetNode("Panel/Combat");
        Ingenuity = (Label)GetNode("Panel/Ingenuity");
        Cost = (Label)GetNode("Panel/Cost");
        Build();
    }

    public void _on_Panel_mouse_entered()
    {
        GD.Print("enter " + this);
    }

    public void _on_Panel_mouse_exited()
    {
        GD.Print("leave " + this);
    }
    


    public static Character Factory(SGCharacter character)
    {
        // probablement mettre ca au dessus pour des raisons de perf
        var scene = GD.Load<PackedScene>("res://SGGodot/Character.tscn");
        Character instance = (Character)scene.Instance();
        CardModel.CardModelObservable += new EventHandler(instance.HandleRefreshCard);
        instance.SGCharacter = character;
        return instance;

    }

    public void Build()
    {

        if (SGCharacter != null)
        {
            Culture.Text = SGCharacter.Culture.ToString();
            Science.Text = SGCharacter.Science.ToString();
            Combat.Text = SGCharacter.Combat.ToString();
            Ingenuity.Text = SGCharacter.Ingenuity.ToString();
            Cost.Text = SGCharacter.Cost.ToString();
        }
 
    }


    public void HandleRefreshCard(object sender, EventArgs e)
    {
        if(sender is CardModel)
        {
            GD.Print("card maj {1} de: {0}", sender.ToString(), e.ToString());

        }

      
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
  {
      //  GD.Print("draw objet");
       // GD.Print(SGCharacter.ToString());

      //  Build();
    }
}

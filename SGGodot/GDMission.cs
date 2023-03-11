using Godot;
using Stargate.SGGodot;
using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;

public class GDMission : GDCard
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    public Texture GlyphTexture;

    public override void ExtraInit()
    {

        // GD.PrintErr(Card.Card);
         GlyphTexture = ResourceLoader.Load("res://Asset/" +  (Card.Card.Glyphe).ToString().ToLower() + ".png") as Texture;
    }



    public override void Decorate(MappingMVC mvc)
    {
        Label Difficulty = (Label)FindNode("Difficulty");
        Difficulty.Text = ((MissionModel)Card).getMissionDifficulty().ToString();

    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

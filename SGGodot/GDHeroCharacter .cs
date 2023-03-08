using Godot;
using Stargate.SGGodot;
using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;

public class GDHeroCharacter : GDCharacter
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }


    //public VBoxContainer glypheContainer = null;

    public override void _Ready()
    {
       base._Ready();
      //  glypheContainer = (VBoxContainer)FindNode("Glyphes"); // ca ca bug je sais pas pourquoi
    }


    public override void Decorate(MappingMVC mvc)
    {
        base.Decorate(mvc);
        //HeroCharacterModel buffer = (HeroCharacterModel)Card;
        Node glypheContainer = FindNode("Glyphes");
        
        
        foreach (Node item in glypheContainer.GetChildren())
        {
            //GD.Print("dans le foreach");
            //item.QueueFree();
        }
        //GD.Print("count glype" + ((HeroCharacterModel)Card).glyphsEarned.Count);
        foreach (MissionModel item in ((HeroCharacterModel)Card).glyphsEarned)
        {
            TextureRect t = new TextureRect();
            t.Texture = ((GDMission)mvc.Get(item)).GlyphTexture;
            //GD.PrintErr("t.Texture : "+ t.Texture+ " glypheContainer :  " + FindNode("Glyphes"));
             glypheContainer.AddChild(t); 
        }
    }

}

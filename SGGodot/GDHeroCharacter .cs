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


    public Node glypheContainer = null;

    public override void _Ready()
    {
       base._Ready();
       glypheContainer = FindNode("Glyphes");
    }


    public override GDCard Decorate(MappingMVC mvc)
    {
        base.Decorate(mvc);
        //HeroCharacterModel buffer = (HeroCharacterModel)Card;

        foreach (MissionModel item in ((HeroCharacterModel)Card).glyphsEarned)
        {
            TextureRect t = new TextureRect();
            t.Texture = ((GDMission)mvc.Get(item)).GlyphTexture;
            glypheContainer.AddChild(t); 
        }
        return this;
    }

}

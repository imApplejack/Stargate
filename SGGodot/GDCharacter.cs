using Godot;
using Stargate;
using Stargate.SGGodot;
using Stargate.Stargate;
using Stargate.Stargate.Card;
using Stargate.Stargate.Card.Interface;
using Stargate.Stargate.Enum;
using System;

public class GDCharacter : GDCard
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


    //private TextureRect stop;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void ExtraInit()
    {
    }

    public override void Decorate(MappingMVC mvc)
    {
        TextureRect stop = (TextureRect)FindNode("Stop");
        if (Card.State == CardState.Stop)
        {
            stop.Visible = true;
        }
        else
        {
            stop.Visible = false;
        }


        ManageSkillsVisibility(Skill.Ingenuity);
        ManageSkillsVisibility(Skill.Combat);
        ManageSkillsVisibility(Skill.Science);
        ManageSkillsVisibility(Skill.Culture);

        //Control Ingenuity = (Control)FindNode("Ingenuity");
        //Ingenuity.Visible = true;
    }



    private void ManageSkillsVisibility(Skill skill)
    {
        ISGSkill chara = (ISGSkill)Card;
        if (chara.GetSkill(skill) != null)
        {
            Control loc = (Control)FindNode(skill.ToString());
            ((Label)loc.FindNode("Label")).Text = ((int)chara.GetSkill(skill)).ToString();
            loc.Visible = true;
        }
    }



}

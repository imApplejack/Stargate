using Godot;
using Stargate;
using System;

public class PlayerUX : Panel
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public Player player;

    protected Label powerLabel;

    protected ProgressBar victoryProgressBar;

    protected ProgressBar villanProgressBar;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        powerLabel = (Label)FindNode("PowerLabel");
        victoryProgressBar = (ProgressBar)FindNode("VictoryProgressBar");
        villanProgressBar = (ProgressBar)FindNode("VillanProgressBar");
    }

    public override void _Draw()
    {
        base._Draw();


        powerLabel.Text = "Power : " + player.Energy.ToString();


        victoryProgressBar.MaxValue = player.TotalExperience();
        victoryProgressBar.Value = player.VictoryTotal();


    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

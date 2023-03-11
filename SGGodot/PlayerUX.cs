using Godot;
using Stargate;
using Stargate.Stargate;
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

    protected Label library;

    protected Label missionPile;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        powerLabel = (Label)FindNode("PowerLabel");
        victoryProgressBar = (ProgressBar)FindNode("VictoryProgressBar");
        villanProgressBar = (ProgressBar)FindNode("VillanProgressBar");
        library = (Label)FindNode("Library");
        missionPile = (Label)FindNode("MissionPile");
    }

    public override void _Draw()
    {
        base._Draw();

        powerLabel.Text = "Power : " + player.Energy.ToString();
        library.Text = "Library : " + player.Library();
        missionPile.Text = "Mission Pile : " + player.MissionPile();
        victoryProgressBar.MaxValue = player.TotalExperience();
        victoryProgressBar.Value = player.VictoryTotal();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

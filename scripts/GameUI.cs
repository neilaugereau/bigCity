using Godot;
using System;

public partial class GameUI : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        //Change the value of the label_nbCoins (coins nb of the player)
        this.GetNode<Label>("label_nbCoins").Text = "";
    }

    public void _on_btn_dice_pressed()
	{
		//On click on the button dice
		// how to modify enabled : this.GetNode<BaseButton>("btn_dice").Disabled = false;
	}
}

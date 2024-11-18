using Godot;
using System;

public partial class GameUI : Control
{
	public event EventHandler BtnDicePressed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        //Change the value of the label_nbCoins (coins nb of the player)
        this.GetNode<Label>("label_nbCoins").Text = this.GetNode<Game>("../Game").mainPlayer.money.ToString();
    }

	public void _on_btn_dice_pressed()
	{
		BtnDicePressed?.Invoke(this, null);
	}
}

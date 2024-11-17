using Godot;
using System;

public partial class Controller : Node
{
	Game game;
	player owner;

	public Controller(player owner, Game game)
	{
		this.owner = owner;
		this.game = game;

	}

	public virtual void ChooseAction() { }

}

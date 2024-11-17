
using Godot;
using System;

public class LandedEventArgs : EventArgs
{
    public int Value { get; private set; }

    public LandedEventArgs(int value)
    {
        Value = value;
    }
}

public partial class DiceManager : Node
{
	public event EventHandler<LandedEventArgs> AllDiceLanded;

	[Export] private PackedScene objectToSpawn;

	private Godot.Collections.Array<Node> diceArray;
	public void ThrowDices(int n = 1)
	{
		for (int i = 0; i < n; i++)
		{
			diceArray.Add(objectToSpawn.Instantiate());
			(diceArray[-1] as Dice).Landed += DiceLanded;
			AddChild(diceArray[-1]);
			if (diceArray[-1] is RigidBody3D firstRigidBody)
				firstRigidBody.Position = new Vector3(0, 5, 0);
		}
	}

	private void DiceLanded(object sender, EventArgs e) 
	{
		int valueSum = 0;
		foreach (Node node in diceArray)
		{
			if (!(node as Dice).HasLanded)
				return;
			valueSum += (node as Dice).GetDiceValue();
		}

		AllDiceLanded?.Invoke(this, new LandedEventArgs(valueSum));
		diceArray.Clear();
	}
}
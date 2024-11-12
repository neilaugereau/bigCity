using System;

namespace BigCity.scripts;

public class Dice
{
	Random random = new();
	public int ThrowDice()
	{
		int currentFaces = random.Next(1,6);
		return currentFaces;
	}
}

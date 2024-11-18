using Godot;
using System.Collections.Generic;

public partial class Piles : Node
{
	public E_Building card;
	public int number;

	public Piles(E_Building _card,int _number)
	{
		card = _card;
		number = _number;
	}

	public CardBase GetCards(player owner)
	{
		if (number > 0)
		{
			number--;
			CardBase output = Globals.Building[card];
			output.owner = owner;
			return output; 
		}
		return null;
	}
}

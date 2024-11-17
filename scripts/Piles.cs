using Godot;
using System.Collections.Generic;
namespace BigCity.scripts;


public partial class Piles : Node
{
	public Card card;
	public int number;

	public Piles(Card _card,int _number)
	{
		card = _card;
		number = _number;
	}

	public Card GetCards()
	{
		if (number > 0)
		{
			number--;
			return null; 
		}
		return null;
	}
}

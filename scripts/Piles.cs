using Godot;
using System.Collections.Generic;
namespace BigCity.scripts;


public partial class Piles : Node
{
	public CardBase card;
	public int number;

	public Piles(CardBase _card,int _number)
	{
		card = _card;
		number = _number;
	}

	public CardBase GetCards()
	{
		if (number > 0)
		{
			number--;
			return null; 
		}
		return null;
	}
}

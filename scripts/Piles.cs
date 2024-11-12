using System.Collections.Generic;
namespace BigCity.scripts;


public class Piles<T> where T : card_base, new()
{
	public int number;

	public Piles(int _number)
	{
		number = _number;
	}

	public card_base GetCards()
	{
		if (number > 0)
		{
			number--;
			return new T(); 
		}
		return null;
	}
}

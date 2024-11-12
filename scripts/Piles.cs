using System.Collections.Generic;
namespace BigCity.scripts;


public class Piles
{
    public card_base cards;
    public int number;
    public List<card_base> pileCards;
    public Piles(card_base _cards,int _number)
    {
        cards = _cards;
        number = _number;
        pileCards = new List<card_base>();
        for (int i = 0; i < _number; i++)
        {
            pileCards.Add(cards);
        }
    }

    public card_base GetCards()
    {
        if (pileCards.Count > 0)
        {
            card_base card = pileCards[0]; 
            pileCards.RemoveAt(0);       
            return card;                   
        }
        return null; 
    }
    
    
    
}
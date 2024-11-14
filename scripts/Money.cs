namespace BigCity.scripts;

public class Money
{
    
    public int money;

    public Money(int _money)
    {
        money = _money;
    }
    
    public void RemoveMoney(int amount)
    {
        if (money - amount < 0)
        {
            money = 0; 
        }
        else
        {
            money -= amount;
        }
    }
	
    public void AddMoney(int amount)
    {
        money += amount;
    }
}
namespace BigCity.scripts.cards;

public partial class RedCard :card_base
{
    protected int gain;
    
    public RedCard(int gain)
    {
        this.gain = gain;
    }
    public override void Activate(Game game, player owner)
    {
        if (owner == game.mainPlayer)
        {
            owner.money.AddMoney(gain);
            game.Enemy.money.RemoveMoney(gain);
        }
        else
        {
            game.Enemy.money.AddMoney(gain);
            owner.money.RemoveMoney(gain);
        }
    }
    
        

}
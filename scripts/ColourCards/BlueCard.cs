namespace BigCity.scripts.cards;

public partial class BlueCard :card_base
{
    protected int gain;
    
    public BlueCard(int gain)
    {
        this.gain = gain;
    }
    public override void Activate(Game game, player owner)
    {
        owner.money.AddMoney(gain);
    }
    
        

}
namespace BigCity.scripts.cards;

public partial class GreenCard :card_base
{
    protected int gain;
    
    public GreenCard(int gain)
    {
        this.gain = gain;
    }
    public override void Activate(Game game, player owner)
    {
        
        owner.money.AddMoney(gain);
    }
    
        

}
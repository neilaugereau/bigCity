using Godot;
using System;

public partial class Effects : Node
{
    public void SimpleGain(object sender, CardActivationEventArgs e)
    {
        ((CardBase)sender).owner.money += ((CardBase)sender).Gain;
    }
    
    public void TypeGain(object sender, CardActivationEventArgs e)
    {
        ((CardBase)sender).owner.money += ((CardBase)sender).Gain * ((CardBase)sender).owner.buildings[((CardBase)sender).CountType].Count;
    }

    public void RedGain(object sender, CardActivationEventArgs e)
    {
        ((CardBase)sender).owner.money += ((CardBase)sender).Gain;
        e.game.players[0].money -= ((CardBase)sender).Gain;
    }

    public void TargetedPlayerGain(object sender, CardActivationEventArgs e)
    {
        ((CardBase)sender).owner.money += ((CardBase)sender).Gain;
        foreach (var elem in e.game.players)
        {
            if (elem != ((CardBase)sender).owner)
                break;
            elem.money -= ((CardBase)sender).Gain;
        }
    }
    
    public void AllPlayerGain(object sender, CardActivationEventArgs e)
    {
        foreach (var elem in e.game.players)
        {
            if (elem != ((CardBase)sender).owner)
            {
                elem.money -= ((CardBase)sender).Gain;
                ((CardBase)sender).owner.money += ((CardBase)sender).Gain;
            }
        }
    }

    public void TradeCards(object sender, CardActivationEventArgs e)
    {
        // J'ai abandonné le trading de carte
        foreach (var elem in e.game.players)
        {
            if (elem != ((CardBase)sender).owner)
            {
                foreach (var card in elem.buildings.Keys)
                {
                    if (card != ECardType.Special)
                    {
                        
                        break;
                    }
                }
                break;
            }
        }
    }
    
    
    
    
    
}

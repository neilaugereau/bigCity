using Godot;
using System;

public partial class Effects : Node
{
    public void SimpleGain(object sender, CardActivationEventArgs e)
    {
        e.game.currentPlayer.money += ((CardBase)sender).Gain;
    }
    
    public void TypeGain(object sender, CardActivationEventArgs e)
    {
        int nbrTypeCards =  e.game.currentPlayer.buildings[((CardBase)sender).CountType].Count;
        for (int i = 0; i < nbrTypeCards; i++)
            e.game.currentPlayer.money += ((CardBase)sender).Gain;
    }

    public void RedGain(object sender, CardActivationEventArgs e)
    {
        e.game.currentPlayer.money += ((CardBase)sender).Gain;
        e.game.opposingPlayer.money -= ((CardBase)sender).Gain;
    }

    public void TargetedPlayerGain(object sender, CardActivationEventArgs e)
    {
        e.game.currentPlayer.money += ((CardBase)sender).Gain;
        foreach (var elem in e.game.allPlayers)
        {
            if (elem != e.game.currentPlayer)
            {
                elem.money -= ((CardBase)sender).Gain;
                break;
            }
        }
    }
    
    public void AllPlayerGain(object sender, CardActivationEventArgs e)
    {
        foreach (var elem in e.game.allPlayers)
        {
            if (elem != e.game.currentPlayer)
            {
                elem.money -= ((CardBase)sender).Gain;
                e.game.currentPlayer.money += ((CardBase)sender).Gain;
            }
        }
    }

    public void TradeCards(object sender, CardActivationEventArgs e)
    {
        // J'ai abandonné le trading de carte
        foreach (var elem in e.game.allPlayers)
        {
            if (elem != e.game.currentPlayer)
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

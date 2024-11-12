using Godot;
using System;

public class player : Node
{
	private List<card_base> buildings;
    
    public player() : base()
    {
        buildings = new List<card_base>();
    }
}

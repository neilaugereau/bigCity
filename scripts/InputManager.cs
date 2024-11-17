using Godot;
using System;

public partial class InputManager : Node2D
{
    const int COLLISION_MASK_CARD = 1;
    const int COLLISION_MASK_DECK = 2;

    CardManager cardManagerReference;
    Variant deckReference;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        cardManagerReference = this.GetNode<CardManager>("../CardManager");
        //deckReference = deckReference;
	}

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.ButtonIndex == MouseButton.Left)
            {
                if (mouseEvent.Pressed)
                {
                    RaycastAtCursor();
                }
                else
                {
                    
                }
            }
        }
    }

    private object RaycastAtCursor()
    {
        var spaceState = GetWorld2D().DirectSpaceState;

        var parameters = new PhysicsPointQueryParameters2D
        {
            Position = GetGlobalMousePosition(),
            CollideWithAreas = true,
            
        };

        var results = spaceState.IntersectPoint(parameters);
        if (results.Count > 0)
        {
            var resultCollisionMask = ((Area2D)results[0]["collider"].Obj).CollisionMask;
            if(resultCollisionMask == COLLISION_MASK_CARD)
            {
                //Card Clicked
                var cardFound = ((Area2D)results[0]["collider"].Obj).GetParent();
                if(cardFound != null)
                {
                    cardManagerReference.StartDrag((Node2D)cardFound);
                }
            }
            else if (resultCollisionMask == COLLISION_MASK_DECK)
            {
                //Deck Clicked

            }
        }
        return null;
    }

}

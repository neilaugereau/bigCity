using Godot;
using Godot.Collections;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class CardManager : Node2D
{
    const int COLLISION_MASK_CARD = 1;
    const int COLLISION_MASK_CARD_SLOT = 2;

    private Node2D _cardBeingDragged;
    private Vector2 _screenSize;
    private bool isHoveringOnCard;
    
    public PlayerHand playerHandReference;

    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;
        playerHandReference = this.GetNode<PlayerHand>("../PlayerHand");
    }

    /*
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.ButtonIndex == MouseButton.Left)
            {
                if (mouseEvent.Pressed)
                {
                    // Detect the card with the mouse
                    var card = RaycastCheckForCard();
                    if (card is Node2D cardNode)
                    {
                        StartDrag(cardNode);
                    }
                }
                else
                {
                    // Dragged the card when the button is Released
                    if (_cardBeingDragged != null)
                    {
                        FinishDrag();
                    }
                }
            }
        }
    }*/

    public void StartDrag(Node2D card)
    {
        _cardBeingDragged = card;
        card.Scale = new Vector2(1,1);
    }

    public void FinishDrag()
    {
        _cardBeingDragged.Scale = new Vector2(1.05f, 1.05f);
        CardSlot cardSlotFounded = RaycastCheckForCardSlot() as CardSlot;
        if (cardSlotFounded != null && !cardSlotFounded.cardInSlot)
        {
            playerHandReference.removeCardFromHand((Card)_cardBeingDragged);
            //The card is dropped in a empty card slot
            _cardBeingDragged.GlobalPosition = cardSlotFounded.GlobalPosition;
            _cardBeingDragged.GetNode<CollisionShape2D>("Area2D/CollisionShape2D").Disabled = true;
            cardSlotFounded.cardInSlot = true;
        }
        else
        {
            playerHandReference.AddCardToHand((Card)_cardBeingDragged);
        }
        _cardBeingDragged = null;
    }

    public void ConnectCardsSignals(Card card)
    {
        GD.Print("Connecting signals...");
        card.Connect("hovered", new Callable(this, "on_hover_over_card"));
        card.Connect("hoveredOff", new Callable(this, "on_hover_off_card"));
    }

    private void on_hover_over_card(Card card)
    {
        if(!isHoveringOnCard)
        {
            isHoveringOnCard = true;
            HighlightCard(card, true);
        }
    }

    private void on_hover_off_card(Card card)
    {
        if (_cardBeingDragged == null)
        {
            HighlightCard(card, false);
            //Check if hovered off card straight to another card
            var newCardHovered = RaycastCheckForCard();
            if (newCardHovered is Card newCard)
            {
                HighlightCard(newCard, true);
            }
            else
            {
                isHoveringOnCard = false;
            }
        }
    }

    private void HighlightCard(Card card, bool hovered)
    {
        if(hovered)
        {
            card.Scale = new Vector2(1.08f, 1.08f);
            card.ZIndex = 2;
        }
        else
        {
            card.Scale = new Vector2(1.0f, 1.0f);
            card.ZIndex = 1;
        }
    }

    private object RaycastCheckForCardSlot()
    {
        var spaceState = GetWorld2D().DirectSpaceState;

        var parameters = new PhysicsPointQueryParameters2D
        {
            Position = GetGlobalMousePosition(),
            CollideWithAreas = true,
            CollisionMask = COLLISION_MASK_CARD_SLOT
        };

        var results = spaceState.IntersectPoint(parameters);
        if (results.Count > 0)
        {
            return ((Area2D)results[0]["collider"].Obj).GetParent();
        }
        return null;
    }

    private object RaycastCheckForCard()
    {
        var spaceState = GetWorld2D().DirectSpaceState;

        var parameters = new PhysicsPointQueryParameters2D
        {
            Position = GetGlobalMousePosition(),
            CollideWithAreas = true,
            CollisionMask = COLLISION_MASK_CARD
        };

        var results = spaceState.IntersectPoint(parameters);
        if (results.Count > 0)
        {
            return GetCardWithHighestZIndex(results);
        }
        return null;
    }

    private object GetCardWithHighestZIndex(Array<Dictionary> cards)
    {
        // Assume the first card in the array is the one with the highest ZIndex.
        Area2D highestZCard = (Area2D)cards[0]["collider"].Obj;

        // Try to get the ZIndex of the parent if it's a Node2D; otherwise, use the card's ZIndex.
        int highestZIndex = highestZCard.GetParent() is Node2D parentNode
                    ? parentNode.ZIndex
                    : highestZCard.ZIndex;

        for (int i = 1; i< cards.Count; i++)
        {
            if (cards[i]["collider"].Obj is Area2D card)
            {
                // Retrieve the ZIndex of the parent if it's a Node2D, otherwise use the card's ZIndex.
                int parentZIndex = card.GetParent() is Node2D cardParent
                   ? cardParent.ZIndex
                   : card.ZIndex;

                if (card.ZIndex > highestZIndex)
                {
                    highestZIndex = card.ZIndex;
                    highestZCard = card;
                }
            }
        }
        return highestZCard.GetParent();
    }



    public override void _Process(double delta)
    {
        if (_cardBeingDragged != null)
        {
            Vector2 mousePos = GetGlobalMousePosition();
            // Update the card position with the mouse position
            _cardBeingDragged.GlobalPosition = new Vector2(Mathf.Clamp(mousePos.X , 0 , _screenSize.X), Mathf.Clamp(mousePos.Y, 0, _screenSize.Y));
        }
    }
}

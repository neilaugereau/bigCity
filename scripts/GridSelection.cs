using Godot;
using System;

public partial class GridSelection : Camera3D
{
	// Called when the node enters the scene tree for the first time.
	
	[Export]
	public PackedScene tiles;
	public override void _Ready()
	{
		
	}
	
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
    
		if(@event.IsPressed() && @event is InputEventMouseButton) 
		{
			
			PhysicsDirectSpaceState3D spaceState = GetWorld3D().DirectSpaceState;
			Vector2 mousePos = GetViewport().GetMousePosition();
			Vector3 rayOrigin = ProjectRayOrigin(mousePos);
			Vector3 rayEnd = rayOrigin + ProjectRayNormal(mousePos) * 200;
			

			var rayQuery = new PhysicsRayQueryParameters3D
			{
				From = rayOrigin,
				To = rayEnd
			};
			
			Godot.Collections.Dictionary intersection = spaceState.IntersectRay(rayQuery);
			if(intersection.ContainsKey("collider"))
			{
				
				GD.Print(intersection);
				var building = tiles.Instantiate();
				GetTree().GetRoot().AddChild(building);
				Vector3 positionToMove = (Vector3)intersection["position"];
				positionToMove[0] = (float)Math.Round(positionToMove[0] / 5) * 5;
				positionToMove[2] = (float)Math.Round(positionToMove[2] / 5) * 5;
				if (building is Node3D buildingNode)
				{
					buildingNode.GlobalTransform = new Transform3D(buildingNode.GlobalTransform.Basis, positionToMove);
				}
				
				
				GD.Print("positionToMove: " + positionToMove);
			}
			
		}  
		else if(!@event.IsPressed() && @event is InputEventMouseButton) 
		{
			// Code pour gérer le relâchement du bouton de la souris (si nécessaire)
		}
	}
	

}

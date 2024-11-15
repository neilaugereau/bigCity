using Godot;
using System;

public partial class GridSelection : Camera3D
{
	[Export]
	public PackedScene tiles;

	public int Spacement = 5;
	public Vector2 PlaneSize = new Vector2(60, 60); // A changer en fonction de la taille
	
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
			Vector3 positionToMove = (Vector3)intersection["position"];
			if (@event.IsPressed() && @event is InputEventMouseButton)
			{
				PlaceTile(positionToMove, 0,Colors.Green);
			}
			/*else if( @event is InputEventMouseMotion)
			{
				PlaceTile(positionToMove, 9,Colors.Black);
			}*/
			
		}
	
		else if(!@event.IsPressed() && @event is InputEventMouseButton) 
		{
			// Code pour gérer le relâchement du bouton de la souris (si nécessaire)
		}
	}

	public void PlaceTile(Vector3 positionToMove,int pos,Color color)
	{
		positionToMove[0] = (float)Math.Round(positionToMove[0] / Spacement) * Spacement;
		positionToMove[1] += pos;
		positionToMove[2] = (float)Math.Round(positionToMove[2] / Spacement) * Spacement;
		Vector2 tilePose = new Vector2(positionToMove[0], positionToMove[2]);
		if (!Globals.gridPositions.ContainsKey(tilePose))
		{
			if (Math.Abs(positionToMove[0]) != Math.Abs(PlaneSize[0] / 2) &&
			    Math.Abs(positionToMove[2]) != Math.Abs(PlaneSize[1] / 2))
			{

				GD.Print($"({(positionToMove[0])} ; {(positionToMove[2])})");
				Globals.gridPositions.Add(tilePose, Globals.E_Buildings.FARM);
				var building = tiles.Instantiate();
				GetTree().GetRoot().AddChild(building);
				if (building is Node3D buildingNode)
				{
					buildingNode.GlobalTransform = new Transform3D(buildingNode.GlobalTransform.Basis, positionToMove);
				}

				if (building is MeshInstance3D buildingMesh)
				{
					var material = buildingMesh.GetSurfaceOverrideMaterial(0)?.Duplicate() as StandardMaterial3D;
					material = new StandardMaterial3D();
					buildingMesh.SetSurfaceOverrideMaterial(0, material);
					material.AlbedoColor = color;
				}
				
				
			}
		}
		else
		{
			//GD.Print("Grid selection could not be instantiated");
		}
	}

}

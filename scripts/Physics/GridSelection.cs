using Godot;
using System;

public partial class GridSelection : Camera3D
{
	[Export]
	public PackedScene tiles;

	public int Spacement = 5;
	public Vector2 PlaneSize = new Vector2(60, 60); // A changer en fonction de la taille
	public Vector2 tilePose;
	
	public Node floatingTile;
	private bool isCtrlPressed = false;
	
	
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event is InputEventKey keyEvent)
		{
			if (keyEvent.Keycode == Key.Ctrl && keyEvent.Pressed && !keyEvent.Echo)
				isCtrlPressed = !isCtrlPressed;
		}
		if (isCtrlPressed)
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
				Vector3 positionToMove = (Vector3)intersection["position"];
				positionToMove[0] = (float)Math.Round(positionToMove[0] / Spacement) * Spacement;
				positionToMove[2] = (float)Math.Round(positionToMove[2] / Spacement) * Spacement;

				tilePose = new Vector2(positionToMove[0], positionToMove[2]);
				if (Math.Abs(positionToMove[0]) != Math.Abs(PlaneSize[0] / 2) &&
					Math.Abs(positionToMove[2]) != Math.Abs(PlaneSize[1] / 2))
				{
					if (@event.IsPressed() && @event is InputEventMouseButton)
					{
						if (!Globals.gridPositions.ContainsKey(tilePose))
							PlaceTile(positionToMove, 0,Colors.Black);
					}
					else if(@event is InputEventMouseMotion)
					{
						if (!Globals.gridPositions.ContainsKey(tilePose))
						{
							TileSelector(positionToMove, 4,Colors.Green);
						}
						else
						{
							TileSelector(positionToMove, 4, Colors.Red);
						}
					
					}
				}
			}
		}
		else
		{
			DestroyTile();
		}
	}

	public void PlaceTile(Vector3 positionToMove,int posY,Color color)
	{
		//GD.Print($"({(positionToMove[0])} ; {(positionToMove[2])})");
		var building = tiles.Instantiate();
		Globals.gridPositions.Add(tilePose, Globals.E_Building.FARM);
		GetTree().GetRoot().AddChild(building);
		
		if (building is Node3D buildingNode)
		{
			positionToMove[1] += posY;
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

	public void TileSelector(Vector3 positionToMove,int posY,Color color)
	{

		if (floatingTile == null)
		{
			floatingTile = tiles.Instantiate();
			GetTree().GetRoot().AddChild(floatingTile);
			
		}
		
		if (floatingTile is Node3D floatingTileNode)
		{
			positionToMove[1] = posY;
			floatingTileNode.GlobalTransform = new Transform3D(floatingTileNode.GlobalTransform.Basis, positionToMove);
		}
		if (floatingTile is MeshInstance3D buildingMesh)
		{
			var material = buildingMesh.GetSurfaceOverrideMaterial(0)?.Duplicate() as StandardMaterial3D;
			material = new StandardMaterial3D();
			buildingMesh.SetSurfaceOverrideMaterial(0, material);
			material.AlbedoColor = color;
		}
	}

	public void DestroyTile()
	{
		if (floatingTile != null)
		{
			floatingTile.QueueFree();
			floatingTile = null;  
		}
		
	}
}

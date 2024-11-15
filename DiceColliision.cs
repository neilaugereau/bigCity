using Godot;
using System;
using System.Timers;

public partial class DiceColliision : RigidBody3D
{
	private  Vector3[] facesRotation = new Vector3[] {
		new Vector3(0, 0, 0),     
		new Vector3(0, 0, 180),    
		new Vector3(0, 0, 90),     
		new Vector3(0, 0, -90),   
		new Vector3(90, 0, 0),     
		new Vector3(-90, 0, 0)     
	};
	
	public float accumulatedTime = 0.0f;

	private System.Timers.Timer aTimer;

	public override void _Ready()
	{
		this.LinearVelocity = new Vector3(0, 5f, -5f);;
		this.AngularVelocity = new Vector3(0, 0f, 5f);
		this.ConstantForce = new Vector3(0, 0f, 0f);


	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		accumulatedTime += (float)delta;
		if (accumulatedTime >= 2f)
		{
			
			GD.Print(this.RotationDegrees);
			accumulatedTime = 0.0f;
			GD.Print($"La valeur de dé est {Throw(this.RotationDegrees)}");
			
		}
		
	}

	public int Throw(Vector3 rotation)
	{
		float roundedRotation0 = (float)Math.Round(rotation[0] / 10) * 10;
		float roundedRotation2 = (float)Math.Round(rotation[2] / 10) * 10;
		
		for (int i = 1; i < facesRotation.Length+1; i++)
		{
			if (roundedRotation0==facesRotation[i][0] && roundedRotation2==facesRotation[i][1])
			{

				return i;
			}
		}
		return 0;
	}
}

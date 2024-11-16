using Godot;
using System;
using System.Timers;

public partial class DiceColliision : RigidBody3D
{
	// Array de Vector3 permettant d'assigner une valeur(index) aux 6 faces en fonction des rotatiions prédéfinies 
	private  Vector3[] facesRotations = new Vector3[] {
		new Vector3(0, 0, 0),     
		new Vector3(0, 0, -180),    
		new Vector3(0, 0, 90),     
		new Vector3(0, 0, -90),   
		new Vector3(0, 0, -180),     
		new Vector3(-90, 0, 0)     
	};
	
	private float accumulatedTime = 0.0f; //  Temps utilisé en tant que timer
	Random rand  = new Random();
	private System.Timers.Timer aTimer;

	public override void _Ready() // Mise en place des caractéristiques du lancer (vitesse,orientation,puissance)
	{
		
		this.LinearVelocity = new Vector3(0, (float)rand.NextDouble() + (float)rand.Next(0,5), -(float)rand.NextDouble() - (float)rand.Next(0,5));;
		this.AngularVelocity = new Vector3(0, 0f, (float)rand.NextDouble() + (float)rand.Next(0,5));
		this.ConstantForce = new Vector3(0, 0f, 0f);
		
	}

	public override void _Process(double delta)
	{
		accumulatedTime += (float)delta; // Timer qui se rafraichit toutes les 2 secondes 
		if (accumulatedTime >= 2f)
		{
			if (new Vector3((int)this.AngularVelocity[0], (int)this.AngularVelocity[1], (int)this.AngularVelocity[2]) ==
			    Vector3.Zero)
				GD.Print($"{Throw()}");
			accumulatedTime = 0.0f;
		}
	}

	public int Throw()
	{
		int roundedRotation0 = (int)Math.Round(RotationDegrees.X / 10) * 10; // Arrondit la rotation
		int roundedRotation2 = (int)Math.Round(RotationDegrees.Z / 10) * 10;
		int roundedRotation1 = (int)Math.Round(RotationDegrees.Y / 10) * 10;
		for (int i = 0; i < facesRotations.Length; i++)
		{
			GD.Print(new Vector3(roundedRotation0,roundedRotation1,roundedRotation2));
			if (roundedRotation0==facesRotations[i][0] && roundedRotation2==facesRotations[i][2])
			{
				return i+1;
			}
		}
		return 0;
	}
}

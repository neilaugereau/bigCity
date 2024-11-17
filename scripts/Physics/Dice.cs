using Godot;
using System;
using System.Timers;

public partial class Dice : RigidBody3D
{
	// Array de Vector3 permettant d'assigner une valeur(index) aux 6 faces en fonction des rotatiions prédéfinies 
	[Export] private Color color = new Color(1, 1, 1);

	private Vector3[] facesRotations;
	private float accumulatedTime = 0.0f; //  Temps utilisé en tant que timer
	Random rand  = new Random();
	private System.Timers.Timer aTimer;
	
	public bool HasLanded = false;
	public event EventHandler Landed;

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
			{
				HasLanded = true;
				Landed?.Invoke(this, null);
				SetProcess(false);
			}
			accumulatedTime = 0.0f;
		}
	}

	public int GetDiceValue()
	{
		Basis basis = this.GlobalTransform.Basis;
		facesRotations = new Vector3[] {
			-basis.Y,
			-basis.X,
			-basis.Z,
			basis.Z,
			basis.X,
			basis.Y,
		};

		Vector3 vectorup = new Vector3(0, 1, 0);
		
		Vector3 closestVector = Vector3.Zero;
		float maxSimilarity = float.NegativeInfinity;
		int index = 0;
		
		for (int i = 0; i < facesRotations.Length; i++)
		{
			Vector3 normalizedVec = facesRotations[i].Normalized();
			float similarity = normalizedVec.Dot(vectorup);

			if (similarity > maxSimilarity)
			{
				maxSimilarity = similarity;
				closestVector = facesRotations[i];
				index = i+1;
				
			}
		}
		
		return index;
		
	}
}

using Godot;
using System;

public partial class CameraMovement : Camera3D
{
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey key)
		{
			Vector3 moveDirection = Vector3.Zero;
			Vector3 forward = -GlobalTransform.Basis.Z;
			Vector3 right = GlobalTransform.Basis.X;

			forward.Y = 0;
			right.Y = 0;

			if (Input.IsActionPressed("move_forward")) moveDirection += forward;
			if (Input.IsActionPressed("move_left")) moveDirection -= right;
			if (Input.IsActionPressed("move_backward")) moveDirection -= forward;
			if (Input.IsActionPressed("move_right")) moveDirection += right;
			this.Position += moveDirection.Normalized() * 5.0f;
			this.Position = new Vector3(Mathf.Clamp(this.Position.X, -140, 140), this.Position.Y, Mathf.Clamp(this.Position.Z, -140, 140));
		}
	}
}

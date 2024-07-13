using Godot;
using System;

public partial class Player2D : CharacterBody2D
{
	public Vector2 SmoothedMousePos;

	[Signal]
	public delegate void HitEventHandler();

	[Export]
	public int Speed { get; set; } = 400;

	public Dash Dash;
	public int DashSpeed = 4000;
	public float DashDuration = 0.3f;

	public Vector2 ScreenSize; // Size of the game window.

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		Dash = GetNode<Dash>("Dash");
	}

	private Vector2 GetMoveDirection()
	{
		return new Vector2(
				Convert.ToInt32(Input.IsActionPressed("move_right")) - Convert.ToInt32(Input.IsActionPressed("move_left")),
				Convert.ToInt32(Input.IsActionPressed("move_backward")) - Convert.ToInt32(Input.IsActionPressed("move_forward"))
			);
	}


	private Vector2 ComputeBaseMovement()
	{

		Vector2 moveDirection = GetMoveDirection();
		return moveDirection.Normalized() * (float)Speed;

	}

	private Vector2 ComputeDashMovement()
	{
		if (Input.IsActionJustPressed("space") && !Dash.IsDashing())
		{
			Dash.StartDash(DashDuration);
			return GetMoveDirection().Normalized() * (float)DashSpeed;
		}
		return new Vector2(0, 0);
	}

	private void ComputeRotation()
	{
		SmoothedMousePos = SmoothedMousePos.Lerp(GetGlobalMousePosition(), 0.3f);
		LookAt(SmoothedMousePos);
	}

	public override void _Process(double delta)
	{
		ComputeRotation();
		Velocity = ComputeBaseMovement();
		Velocity += ComputeDashMovement();
		MoveAndSlide();
	}

	private void OnBodyEntered(Node2D body)
	{

		EmitSignal(SignalName.Hit);
		// Must be deferred as we can"t change physics properties on a physics callback.
		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
	}

}

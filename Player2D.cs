using Godot;
using System;

public partial class Player2D : Area2D
{
	[Export]
	public int Speed = 400; // How fast the player will move (pixels/sec).

	public Vector2 ScreenSize; // Size of the game window.

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("move_backward"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("move_forward"))
		{
			velocity.Y -= 1;
		}

		var player = this;

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;

		}

	}

	public override void _Draw()
	{
		DrawRect(new Rect2(0.0f, 0.0f, 100.0f, 100.0f), Colors.Green, true);
	}


}

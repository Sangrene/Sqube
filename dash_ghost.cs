using Godot;
using System;

public partial class dash_ghost : ColorRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Tween tween = CreateTween().SetTrans(Tween.TransitionType.Sine);
		tween.TweenProperty(this.Material, "shader_parameter/u_alpha", 0.0, 0.5).From(0.7);
		tween.TweenCallback(Callable.From(this.QueueFree));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

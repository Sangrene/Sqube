using Godot;
using System;

public partial class Dash : Node2D
{
	private Timer DashTimer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		DashTimer = GetNode<Timer>("DashTimer");
	}

	public void StartDash(float duration){
		DashTimer.WaitTime = duration;
		DashTimer.Start();
	}

	public bool IsDashing(){
		return !DashTimer.IsStopped();
	}
}

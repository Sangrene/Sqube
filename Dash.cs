using Godot;
using System;

public partial class Dash : Node2D
{
	private readonly PackedScene GhostScene = ResourceLoader.Load<PackedScene>("res://dash_ghost.tscn");
	private Timer DashTimer;
	private Timer GhostTimer;

	private Player2D Player;
	private ColorRect PlayerRect;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		DashTimer = GetNode<Timer>("DashTimer");
		GhostTimer = GetNode<Timer>("GhostTimer");
	}

	public void InstanceGhost(){
		ColorRect ghost = (ColorRect)GhostScene.Instantiate();
		GetParent().GetParent().AddChild(ghost);

		ghost.Position = Player.Position;
		ghost.Scale = Player.Scale;
		ghost.Rotation = Player.Rotation;
		
	}

	public void StartDash(float duration, Player2D player, ColorRect playerRect){
		this.PlayerRect = playerRect;
		this.Player = player;
		DashTimer.WaitTime = duration;
		DashTimer.Start();
		GhostTimer.Start();
		//InstanceGhost();
	}

	public void EndDash(){
		GhostTimer.Stop();
	}

	public bool IsDashing(){
		return !DashTimer.IsStopped();
	}

	private void OnTimerTimeout()
	{
		InstanceGhost();
	}

	private void OnDashTimerTimeout(){
		EndDash();
	}

}



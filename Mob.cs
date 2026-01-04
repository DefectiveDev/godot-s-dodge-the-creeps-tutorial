using Godot;
using System;

public partial class Mob : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	    var animatedSprited2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	    string[] mobTypes = animatedSprited2D.SpriteFrames.GetAnimationNames();
	    animatedSprited2D.Play(mobTypes[GD.Randi() % mobTypes.Length]);
	}

	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
	    QueueFree();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

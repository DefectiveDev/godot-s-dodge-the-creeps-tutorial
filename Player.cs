using Godot;
using System;

public partial class Player : Area2D
{
    [Export]
    public int Speed = 400;

    public Vector2 ScreenSize;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	    ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	    var velocity = Vector2.Zero;

        //Tutorial creates bug here that will increase the speed if you are holding corner directions
        //x and y should be normalised
	    if (Input.IsActionPressed("move_right"))
	    {
	        velocity.X += 1;
	    }
	    if (Input.IsActionPressed("move_left"))
	    {
	        velocity.X -= 1;
	    }
	    if (Input.IsActionPressed("move_down"))
	    {
	        velocity.Y += 1;
	    }
	    if (Input.IsActionPressed("move_up"))
	    {
	        velocity.Y -= 1;
	    }

	    var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D"); //Could use signals to reduce error potential

	    if (velocity.Length() > 0)
	    {
	        //Tutorial fixes speed bug here
	        velocity = velocity.Normalized() * Speed;
	        animatedSprite2D.Play();
	    }
        else
        {
            animatedSprite2D.Stop();
        }

        Position += velocity * (float)delta; //delta is the time between frames. this will enable consistencey across devices
        Position = new Vector2(
                    x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
                    y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
                );
	}
}

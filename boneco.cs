using Godot;
using System;

public class boneco : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    private Vector2 velocity = new Vector2();
    private int speed = 300;
 // Called every frame. 'delta' is the elapsed time since the previous frame.
    public void GetInput()
    {
        velocity = new Vector2();

        if (Input.IsActionPressed("direita"))
            velocity.x += 1;

        if (Input.IsActionPressed("esquerda"))
            velocity.x -= 1;

        if (Input.IsActionPressed("baixo"))
            velocity.y += 1;

        if (Input.IsActionPressed("cima"))
            velocity.y -= 1;

        velocity = velocity.Normalized() * speed;
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        velocity = MoveAndSlide(velocity);
    }
}

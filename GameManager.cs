using Godot;
using System;

public class GameManager : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        KinematicBody2D player = GetNode<KinematicBody2D>("Player");
        Position2D spawn = GetNode<Position2D>("p1");
        player.Position = spawn.Position;
    }

 // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {
     if(Input.IsActionJustPressed("up")){
        KinematicBody2D player = GetNode<KinematicBody2D>("Player");
        Position2D spawn = GetNode<Position2D>("p2");
        player.Position = spawn.Position;
     }
 }
}

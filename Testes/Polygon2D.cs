using Godot;
using System;

public class Polygon2D : Godot.Polygon2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        n2 = 360/n;
        n2 = Mathf.Deg2Rad((float)n2);
     for(i=0; i<n;i++){
        x =  Math.Sin(n2*i);
        y = (Math.Cos(n2*i))*-1;
        GD.Print("x: " + x.ToString() + " y: " + y.ToString());
     }
    }
    
    private double x,y,n = 3, n2, n3,i;
 // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {
     
 }
}

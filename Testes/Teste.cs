using Godot;
using System;

public class Teste : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _Draw();
    }
    private double n,n2 =12 ,x,y;
    private int i;
    public override void _Draw()
    {

       /* Vector2[] points = {
            new Vector2(-1,-1),
            new Vector2(1,-1),
            new Vector2(1,0.5f),
            new Vector2(-1,0.5f)
        };*/
        var points = new System.Collections.Generic.List<Vector2>();
        var color = new System.Collections.Generic.List<Color>();
        n = 360/n2;
        n = Mathf.Deg2Rad((float)n);
        for(i=0; i<n2;i++){
            x =  Math.Sin(n*i);
            y = (Math.Cos(n*i))*-1;
            points.Add(new Vector2((float)x,(float)y));
            color.Add(new Color(0,0,0));

        }
        DrawPolygon(points.ToArray(), color.ToArray() );
        
        
        
        
    }
    

}

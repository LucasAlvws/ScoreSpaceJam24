using Godot;
using System;

public class player : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    double n, n2=8, i,x,y;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Polygon2D linha = new Polygon2D();
        
        linha.Polygon = devolve_vetor(n2);
        linha.Color = new Color(0,0,0);
        linha.Antialiased = true;
        
        AddChild(linha);
    }

    private Vector2[] devolve_vetor(double n2)
    {
        var points = new System.Collections.Generic.List<Vector2>();
        n = 360/n2;
        n = Mathf.Deg2Rad((float)n);
        for(i=0; i<n2;i++){
            x =  Math.Sin(n*i);
            y = (Math.Cos(n*i))*-1;
            points.Add(new Vector2((float)x,(float)y));
        }
        return points.ToArray();
    }

    private Color[] devolve_color(double n2)
    {
        var color = new System.Collections.Generic.List<Color>();
        n = 360/n2;
        n = Mathf.Deg2Rad((float)n);
        for(i=0; i<n2;i++){
            x =  Math.Sin(n*i);
            y = (Math.Cos(n*i))*-1;
            color.Add(new Color(0,0,0));
        }
        return color.ToArray();
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

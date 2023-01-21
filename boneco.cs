using Godot;
using System;

public class boneco : KinematicBody2D
{
    
    private Vector2 velocity = new Vector2();
    private int speed = 300;
    private double n, n2 = 4, x, y;
    private int i;
    private Godot.CollisionPolygon2D col;
    public override void _Ready()
    {
        _Draw();
    
        
        
    }
    
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
        setar_colisao();
        
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
    
    public override void _Draw()
    {
        DrawPolygon(devolve_vetor(n2), devolve_color(n2));
    }
    private void setar_colisao(){
        col = GetNode<Godot.CollisionPolygon2D>("colisao");
        col.Polygon = devolve_vetor(n2);
    }    
}

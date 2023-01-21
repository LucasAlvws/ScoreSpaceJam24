using Godot;
using System;

public class boneco : KinematicBody2D
{
    [Export]
    public int n2 = 4;
    private Vector2 velocity = new Vector2();
    private int speed = 250;
    private double n, x, y;
    private int i;
    private Godot.CollisionPolygon2D col;
    public override void _Ready()
    {
        _Draw();
    }
    
    public void GetInput()
    {
        velocity = new Vector2();

        if (Input.IsActionPressed("d"))
            velocity.x = Mathf.Lerp(velocity.x, speed, 0.1f);

        if (Input.IsActionPressed("a"))
            velocity.x = Mathf.Lerp(velocity.x, -speed, 0.1f);

        if (Input.IsActionPressed("s"))
            velocity.y += Mathf.Lerp(velocity.y, speed, 0.1f);

        if (Input.IsActionPressed("w"))
            velocity.y += Mathf.Lerp(velocity.y, -speed, 0.1f);

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
        DrawPolygon(devolve_vetor(n2), devolve_color(n2), antialiased:true);
        /*Polygon2D linha = new Polygon2D();
        Vector2[] linhas = {
            devolve_vetor(n2)[0],
            devolve_vetor(n2)[1]
        };
        linha.Polygon = linhas;
        linha.Color = new Color(50,50,50);
        AddChild(linha);*/

        /*DrawLine(devolve_vetor(n2)[0],devolve_vetor(n2)[1], new Color(50,50,50),width:4);*/
    }
    private void setar_colisao(){
        col = GetNode<Godot.CollisionPolygon2D>("colisao");
        col.Polygon = devolve_vetor(n2);
    }    
}

using Godot;
using System;

public class PlayerBody : KinematicBody2D
{
    [Export]
    public int n2 = 4;
    private Vector2 velocity = new Vector2();
    private int speed = 200, i;
    private double n, x, y;
    private Godot.CollisionPolygon2D col;

    //rotation
    public int speedR = 125;
    public float rotationSpeed = 2;
    public Vector2 velocityR = new Vector2();
    public int rotationDir = 0;



    public override void _Ready()
    {
        
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


        rotationDir = 0;
        velocityR = new Vector2();

        if (Input.IsActionPressed("right"))
            rotationDir += 1;

        if (Input.IsActionPressed("left"))
            rotationDir -= 1;

        if (Input.IsActionPressed("down"))
            velocityR = new Vector2(-speedR, 0).Rotated(Rotation);

        if (Input.IsActionPressed("up"))
            velocityR = new Vector2(speedR, 0).Rotated(Rotation);

        velocityR = velocity.Normalized() * speed;


        if (Input.IsActionPressed("espaco")){
            add_sides();
        }

    }
    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        
        Rotation += rotationDir * rotationSpeed * delta;
        velocity = MoveAndSlide(velocity);
        velocity = MoveAndSlide(velocity);
        
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
    
    private void setar_colisao(string node){
        if(node.Equals("player")){
            col = GetNode<Godot.CollisionPolygon2D>("colisao_player");
            col.Polygon = devolve_vetor(n2);
        }else if(node.Equals("escudo")){
            col = GetNode<Godot.CollisionPolygon2D>("colisao_escudo");
            col.Polygon = devolve_vetor(n2);
            col.Position = new Vector2(0.1f,0.1f);
        }
        
    }

    private void setar_player(){
        Godot.Node2D player = GetNode<Godot.Node2D>("player");
        Polygon2D playerBody = new Polygon2D();
        playerBody.Polygon = devolve_vetor(n2);
        playerBody.Color = new Color(0,0,0);
        playerBody.Antialiased = true;
        AddChild(playerBody);
        setar_colisao("player");
        
    }

    private void setar_escudo(){
        Godot.Node2D escudo = GetNode<Godot.Node2D>("escudo");
        Polygon2D escudoBody = new Polygon2D();
        escudoBody.Polygon = devolve_vetor(n2);
        escudoBody.Color = new Color(50,50,50);
        escudoBody.Antialiased = true;
        escudoBody.GlobalPosition = new Vector2(0.1f,0.1f);
        escudoBody.Name = "escudoBody";
        AddChild(escudoBody);
        setar_colisao("escudo");
    }

    private void add_sides(){
        Godot.Node2D escudo = GetNode<Godot.Node2D>("escudo");
        Godot.Polygon2D escudoBody = escudo.GetNode<Godot.Polygon2D>("escudoBody");
    }
}

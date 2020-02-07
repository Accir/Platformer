using Godot;
using System;

public class Character : KinematicBody2D
{

    [Export] public int jumpValue = -300;
    [Export] public int gravityValue = 13;
    [Export] public int maxSpeed = 125;
    [Export] public int acceleration = 25;
    public Vector2 motion = new Vector2();
    private Vector2 UP = new Vector2(0, -1);
    private bool jumped = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public void GetInput()
    {
        AnimatedSprite node = (AnimatedSprite)GetNode("Animation");
        motion.y += gravityValue;

        if (Input.IsActionPressed("left"))
        {
            motion.x -= acceleration;
            motion.x = Math.Max(-maxSpeed, motion.x);

            node.FlipH = true;
            node.Play("RunRight");

        }
        else if (Input.IsActionPressed("right"))
        {
            motion.x += acceleration;
            motion.x = Math.Min(maxSpeed, motion.x);

            node.FlipH = false;
            node.Play("RunRight");
        }
        else
        {
            //lerp firstFloat + (secondFloat - firstFloat) * by
            motion.x = motion.x + (0f - motion.x) * 0.3f;
            node.Play("Idle");
        }

        if (IsOnFloor())
        {
            //System.Console.WriteLine("landed");
            //jumped = false;
            if (Input.IsActionJustPressed("jump"))
            {
                // System.Console.WriteLine("jumped");
                //jumped = true;
                motion.y = jumpValue;
            }
        }
        // else if (jumped)
        // {
        //     System.Console.WriteLine("air");
        //     node.Play("Jump");
        // }
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        motion = MoveAndSlide(motion, UP, true);
    }
}

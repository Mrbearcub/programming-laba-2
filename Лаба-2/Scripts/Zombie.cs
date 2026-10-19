using Godot;
using System;

[GlobalClass]
public partial class Zombie : GroundEnemy
{
    [Export] 
    private float HorizontalSpeed = 150f;
    [Export] 
    private float DashInterval = 3.5f;
    
    private float time = 0f;

	/// <summary>
	/// Обновляет положение объекта с учётом времени кадра.
	/// </summary>
	protected override void Move(float delta)
    {
        time += delta;
        Vector2 movement = new Vector2(0, 0);
        movement.X = -HorizontalSpeed * (Mathf.Cos(time * DashInterval)+1.3f);
        Position += movement * delta;
    }
}

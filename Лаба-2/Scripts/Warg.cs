using Godot;
using System;

public partial class Warg : GroundEnemy
{
	[Export] 
	private float ChaseSpeed = 250f;
    [Export] 
	private float DetectionRange = 600f;
	[Export]
	private float HorizontalSpeed = 100f;

    /// <summary>
    /// Обновляет положение объекта с учётом времени кадра.
    /// </summary>
    protected override void Move(float delta)
    {
		Vector2 movement = new Vector2(0, 0);
        

        var player = GetTree().GetFirstNodeInGroup("player") as Node2D;
        if (player != null && GlobalPosition.DistanceTo(player.GlobalPosition) <= DetectionRange)
        {
            Vector2 direction = (player.GlobalPosition - GlobalPosition).Normalized();
			
            movement.X = ChaseSpeed * direction.X;
        }
        else
			movement.X = -HorizontalSpeed;
		Position += movement * delta;
    }
}

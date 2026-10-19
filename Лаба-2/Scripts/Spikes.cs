using Godot;
using System;

public partial class Spikes : GroundObstacle
{
	 [Export]
    private float VerticalSpeed = 100f;

    [Export]
    private float HorizontalSpeed = 100f;

    private float time = 0f;

	/// <summary>
	/// Обновляет положение объекта с учётом времени кадра.
	/// </summary>
	protected override void Move(float delta)
    {
        time += delta;
        Vector2 movement = new Vector2(-HorizontalSpeed, 0);
        movement.Y = Mathf.Sin(time * 3f) * VerticalSpeed;
        Position += movement * delta;
    }
}

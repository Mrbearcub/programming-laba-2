using Godot;
using System;

public partial class VerticalPlatform : Platform
{
	[Export]
	private float HorizontalSpeed = 100f;

	/// <summary>
	/// Обновляет положение объекта с учётом времени кадра.
	/// </summary>
	protected override void Move(float delta)
    {
        Vector2 movement = new Vector2(0, 0);
        movement.X = -HorizontalSpeed;
        Position += movement * delta;
    }
}

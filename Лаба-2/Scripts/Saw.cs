using Godot;
using System;
using System.ComponentModel.Design;

using Godot;

public partial class Saw : FlyingObstacle
{
    public enum MovementType
    {
        Straight,
        Sine
    }

    private MovementType MovementMode;

    [Export]
    private float VerticalSpeed = 100f;

    [Export]
    private float HorizontalSpeed = 100f;

    private float time = 0f;

    /// <summary>
    /// Инициализирует объект и необходимые связи при добавлении на сцену.
    /// </summary>
    public override void _Ready()
    {
        base._Ready();

        MovementMode = (MovementType)GD.RandRange(0, 1);
    }

    /// <summary>
    /// Обновляет положение объекта с учётом времени кадра.
    /// </summary>
    protected override void Move(float delta)
    {
        time += delta;

        Vector2 movement = new Vector2(-HorizontalSpeed, 0);

        if (MovementMode == MovementType.Sine)
        {
            movement.Y = Mathf.Sin(time * 3f) * VerticalSpeed;
        }

        Position += movement * delta;
    }
}


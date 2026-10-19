using Godot;
using System;

[GlobalClass]
public partial class Bat : FlyingEnemy //Класс летучей мыши - тип врага
{


    [Export]
    private float VerticalSpeed = 100f;

    private float time;


    /// <summary>
    /// Обновляет положение объекта с учётом времени кадра.
    /// </summary>
    protected override void Move(float delta) //Меняем движение, чтобы было по синусоиде
    {
        time += (float)GetProcessDeltaTime();

        Vector2 movement = new Vector2(
            -100f,
            Mathf.Sin(time * 3) * VerticalSpeed
        );

        Position += movement * (float)GetProcessDeltaTime();
    }
}

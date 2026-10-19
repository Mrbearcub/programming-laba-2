using Godot;
using Godot.Collections;
using System;

public partial class player : CharacterBody2D
{
    [Export]
    private float MovementSpeed = 300f;
    [Export]
    private float Gravity = 900f;
    [Export]
    private float JumpVelocity { get; set; } = -800f;
    private float ReloadTime { get; set; } = 1f;

    private Vector2 _velocity;
    /// <summary>
    /// Обновляет физическое состояние объекта каждый физический кадр.
    /// </summary>
    public override void _PhysicsProcess(double delta) //Вводим гравитацию и высоту прыжка
    {
        Vector2 _velocity = Velocity;

        float direction = Input.GetAxis("left", "right");

        _velocity.X = direction * MovementSpeed;
        if (!IsOnFloor())
        {
            _velocity.Y += Gravity * (float)delta;
        }
        if (IsOnFloor() && Input.IsActionJustPressed("jump"))
        {
            _velocity = Jump(_velocity);
        }
        Velocity = _velocity;
        MoveAndSlide();
    }

    /// <summary>
    /// Возвращает вектор скорости для прыжка.
    /// </summary>
    private Vector2 Jump(Vector2 Velocity) //Функция прыжка
    {
        return new Vector2(0, JumpVelocity);
    }

    [Export]
    private float BulletSpeed = 600f;
    [Export]
    private float BulletDamage = 10f;

    /// <summary>
    /// Обрабатывает действия игрока с клавиатуры или мыши.
    /// </summary>
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("shoot"))
        {
            Shoot();
        }
    }
    private PackedScene BulletScene = GD.Load<PackedScene>("res://Scenes/bullet.tscn");
    /// <summary>
    /// Создаёт снаряд и задаёт его начальную позицию и скорость.
    /// </summary>
    private void Shoot() //Функция стрельбы, создаем пулю на растоянии 50 от игрока по X, задаем ей скорость
    {
        //GD.Print("Shooting");
        bullet bullet = (bullet)BulletScene.Instantiate();
        AddSibling(bullet);
        bullet.Position = Position + new Vector2(50, 0);
        bullet.Velocity = new Vector2(BulletSpeed, 0);
        bullet.SetDamage(BulletDamage);

    }

    /// <summary>
    /// Обрабатывает получение урона и проверяет необходимость уничтожения.
    /// </summary>
    public void TakeDamage()
    {
        Die();
    }

    /// <summary>
    /// Обрабатывает контакт с областью другого объекта.
    /// </summary>
    private void _On_Collision(Area2D area) //Смерть игрока, если в него вошел объект-дамагер
    {
        if (area is DamagingObject)
        {
            GD.Print("Player hit");
            Die();
        }
    }

    /// <summary>
    /// Обрабатывает смерть объекта.
    /// </summary>
    private void Die() //Смерть игрока, если в него вошел объект-дамагер
    {
        GetTree().Quit();
    }
}

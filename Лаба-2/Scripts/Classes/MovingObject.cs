using Godot;
using System;

public partial class MovingObject : Area2D
{
    [Export]
    protected Vector2 velocity = new Vector2(-300f, 0);

    /// <summary>
    /// Обновляет физическое состояние объекта каждый физический кадр.
    /// </summary>
    public override void _PhysicsProcess(double delta)
    {
        Move((float)delta);
    }

    /// <summary>
    /// Обновляет положение объекта с учётом времени кадра.
    /// </summary>
    protected virtual void Move(float delta) //Функция движения, подгоняем под частоту кадров
    {
        Position += velocity * delta;
    }

    /// <summary>
    /// Вычисляет позицию появления объекта на игровом поле.
    /// </summary>
    public virtual Vector2 GetSpawnPosition() //Вводим функцию спавна для будущего переопределения
    {
        return GlobalPosition;
    }

    /// <summary>
    /// Инициализирует объект и необходимые связи при добавлении на сцену.
    /// </summary>
    public override void _Ready()
    {
        VisibleOnScreenNotifier2D notifier = new VisibleOnScreenNotifier2D();
        AddChild(notifier);

    }

    /// <summary>
    /// Обрабатывает выход объекта за пределы видимой области.
    /// </summary>
    private async void _On_Sreen_Exited() //Т.к. враги спавнятся за экраном, уничтожаем их только после определенного времени
    {
        Timer timer = new Timer();
        timer.WaitTime = 1f;
        timer.OneShot = true;
        AddChild(timer);
        timer.Start();
        await ToSignal(timer, "timeout");
        GD.Print($"{Name} has exited the scene.");
        QueueFree();
    }
}

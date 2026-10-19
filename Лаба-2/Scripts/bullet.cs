using Godot;
using System;

public partial class bullet : CharacterBody2D //Класс пули
{
    private float Damage = 10f;

    /// <summary>
    /// Обновляет физическое состояние объекта каждый физический кадр.
    /// </summary>
    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    /// <summary>
    /// Обрабатывает контакт с областью другого объекта.
    /// </summary>
    private void _On_Collision(Area2D area) //Пуля или бьет врага или уничтожается об объекты
    {
        GD.Print("Bullet vollide with" + area.Name);
        if (area is Enemy)
        {
            GD.Print("Bullet hit an enemy!");
            Enemy enemy = (Enemy)area;
            enemy.TakeDamage(Damage);
            QueueFree();
        }
        if (area is Obstacle || area is Platform)
        {
            GD.Print("Bullet was destroyed!");
            QueueFree();
        }
    }

    /// <summary>
    /// Удаляет снаряд после выхода за пределы экрана.
    /// </summary>
    private void _On_Screen_Leave() //Исчезновение пули за экраном
    {
        //GD.Print("ENd");
        QueueFree();
    }

    /// <summary>
    /// Устанавливает урон снаряда.
    /// </summary>
    public void SetDamage(float damage)
    {
        Damage = damage;
    }
}

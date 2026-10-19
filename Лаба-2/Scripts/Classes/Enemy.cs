using Godot;
using System;

[GlobalClass]
public partial class Enemy : DamagingObject //Класс врага
{
    [Export]
    protected float Health;

    

    /// <summary>
    /// Обрабатывает получение урона и проверяет необходимость уничтожения.
    /// </summary>
    public void TakeDamage(float damage) //Возможность получения урона
    {
        Health -= damage;
        GD.Print($"{Name} took {damage} damage, has {Health} health");
        if (Health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Обрабатывает смерть объекта.
    /// </summary>
    private void Die() //Возможность умереть
    {
        GD.Print($"{Name} died");
        QueueFree();
    }
}

using Godot;
using System;

public partial class EnemyBullet : CharacterBody2D
{
    /// <summary>
    /// Инициализирует объект и необходимые связи при добавлении на сцену.
    /// </summary>
    public override void _Ready()
    {
        GetNode<Area2D>("Area2D").BodyEntered += OnBodyEntered;
    }

    /// <summary>
    /// Обновляет физическое состояние объекта каждый физический кадр.
    /// </summary>
    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
        for (int i = 0; i < GetSlideCollisionCount(); i++)
        {
            var collider = GetSlideCollision(i).GetCollider();
            if (collider is player target)
            {
                target.TakeDamage();
                QueueFree();
                return;
            }
            if (collider is StaticBody2D || collider is Obstacle || collider is Platform)
            {
                QueueFree();
                return;
            }
        }
    }

    /// <summary>
    /// Обрабатывает столкновение с физическим телом.
    /// </summary>
    private void OnBodyEntered(Node2D body)
    {
        if (body is player target)
        {
            target.TakeDamage();
            QueueFree();
        }
        else if (body is StaticBody2D || body is Obstacle || body is Platform)
        {
            QueueFree();
        }
    }

    /// <summary>
    /// Обрабатывает контакт с областью другого объекта.
    /// </summary>
    private void _On_Collision(Area2D area)
    {
        if (area.GetParent() is player target)
        {
            target.TakeDamage();
            QueueFree();
        }
    }

    /// <summary>
    /// Удаляет снаряд после выхода за пределы экрана.
    /// </summary>
    private void _On_Screen_Leave() => QueueFree();
}

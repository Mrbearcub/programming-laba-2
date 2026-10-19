using Godot;
using System;

public partial class Dragon : FlyingEnemy
{
    [Export] private float HorizontalSpeed = 100f;
    [Export] private float BulletSpeed = 600f;
    [Export] private float ShootInterval = 2f;

    private readonly PackedScene bulletScene = GD.Load<PackedScene>("res://Scenes/enemy bullet.tscn");
    private float shootCooldown;

    /// <summary>
    /// Инициализирует объект и необходимые связи при добавлении на сцену.
    /// </summary>
    public override void _Ready()
    {
        shootCooldown = ShootInterval;
    }

    /// <summary>
    /// Обновляет положение объекта с учётом времени кадра.
    /// </summary>
    protected override void Move(float delta)
    {
        Position += Vector2.Left * HorizontalSpeed * delta;
        shootCooldown -= delta;
        if (shootCooldown <= 0f)
        {
            Shoot();
            shootCooldown = Mathf.Max(0.1f, ShootInterval);
        }
    }

    /// <summary>
    /// Создаёт снаряд и задаёт его начальную позицию и скорость.
    /// </summary>
    private void Shoot()
    {
        EnemyBullet enemyBullet = bulletScene.Instantiate<EnemyBullet>();
        GetParent().AddChild(enemyBullet);
        enemyBullet.GlobalPosition = GlobalPosition + Vector2.Left * 50f;
        enemyBullet.Velocity = Vector2.Left * BulletSpeed;
    }
}

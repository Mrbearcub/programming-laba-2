using Godot;
using System;

public partial class GroundEnemy : Enemy
{
    [Export]
    private float SpawnX = 1300f;
    [Export]
    private float SpawnY = 450f;

    /// <summary>
    /// Вычисляет позицию появления объекта на игровом поле.
    /// </summary>
    public override Vector2 GetSpawnPosition() //Спавним за экраном
    {
        return new Vector2(SpawnX, SpawnY);
    }
}

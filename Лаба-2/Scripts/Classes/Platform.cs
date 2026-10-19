using Godot;
using System;

public partial class Platform : BenignObject
{
    [Export]
    private float SpawnX = 1300f;

    [Export]
    private float MinSpawnY = 50f;

    [Export]
    private float MaxSpawnY = 250f;
    /// <summary>
    /// Вычисляет позицию появления объекта на игровом поле.
    /// </summary>
    public override Vector2 GetSpawnPosition() //Меняем спавн, чтобы был на рандомной высоте
    {
        RandomNumberGenerator random = new RandomNumberGenerator();

        float randomY = random.RandfRange(MinSpawnY, MaxSpawnY);

        return new Vector2(SpawnX, randomY);
    }
}

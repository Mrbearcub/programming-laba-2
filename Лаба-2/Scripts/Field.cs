using Godot;
using System;
using System.Security.Cryptography;
using RandomNumberGenerator = Godot.RandomNumberGenerator;

public partial class Field : Node2D
{
   
    private Timer EnemyTimer;
    private Timer PlatformTimer;
    private Timer ObstacleTimer;
    private Node SpawnNode;

    /// <summary>
    /// Инициализирует объект и необходимые связи при добавлении на сцену.
    /// </summary>
    public override void _Ready()
    {
        SpawnNode = GetNode<Node2D>("Enemy");
        EnemyTimer = GetNode<Timer>("EnemyTimer");
        PlatformTimer = GetNode<Timer>("PlatformTimer");
        ObstacleTimer = GetNode<Timer>("ObstacleTimer");
    }

    /// <summary>
    /// Вызывается таймером и запускает создание нового игрового объекта.
    /// </summary>
    private void _OnSpawnEnemyTimerTimeout()
    {
        //GD.Print("Spawn");
        SpawnEnemy();
    }

    /// <summary>
    /// Вызывается таймером и запускает создание нового игрового объекта.
    /// </summary>
    private void _OnSpawnPlatformTimerTimeout()
    {
        //GD.Print("Spawn");
        SpawnPlatform();
    }

    /// <summary>
    /// Вызывается таймером и запускает создание нового игрового объекта.
    /// </summary>
    private void _OnSpawnObstacleTimerTimeout()
    {
        //GD.Print("Spawn");
        SpawnObstacle();
    }

    [Export]
    private Godot.Collections.Array<PackedScene> Enemies = new Godot.Collections.Array<PackedScene>();
    [Export]
    private Godot.Collections.Array<PackedScene> Platforms = new Godot.Collections.Array<PackedScene>();
    [Export]
    private Godot.Collections.Array<PackedScene> Obstacles = new Godot.Collections.Array<PackedScene>();
    private RandomNumberGenerator random = new RandomNumberGenerator();

    /// <summary>
    /// Создаёт случайного врага из доступных сцен.
    /// </summary>
    private void SpawnEnemy() //Спавним рандомных врагов с определенной периодичностью
    {
        int RandomIndex = random.RandiRange(0, Enemies.Count - 1);
        GD.Print($"Spawn enemy {Enemies[RandomIndex].ResourcePath}");
        Enemy obj = (Enemy)Enemies[RandomIndex].Instantiate();
        SpawnNode.AddChild(obj);
        obj.Position = obj.GetSpawnPosition();

    }

    /// <summary>
    /// Создаёт платформу из списка доступных сцен.
    /// </summary>
    private void SpawnPlatform()
    {
        int RandomIndex = random.RandiRange(0, Platforms.Count - 1);
        GD.Print($"Spawn platform {Platforms[RandomIndex].ResourcePath}");
        BenignObject obj = (BenignObject)Platforms[RandomIndex].Instantiate();
        SpawnNode.AddChild(obj);
        obj.Position = obj.GetSpawnPosition();

    }

    /// <summary>
    /// Создаёт препятствие из списка доступных сцен.
    /// </summary>
    private void SpawnObstacle()
    {
        int RandomIndex = random.RandiRange(0, Obstacles.Count - 1);
        GD.Print($"Spawn platform {Obstacles[RandomIndex].ResourcePath}");
        Obstacle obj = (Obstacle)Obstacles[RandomIndex].Instantiate();
        SpawnNode.AddChild(obj);
        obj.Position = obj.GetSpawnPosition();

    }
}

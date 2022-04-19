public class PlyareSpawner : Entity
{
    protected override void Initialize()
    {
        AddSystem(new PlayerSpawnerSystem());
    }
}

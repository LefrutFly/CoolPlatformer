public class PlyareSpawner : Entity
{
    protected override void Initialize()
    {
        GameLinks.AddLink(this);

        AddSystem(new PlayerSpawnerSystem());
    }
}

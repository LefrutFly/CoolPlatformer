using Lefrut.Framework;

public class PlyareSpawner : Facade
{
    protected override void InitData()
    {
        AddData(new PlayerSpawnerSystem());
    }

    protected override void InitSystems()
    {
        GameLinks.AddLink(this);

        AddSystem(new PlayerSpawnerSystem());
    }
}

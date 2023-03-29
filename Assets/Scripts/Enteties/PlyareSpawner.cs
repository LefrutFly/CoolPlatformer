using Lefrut.Framework;

public class PlyareSpawner : Facade
{
    protected override void InitData()
    {
        AddDataFromSystem(new PlayerSpawnerSystem());
    }

    protected override void InitSystems()
    {
        GameLinks.AddLink(this);

        AddSystem(new PlayerSpawnerSystem());
    }
}

using Lefrut.Framework;

public class PlayerSpawnerProvider : IProvider
{
    public PlayerSpawnerComponent component;

    public override IData Data => component;
}

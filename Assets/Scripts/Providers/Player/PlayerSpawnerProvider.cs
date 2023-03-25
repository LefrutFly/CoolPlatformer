using Lefrut.Framework;

public class PlayerSpawnerProvider : MonoProvider
{
    public PlayerSpawnerComponent component;

    public override IData Data => component;
}

using Lefrut.Framework;

public class EntityProvider : MonoProvider
{
    public EntityComponent component;

    public override IData Data => component;
}

using Lefrut.Framework;

public class EntityProvider : IProvider
{
    public EntityComponent component;

    public override IData Data => component;
}

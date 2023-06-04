using Lefrut.Framework;

public class EntityIsDieProvider : IProvider
{
    public EntityIsDieComponent component;

    public override IData Data => component;
}
using Lefrut.Framework;

public class EntityIsDieProvider : MonoProvider
{
    public EntityIsDieComponent component;

    public override IData Data => component;
}
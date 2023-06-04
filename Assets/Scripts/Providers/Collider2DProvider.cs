using Lefrut.Framework;

public class Collider2DProvider : IProvider
{
    public Collider2DComponent component;

    public override IData Data => component;
}
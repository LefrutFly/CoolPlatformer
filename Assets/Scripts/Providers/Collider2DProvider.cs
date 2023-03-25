using Lefrut.Framework;

public class Collider2DProvider : MonoProvider
{
    public Collider2DComponent component;

    public override IData Data => component;
}
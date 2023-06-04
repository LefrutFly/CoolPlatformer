using Lefrut.Framework;

public class ViewSpriteProvider : IProvider
{
    public ViewSpriteComponent component;

    public override IData Data => component;
}
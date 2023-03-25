using Lefrut.Framework;

public class ViewSpriteProvider : MonoProvider
{
    public ViewSpriteComponent component;

    public override IData Data => component;
}
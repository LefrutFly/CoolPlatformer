using Lefrut.Framework;

public class DirectionProvider : MonoProvider
{
    public DirectionComponent component;

    public override IData Data => component;
}
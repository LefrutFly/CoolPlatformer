using Lefrut.Framework;

public class DirectionProvider : IProvider
{
    public DirectionComponent component;

    public override IData Data => component;
}
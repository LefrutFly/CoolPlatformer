using Lefrut.Framework;

public class RotatableProvider : IProvider
{
    public RotatableComponent component;

    public override IData Data => component;
}

using Lefrut.Framework;

public class RotatableProvider : MonoProvider
{
    public RotatableComponent component;

    public override IData Data => component;
}

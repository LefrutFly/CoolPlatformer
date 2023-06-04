using Lefrut.Framework;

public class ManaProvider : IProvider
{
    public ManaComponent component;

    public override IData Data => component;
}
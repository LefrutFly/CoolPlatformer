using Lefrut.Framework;

public class PlusHealthProvider : IProvider
{
    public PlusHealthComponent component;

    public override IData Data => component;
}

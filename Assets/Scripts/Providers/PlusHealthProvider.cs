using Lefrut.Framework;

public class PlusHealthProvider : MonoProvider
{
    public PlusHealthComponent component;

    public override IData Data => component;
}

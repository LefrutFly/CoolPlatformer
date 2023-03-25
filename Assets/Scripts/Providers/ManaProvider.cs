using Lefrut.Framework;

public class ManaProvider : MonoProvider
{
    public ManaComponent component;

    public override IData Data => component;
}
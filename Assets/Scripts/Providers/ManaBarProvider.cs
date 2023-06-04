using Lefrut.Framework;

public class ManaBarProvider : IProvider
{
    public ManaBarComponent component;

    public override IData Data => component;
}

using Lefrut.Framework;

public class ManaBarProvider : MonoProvider
{
    public ManaBarComponent component;

    public override IData Data => component;
}

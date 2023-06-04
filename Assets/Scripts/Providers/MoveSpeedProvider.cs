using Lefrut.Framework;

public class MoveSpeedProvider : IProvider
{
    public MoveSpeedComponent component;

    public override IData Data => component;
}

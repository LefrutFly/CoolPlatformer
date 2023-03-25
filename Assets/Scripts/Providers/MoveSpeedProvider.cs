using Lefrut.Framework;

public class MoveSpeedProvider : MonoProvider
{
    public MoveSpeedComponent component;

    public override IData Data => component;
}

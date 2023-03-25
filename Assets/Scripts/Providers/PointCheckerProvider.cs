using Lefrut.Framework;

public class PointCheckerProvider : MonoProvider
{
    public PointCheckerComponent component;

    public override IData Data => component;
}

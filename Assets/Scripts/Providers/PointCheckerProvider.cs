using Lefrut.Framework;

public class PointCheckerProvider : IProvider
{
    public PointCheckerComponent component;

    public override IData Data => component;
}

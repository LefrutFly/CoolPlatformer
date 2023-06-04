using Lefrut.Framework;

public class CameraShiftProvider : IProvider
{
    public CameraShiftComponent component;

    public override IData Data => component;
}
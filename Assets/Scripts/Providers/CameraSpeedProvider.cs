using Lefrut.Framework;

public class CameraSpeedProvider : IProvider
{
    public CameraSpeedComponent component;

    public override IData Data => component;
}
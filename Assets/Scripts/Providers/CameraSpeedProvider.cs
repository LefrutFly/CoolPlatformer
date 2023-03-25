using Lefrut.Framework;

public class CameraSpeedProvider : MonoProvider
{
    public CameraSpeedComponent component;

    public override IData Data => component;
}
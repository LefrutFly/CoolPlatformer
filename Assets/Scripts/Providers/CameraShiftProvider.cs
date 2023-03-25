using Lefrut.Framework;

public class CameraShiftProvider : MonoProvider
{
    public CameraShiftComponent component;

    public override IData Data => component;
}
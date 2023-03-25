using Lefrut.Framework;

public class HealthBarProvider : MonoProvider
{
    public HealthBarComponent component;

    public override IData Data => component;
}

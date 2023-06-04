using Lefrut.Framework;

public class HealthBarProvider : IProvider
{
    public HealthBarComponent component;

    public override IData Data => component;
}

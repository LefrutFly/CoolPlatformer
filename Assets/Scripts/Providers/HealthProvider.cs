using Lefrut.Framework;

public class HealthProvider : IProvider 
{
    public HealthComponent component;

    public override IData Data => component;
}

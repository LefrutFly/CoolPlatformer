using Lefrut.Framework;

public class PeriodicTriggerDamageProvider : IProvider
{
    public PeriodicTriggerDamageComponent component;

    public override IData Data => component;
}

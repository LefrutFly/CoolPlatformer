using Lefrut.Framework;

public class PeriodicTriggerDamageProvider : MonoProvider
{
    public PeriodicTriggerDamageComponent component;

    public override IData Data => component;
}

public class Spike : TrapTag
{
    protected override void Initialize()
    {
        AddSystem(new PeriodicTriggerDamageSystem());
    }
}

public class Spike : TrapTag
{
    protected override void InitData()
    {
        AddData(new PeriodicTriggerDamageSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new PeriodicTriggerDamageSystem());
    }
}

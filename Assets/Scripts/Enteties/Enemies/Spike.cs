public class Spike : TrapTag
{
    protected override void InitData()
    {
        AddDataFromSystem(new PeriodicTriggerDamageSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new PeriodicTriggerDamageSystem());
    }
}

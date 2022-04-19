public class Spike : Entity
{
    protected override void Initialize()
    {
        AddSystem(new PeriodicTriggerDamageSystem());
    }
}

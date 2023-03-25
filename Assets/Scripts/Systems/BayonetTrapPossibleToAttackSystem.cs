using Lefrut.Framework;

public class BayonetTrapPossibleToAttackSystem : BaseSystem, IEnableSystem, IUpdatableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new AttackReachProvider(), this);
        NeededProviders.Set(new PossibleToAttackProvider(), this);
    }

    public void Enable()
    {
        var trap = Providers.Get<EntityProvider>().component.entity as BayonetTrap;

        AddSystems(trap);
    }

    public void Update()
    {
        var possibleToAttack = Providers.Get<PossibleToAttackProvider>().component;
        var isAttackReach = Providers.Get<AttackReachProvider>().component.IsIt;

        possibleToAttack.IsIt = isAttackReach;
    }

    private void AddSystems(BayonetTrap trap)
    {
        var globalSystemStorage = GlobalSystemStorage.GetInstance();
        var index = Facade.Index;

        if (globalSystemStorage.Systems[index].Has<AttackReachSystem<EnemyTag>>() == false)
        {
            trap.AddSystem(new AttackReachSystem<EnemyTag>());
        }
    }
}
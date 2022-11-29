public class BayonetTrapPossibleToAttackSystem : BaseSystem, IEnableSystem, IUpdatableSystem
{
    public void Enable()
    {
        if (Providers.Has<EntityProvider>() == false) return;

        var trap = Providers.Get<EntityProvider>().component.entity as BayonetTrap;

        AddSystems(trap);
    }

    public void Update()
    {
        if (Providers.Has<EntityProvider>() == false ||
            Providers.Has<AttackReachProvider>() == false ||
            Providers.Has<PossibleToAttackProvider>() == false)
            return;

        var possibleToAttack = Providers.Get<PossibleToAttackProvider>().component;
        var isAttackReach = Providers.Get<AttackReachProvider>().component.IsIt;

        possibleToAttack.IsIt = isAttackReach;
    }

    private void AddSystems(BayonetTrap trap)
    {
        if (trap.Systems.Has<AttackReachSystem<EnemyTag>>() == false)
        {
            trap.AddSystem(new AttackReachSystem<EnemyTag>());
        }
    }
}
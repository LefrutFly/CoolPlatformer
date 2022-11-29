using UnityEngine;

public class NipperPossibleToAttackSystem : BaseSystem, IUpdatableSystem, IEnableSystem
{
    private PossibleToAttackComponent possibleToAttack;
    private AttackComponent playerAttackComponent;
    private Collider2D collider;
    private ColliderDeterminant colliderDeterminant = new ColliderDeterminant();
    private Entity thisEntity;

    public void Enable()
    {
        if (Providers.Has<EntityProvider>() == false ||
            Providers.Has<AttackReachProvider>() == false ||
            Providers.Has<PossibleToAttackProvider>() == false)
            return;

        var nipper = Providers.Get<EntityProvider>().component.entity as Nipper;

        AddSystems(nipper);

        possibleToAttack = Providers.Get<PossibleToAttackProvider>().component;
        playerAttackComponent = Providers.Get<AttackProvider>().component;
        collider = playerAttackComponent.collider;
        thisEntity = Providers.Get<EntityProvider>().component.entity;
    }

    public void Update()
    {
        if (Providers.Has<EntityProvider>() == false ||
            Providers.Has<AttackReachProvider>() == false ||
            Providers.Has<PossibleToAttackProvider>() == false)
            return;

        thisEntity = Providers.Get<EntityProvider>().component.entity;
        var isAttackReach = Providers.Get<AttackReachProvider>().component.IsIt;
        var isAnotherEnemy = colliderDeterminant.IsItT<EnemyTag>(collider, thisEntity);
        var isPlayer = colliderDeterminant.IsItT<Player>(collider, thisEntity);

        possibleToAttack.IsIt = isAttackReach && (!isAnotherEnemy || isPlayer);
    }

    private void AddSystems(Nipper nipper)
    {
        if (nipper.Systems.Has<AttackReachSystem<EnemyTag>>() == false)
        {
            nipper.AddSystem(new AttackReachSystem<EnemyTag>());
        }
    }
}

using UnityEngine;

public class NipperPossibleToAttackSystem : BaseSystem, IUpdatableSystem, IStartableSystem
{
    private PossibleToAttackComponent possibleToAttack;
    private AttackComponent playerAttackComponent;
    private Collider2D collider;
    private ColliderDeterminant colliderDeterminant = new ColliderDeterminant();
    private Entity thisEntity;

    public void Start()
    {
        if (Providers.Has<EntityProvider>() == false)
            return;

        var nipper = Providers.Get<EntityProvider>().component.entity as Nipper;

        AddProviders(nipper);
        AddSystems(nipper);

        possibleToAttack = Providers.Get<PossibleToAttackProvider>().component;
        playerAttackComponent = Providers.Get<AttackProvider>().component;
        collider = playerAttackComponent.collider;
        thisEntity = Providers.Get<EntityProvider>().component.entity;
    }

    public void Update()
    {
        if (Providers.Has<EntityProvider>() == false)
            return;

        thisEntity = Providers.Get<EntityProvider>().component.entity;
        var isAttackReach = Providers.Get<AttackReachProvider>().component.IsIt;
        var isAnotherEnemy = colliderDeterminant.IsItT<Enemy>(collider, thisEntity);
        var isPlayer = colliderDeterminant.IsItT<Player>(collider, thisEntity);

        possibleToAttack.IsIt = isAttackReach && (!isAnotherEnemy || isPlayer);
    }

    private void AddProviders(Nipper nipper)
    {
        if (Providers.Has<AttackReachProvider>() == false)
        {
            nipper.Providers.Set(new AttackReachProvider());
        }
        if (Providers.Has<PossibleToAttackProvider>() == false)
        {
            nipper.Providers.Set(new PossibleToAttackProvider());
        }
    }

    private void AddSystems(Nipper nipper)
    {
        if (nipper.Systems.Has<AttackReachSystem>() == false)
        {
            nipper.AddSystem(new AttackReachSystem());
        }
    }
}

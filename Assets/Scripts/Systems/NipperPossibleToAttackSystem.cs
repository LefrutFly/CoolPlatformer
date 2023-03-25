using Lefrut.Framework;
using UnityEngine;

public class NipperPossibleToAttackSystem : BaseSystem, IUpdatableSystem, IEnableSystem
{
    private PossibleToAttackComponent possibleToAttack;
    private AttackComponent playerAttackComponent;
    private Collider2D collider;
    private ColliderDeterminant colliderDeterminant = new ColliderDeterminant();
    private Facade thisEntity;


    public override void AddProviders()
    {
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new AttackReachProvider(), this);
        NeededProviders.Set(new PossibleToAttackProvider(), this);
    }

    public void Enable()
    {
        var nipper = Providers.Get<EntityProvider>().component.entity as Nipper;

        AddSystems(nipper);

        possibleToAttack = Providers.Get<PossibleToAttackProvider>().component;
        playerAttackComponent = Providers.Get<AttackProvider>().component;
        collider = playerAttackComponent.collider;
        thisEntity = Providers.Get<EntityProvider>().component.entity;
    }

    public void Update()
    {
        thisEntity = Providers.Get<EntityProvider>().component.entity;
        var isAttackReach = Providers.Get<AttackReachProvider>().component.IsIt;
        var isAnotherEnemy = colliderDeterminant.IsItT<EnemyTag>(collider, thisEntity);
        var isPlayer = colliderDeterminant.IsItT<Player>(collider, thisEntity);

        possibleToAttack.IsIt = isAttackReach && (!isAnotherEnemy || isPlayer);
    }

    private void AddSystems(Nipper nipper)
    {
        var globalSystemStorage = GlobalSystemStorage.GetInstance();
        var index = Facade.Index;
        if (globalSystemStorage.Systems[index].Has<AttackReachSystem<EnemyTag>>() == false)
        {
            nipper.AddSystem(new AttackReachSystem<EnemyTag>());
        }
    }
}

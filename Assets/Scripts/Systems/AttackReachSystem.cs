using System.Collections.Generic;
using UnityEngine;

public class AttackReachSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (Providers.Has<AttackProvider>() == false ||
            Providers.Has<EntityProvider>() == false ||
            Providers.Has<PossibleToAttackProvider>() == false)
            return;

        var playerAttackComponent = Providers.Get<AttackProvider>().component;

        var collider = playerAttackComponent.collider;

        var thisEntity = Providers.Get<EntityProvider>().component.entity;

        Providers.Get<PossibleToAttackProvider>().component.IsIt = IsInWithinReach(collider, thisEntity);
    }

    private bool IsInWithinReach(Collider2D collider, Entity thisEntity)
    {
        List<Collider2D> colliders = new List<Collider2D>();

        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;

        collider.OverlapCollider(contactFilter, colliders);

        foreach (var c in colliders)
        {
            if (c.gameObject.TryGetComponent(out Entity entity) && c.gameObject != thisEntity.gameObject)
            {
                if(entity.Providers.Has<HealthProvider>() == true)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class AttackReachSystem<AlliesType> : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (Providers.Has<AttackProvider>() == false ||
            Providers.Has<EntityProvider>() == false ||
            Providers.Has<AttackReachProvider>() == false)
            return;

        var playerAttackComponent = Providers.Get<AttackProvider>().component;

        var collider = playerAttackComponent.collider;

        var thisEntity = Providers.Get<EntityProvider>().component.entity;

        Providers.Get<AttackReachProvider>().component.IsIt = IsInWithinReach(collider, thisEntity);
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
                if (entity.Providers.Has<HealthProvider>() == true && entity.gameObject.GetComponent<AlliesType>() == null)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

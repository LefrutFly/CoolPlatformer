using Lefrut.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AttackReachSystem<AlliesType> : BaseSystem, IUpdatableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new AttackProvider(), this);
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new AttackReachProvider(), this);
    }

    public void Update()
    {
        var playerAttackComponent = Providers.Get<AttackProvider>().component;

        var collider = playerAttackComponent.collider;

        var thisEntity = Providers.Get<EntityProvider>().component.entity;

        Providers.Get<AttackReachProvider>().component.IsIt = IsInWithinReach(collider, thisEntity);
    }

    private bool IsInWithinReach(Collider2D collider, Facade thisEntity)
    {
        List<Collider2D> colliders = new List<Collider2D>();

        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;

        collider.OverlapCollider(contactFilter, colliders);

        foreach (var c in colliders)
        {
            if (c.gameObject.TryGetComponent(out Facade entity) && c.gameObject != thisEntity.gameObject)
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

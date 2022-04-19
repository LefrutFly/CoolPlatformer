using UnityEngine;

public class GunDamageSystem : BaseSystem, ITriggableSystem
{
    public void TriggetEnter(Collider2D collision)
    {
        if(Providers.Has<GunDamageProvider>() == false) return;

        var damage = Providers.Get<GunDamageProvider>().component.damage;

        if (collision.TryGetComponent(out Entity entity))
        {
            if(entity.Providers.TryGet(out HealthProvider healthProvider))
            {
                HealthComponent health = healthProvider.component;

                health.TakeDamage(damage);
            }
        }
    }

    public void TriggetExit(Collider2D collision) { }

    public void TriggetStay(Collider2D collision) { }
}
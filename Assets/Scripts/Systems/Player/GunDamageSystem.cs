using Lefrut.Framework;
using UnityEngine;

public class GunDamageSystem : BaseSystem, ITriggerableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new GunDamageProvider(), this);
        NeededProviders.Set(new Collider2DProvider(), this);
    }

    public void TriggetEnter(Collider2D collision)
    {
        var damage = Providers.Get<GunDamageProvider>().component.damage;

        if (collision.TryGetComponent(out Facade entity))
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
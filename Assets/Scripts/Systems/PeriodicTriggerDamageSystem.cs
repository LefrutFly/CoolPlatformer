using Lefrut.Framework;
using System.Collections;
using UnityEngine;

public class PeriodicTriggerDamageSystem : BaseSystem, ITriggerableSystem
{
    private Coroutine damage;


    public override void AddProviders()
    {
        NeededProviders.Set(new PeriodicTriggerDamageProvider(), this);
    }

    public void TriggetEnter(Collider2D collision)
    {
        ref var periodicTriggerDamageComponent = ref Providers.Get<PeriodicTriggerDamageProvider>().component;

        if (collision.TryGetComponent(out Facade entity))
        {
            if (damage == null)
            {
                damage = Coroutines.Start(TakeDamage(entity, periodicTriggerDamageComponent));
            }
        }
    }

    public void TriggetExit(Collider2D collision)
    {
        if (collision.TryGetComponent(out Facade entity))
        {
            if (damage != null)
            {
                Coroutines.Stop(damage);
                damage = null;
            }
        }
    }

    public void TriggetStay(Collider2D collision) { }

    private IEnumerator TakeDamage(Facade entity, PeriodicTriggerDamageComponent component)
    {
        var damage = component.damage;
        var cooldown = component.cooldown;

        if (entity.Providers.Has<HealthProvider>() == false) yield break;

        while (true)
        {
            entity.Providers.Get<HealthProvider>().component.TakeDamage(damage);

            yield return new WaitForSeconds(cooldown);

            if (entity.gameObject.activeSelf == false)
            {
                break;
            }
        }
        if (this.damage != null)
        {
            Coroutines.Stop(this.damage);
            this.damage = null;
        }
    }
}

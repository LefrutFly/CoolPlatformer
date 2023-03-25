using Lefrut.Framework;
using UnityEngine;

public class PlusHealthSystem : BaseSystem, ITriggerableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new PlusHealthProvider(), this);
        NeededProviders.Set(new EntityProvider(), this);
    }

    public void TriggetEnter(Collider2D collision)
    {
        var plusHealthComponent = Providers.Get<PlusHealthProvider>().component;

        AddHealth(collision, plusHealthComponent);
    }

    public void TriggetExit(Collider2D collision) { }

    public void TriggetStay(Collider2D collision) { }

    private void AddHealth(Collider2D collision, PlusHealthComponent plusHealthComponent)
    {
        var plusHealth = plusHealthComponent.plusHealth;

        if (collision.TryGetComponent(out Facade entity))
        {
            if (entity.Providers.TryGet(out HealthProvider healthProvider))
            {
                if (healthProvider.component.Health < healthProvider.component.MaxHealth)
                {
                    healthProvider.component.Health += plusHealth;

                    Destroy();
                }
            }
        }
    }

    private void Destroy()
    {
        MonoBehaviour.Destroy(Providers.Get<EntityProvider>().component.entity.gameObject);
    }
} 
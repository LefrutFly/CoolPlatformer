using UnityEngine;

public class PlusHealthSystem : BaseSystem, ITriggableSystem
{
    public void TriggetEnter(Collider2D collision)
    {
        if (Providers.Has<PlusHealthProvider>() == false ||
            Providers.Has<EntityProvider>() == false) 
            return;

        var plusHealthComponent = Providers.Get<PlusHealthProvider>().component;

        AddHealth(collision, plusHealthComponent);
    }

    public void TriggetExit(Collider2D collision) { }

    public void TriggetStay(Collider2D collision) { }

    private void AddHealth(Collider2D collision, PlusHealthComponent plusHealthComponent)
    {
        var plusHealth = plusHealthComponent.plusHealth;

        if (collision.TryGetComponent(out Entity entity))
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
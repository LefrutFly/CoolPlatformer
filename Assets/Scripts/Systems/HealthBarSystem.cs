using UnityEngine;

public class HealthBarSystem : BaseSystem, IStartableSystem, IDisableSystem
{
    public void Start()
    {
        if (Providers.Has<EntityProvider>() == false ||
            Providers.Has<HealthBarProvider>() == false )
            return;

        var entity = Providers.Get<EntityProvider>().component.entity;

        if (entity.Providers.TryGet(out HealthProvider healthProvider))
        {
            float health = entity.Providers.Get<HealthProvider>().component.Health;

            ChangeBar(health);

            entity.Providers.Get<HealthProvider>().component.ChangedHealth += () =>
            {
                float health = entity.Providers.Get<HealthProvider>().component.Health;

                ChangeBar(health);
            };
        }
    }

    public void Disable()
    {
        if (Providers.Has<EntityProvider>() == false)
            return;

        var healthBarComponent = Providers.Get<HealthBarProvider>().component;
        var entity = Providers.Get<EntityProvider>().component.entity;

        if (entity.Providers.TryGet(out HealthProvider healthProvider))
        {
            entity.Providers.Get<HealthProvider>().component.ChangedHealth -= () =>
            {
                float health = entity.Providers.Get<HealthProvider>().component.Health;

                ChangeBar(health);
            };
        }
    }

    private void ChangeBar(float health)
    {
         var healthBarComponent =  Providers.Get<HealthBarProvider>().component;

         var text =  healthBarComponent.text;
         var animator =  healthBarComponent.animator;
         var nameAnimationTrigger =  healthBarComponent.nameAnimationTrigger;

        text.text = "HP : " + health;
        animator.SetTrigger(nameAnimationTrigger);
    }
}

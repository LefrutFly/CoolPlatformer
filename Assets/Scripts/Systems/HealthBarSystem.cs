using Lefrut.Framework;

public class HealthBarSystem : BaseSystem, IStartableSystem, IDisableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new HealthBarProvider(), this);
    }

    public void Start()
    {
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
        var healthBarComponent = Providers.Get<HealthBarProvider>().component;

        var text = healthBarComponent.text;
        var animator = healthBarComponent.animator;
        var nameAnimationTrigger = healthBarComponent.nameAnimationTrigger;

        text.text = "HP : " + health;
        animator.SetTrigger(nameAnimationTrigger);

        if (health <= 0)
        {
            var newColor = text.color;

            newColor.r *= 0.55f;
            newColor.g *= 0.55f;
            newColor.b *= 0.55f;
            newColor.a = 0.8f;

            text.color = newColor;
        }
    }
}

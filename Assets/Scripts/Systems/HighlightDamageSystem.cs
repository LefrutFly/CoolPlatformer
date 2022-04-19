public class HighlightDamageSystem : BaseSystem, IStartableSystem, IDisableSystem
{
    public void Start()
    {
        if (Providers.Has<HealthProvider>() == false ||
           Providers.Has<ViewSpriteProvider>() == false)
            return;

        var healthComponent = Providers.Get<HealthProvider>().component;

        healthComponent.TakedDamage += Highlight;
    }

    public void Disable()
    {
        if (Providers.Has<HealthProvider>() == false ||
            Providers.Has<ViewSpriteProvider>() == false)
            return;

        var healthComponent = Providers.Get<HealthProvider>().component;

        healthComponent.TakedDamage -= Highlight;
    }

    private void Highlight()
    {
        var sprite = Providers.Get<ViewSpriteProvider>().component.spriteRenderer;
        var healthComponent = Providers.Get<HealthProvider>().component;

        
    }
}
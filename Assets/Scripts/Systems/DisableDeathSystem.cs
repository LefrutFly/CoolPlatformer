using UnityEngine;

public class DisableDeathSystem : BaseSystem, IStartableSystem, IDisableSystem
{
    public void Start()
    {
        if (Providers.Has<HealthProvider>() == false || Providers.Has<EntityProvider>() == false) return;
     
        Providers.Get<HealthProvider>().component.ZeroHealth += Die;
    }

    public void Disable()
    {
        if (Providers.Has<HealthProvider>() || Providers.Has<EntityProvider>()) return;

        Providers.Get<HealthProvider>().component.ZeroHealth -= Die;
    }

    protected void Die()
    {
        var entity = Providers.Get<EntityProvider>().component.entity;
        entity.gameObject.SetActive(false);
    }
}

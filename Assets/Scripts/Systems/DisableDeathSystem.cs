using Lefrut.Framework;
using UnityEngine;

public class DisableDeathSystem : BaseSystem, IEnableSystem, IDisableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new HealthProvider(), this);
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new EntityIsDieProvider(), this);
    }

    public void Enable()
    {
        Providers.Get<HealthProvider>().component.ZeroHealth += Die;
    }

    public void Disable()
    {
        Providers.Get<HealthProvider>().component.ZeroHealth -= Die;
    }

    protected void Die()
    {
        var entity = Providers.Get<EntityProvider>().component.entity;
        entity.gameObject.SetActive(false);

        Providers.Get<EntityIsDieProvider>().component.IsIt = true;
    }
}

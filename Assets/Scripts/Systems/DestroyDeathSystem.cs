using Lefrut.Framework;
using UnityEngine;

public class DestroyDeathSystem : BaseSystem, IStartableSystem, IDisableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new HealthProvider(), this);
        NeededProviders.Set(new EntityProvider(), this);
    }

    public void Start()
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

        MonoBehaviour.Destroy(entity.gameObject);
    }
}

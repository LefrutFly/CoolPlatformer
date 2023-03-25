using Lefrut.Framework;
using UnityEngine;

public class RotationAroundSystem : BaseSystem, IUpdatableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new RotatableProvider(), this);
        NeededProviders.Set(new EntityProvider(), this);
    }

    public void Update()
    {
        var rotatableComponent = Providers.Get<RotatableProvider>().component;
        var entity = Providers.Get<EntityProvider>().component.entity;

        Rotate(entity, rotatableComponent);
    }

    private void Rotate(Facade entity, RotatableComponent rotatableComponent)
    {
        float speed = rotatableComponent.rotationalSpeed;

        entity.gameObject.transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);   
    }
}
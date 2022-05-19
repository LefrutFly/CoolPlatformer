using UnityEngine;

public class RotationAroundSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (Providers.Has<RotatableProvider>() == false ||
            Providers.Has<EntityProvider>() == false)
            return;

        var rotatableComponent = Providers.Get<RotatableProvider>().component;
        var entity = Providers.Get<EntityProvider>().component.entity;

        Rotate(entity, rotatableComponent);
    }

    private void Rotate(Entity entity, RotatableComponent rotatableComponent)
    {
        float speed = rotatableComponent.rotationalSpeed;

        entity.gameObject.transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);   
    }
}
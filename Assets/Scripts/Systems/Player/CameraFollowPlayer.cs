using Lefrut.Framework;
using UnityEngine;

public class CameraFollowPlayer : BaseSystem, IFixedUpdatableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new CameraSpeedProvider(), this);
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new CameraShiftProvider(), this);
    }

    public void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        var speed = Providers.Get<CameraSpeedProvider>().component.speed;
        var target = Providers.Get<CameraShiftProvider>().component.target;
        var shift = Providers.Get<CameraShiftProvider>().component.shift;
        var camera = Providers.Get<EntityProvider>().component.entity.transform;

        Vector3 position = target.position;
        position += shift;

        camera.position = Vector3.Lerp(camera.position, position, speed * Time.deltaTime);
    }
}
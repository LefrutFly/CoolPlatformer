using UnityEngine;

public class CameraFollowPlayer : BaseSystem, IFixedUpdatableSystem
{
    public void FixedUpdate()
    {
        if(Providers.Has<CameraSpeedProvider>() == false ||
            Providers.Has<EntityProvider>() == false ||
            Providers.Has<CameraShiftProvider>() == false) 
            return;


        Follow();
    }

    private void Follow()
    {
        if (Providers.Get<CameraShiftProvider>().component.target == null) return;

        var speed = Providers.Get<CameraSpeedProvider>().component.speed;
        var target = Providers.Get<CameraShiftProvider>().component.target;
        var shift = Providers.Get<CameraShiftProvider>().component.shift;
        var camera = Providers.Get<EntityProvider>().component.entity.transform;

        Vector3 position = target.position;
        position += shift;

        camera.position = Vector3.Lerp(camera.position, position, speed * Time.deltaTime);
    }
}
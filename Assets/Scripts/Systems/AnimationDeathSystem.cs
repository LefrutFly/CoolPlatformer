using Lefrut.Framework;
using UnityEngine;

public class AnimationDeathSystem : BaseSystem, IStartableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new HealthProvider(), this);
        NeededProviders.Set(new AnimationDeathProvider(), this);
        NeededProviders.Set(new ViewProvider(), this);
        NeededProviders.Set(new EntityIsDieProvider(), this);
    }

    public void Start()
    {
        Providers.Get<HealthProvider>().component.ZeroHealth += Die;
    }

    public void Die()
    {
        var animationDeathComponent = Providers.Get<AnimationDeathProvider>().component;

        var prefab = animationDeathComponent.prefab;
        var spawnPoint = animationDeathComponent.spawnPoint;
        var timerBeforeDelete = animationDeathComponent.timerBeforeDelete;

        if (Providers.TryGet(out ViewProvider viewProvider) == true)
        {
            spawnPoint.rotation = viewProvider.component.view.transform.rotation;
        }

        DeletableObjectCreator deletableObjectCreator = new DeletableObjectCreator(prefab, timerBeforeDelete, spawnPoint);

        deletableObjectCreator.Create();

        Providers.Get<EntityIsDieProvider>().component.IsIt = true;
    }
}

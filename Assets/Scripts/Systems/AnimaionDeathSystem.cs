public class AnimaionDeathSystem : BaseSystem, IStartableSystem
{
    public void Start()
    {
        if (Providers.Has<HealthProvider>() == false) return;

        Providers.Get<HealthProvider>().component.ZeroHealth += Die;
    }

    public void Die()
    {
        if (Providers.Has<HealthProvider>() == false ||
            Providers.Has<AnimationDeathProvider>() == false)
            return;

        var animationDeathComponent = Providers.Get<AnimationDeathProvider>().component;

        var prefab = animationDeathComponent.prefab;
        var spawnPoint = animationDeathComponent.spawnPoint;
        var timerBeforeDelete = animationDeathComponent.timerBeforeDelete;

        if(Providers.TryGet(out ViewProvider viewProvider) == true)
        {
            spawnPoint.rotation = viewProvider.component.view.transform.rotation;
        }

        DeletableObjectCreator deletableObjectCreator = new DeletableObjectCreator(prefab, timerBeforeDelete, spawnPoint);

        deletableObjectCreator.Create();

        if (Providers.Has<EntityIsDieProvider>() == true)
        {
            Providers.Get<EntityIsDieProvider>().component.IsIt = true;
        }
    }
}

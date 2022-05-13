public class AnimaionDeathSystem : BaseSystem, IStartableSystem
{
    public void Start()
    {
        if (Providers.Has<HealthProvider>() == false) return;

        Providers.Get<HealthProvider>().component.ZeroHealth += Die;
    }

    private void Die()
    {
        if (Providers.Has<HealthProvider>() == false ||
            Providers.Has<AnimationDeathProvider>() == false)
            return;

        var animationDeathComponent = Providers.Get<AnimationDeathProvider>().component;

        var prefab = animationDeathComponent.prefab;
        var spawnPoint = animationDeathComponent.spawnPoint;
        var timerBeforeDelete = animationDeathComponent.timerBeforeDelete;
        bool isDeleted = animationDeathComponent.isDeleted;

        DeletableObjectCreator deletableObjectCreator = new DeletableObjectCreator(prefab, timerBeforeDelete, spawnPoint);

        deletableObjectCreator.Create();
    }
}

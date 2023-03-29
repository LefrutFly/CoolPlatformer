using Lefrut.Framework;

public class AnimatorDeathSystem : BaseSystem, IStartableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new HealthProvider(), this);
        NeededProviders.Set(new EntityIsDieProvider(), this);
        NeededProviders.Set(new AnimatorDeathProvider(), this);
    }

    public void Start()
    {
        Providers.Get<HealthProvider>().component.ZeroHealth += Die;
    }

    public void Die()
    {
        var animationDeathData = (AnimatorDeathData)Providers.Get<AnimatorDeathProvider>().Data;

        animationDeathData.animator.SetTrigger(animationDeathData.animationTrigger);

        Providers.Get<EntityIsDieProvider>().component.IsIt = true;
    }
}
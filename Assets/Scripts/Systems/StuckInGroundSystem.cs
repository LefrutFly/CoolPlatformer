using Lefrut.Framework;

public class StuckInGroundSystem : BaseSystem, IUpdatableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new PointCheckerProvider(), this);
        NeededProviders.Set(new HealthProvider(), this);
        NeededProviders.Set(new EntityIsDieProvider(), this);

    }

    public void Update()
    {
        var pointChecker = Providers.Get<PointCheckerProvider>().component;
        var Health = Providers.Get<HealthProvider>().component;
        var entityIsDie = Providers.Get<EntityIsDieProvider>().component;

        if (pointChecker.isInternalCollide &&
            pointChecker.isLeftCollide &&
            pointChecker.isRightCollide &&
            pointChecker.isTopCollide &&
            pointChecker.isBottomCollide)
        {
            if(entityIsDie.IsIt == false)
            {
                Health.Health = 0;
                entityIsDie.IsIt = true;
            }
        }
    }
}
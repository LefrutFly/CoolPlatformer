public class StuckInGroundSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (Providers.Has<PointCheckerProvider>() == false ||
            Providers.Has<HealthProvider>() == false ||
            Providers.Has<EntityIsDieProvider>() == false)
            return;

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
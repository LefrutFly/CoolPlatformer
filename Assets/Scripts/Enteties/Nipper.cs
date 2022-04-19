public class Nipper : Entity
{
    protected override void Initialize()
    {
        AddSystem(new PointCheckerSystem());
        AddSystem(new PatrolFromWallToWallSystem());
        AddSystem(new AttackReachSystem());
        AddSystem(new AttackSystem());

        AddSystem(new DestroyDeathSystem());
    }
}
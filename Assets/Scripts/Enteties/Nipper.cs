public class Nipper : Enemy
{
    protected override void Initialize()
    {
        AddSystem(new PointCheckerSystem());
        AddSystem(new PatrolFromWallToWallSystem());
        AddSystem(new NipperPossibleToAttackSystem());
        AddSystem(new AttackSystem<Enemy>());
        AddSystem(new HighlightDamageSystem());

        AddSystem(new DestroyDeathSystem());
    }
}

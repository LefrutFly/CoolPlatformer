public class Nipper : EnemyTag
{
    protected override void Initialize()
    {
        AddSystem(new PointCheckerSystem());
        AddSystem(new PatrolFromWallToWallSystem());
        AddSystem(new NipperPossibleToAttackSystem());
        AddSystem(new AttackSystem<EnemyTag>());
        AddSystem(new HighlightDamageSystem());

        AddSystem(new AnimationDeathSystem());
        AddSystem(new DestroyDeathSystem());
    }
}

public class Nipper : EnemyTag
{
    protected override void InitData()
    {
        AddData(new PointCheckerSystem());
        AddData(new PatrolFromWallToWallSystem());
        AddData(new NipperPossibleToAttackSystem());
        AddData(new AttackSystem<EnemyTag>());
        AddData(new HighlightDamageSystem());

        AddData(new AnimationDeathSystem());
        AddData(new DestroyDeathSystem());
    }

    protected override void InitSystems()
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

public class Nipper : EnemyTag
{
    protected override void InitData()
    {
        AddDataFromSystem(new PointCheckerSystem());
        AddDataFromSystem(new PatrolFromWallToWallSystem());
        AddDataFromSystem(new NipperPossibleToAttackSystem());
        AddDataFromSystem(new AttackSystem<EnemyTag>());
        AddDataFromSystem(new HighlightDamageSystem());

        AddDataFromSystem(new AnimationDeathSystem());
        AddDataFromSystem(new DestroyDeathSystem());
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

public class BayonetTrap : TrapTag
{
    protected override void InitData()
    {
        AddData(new BayonetTrapPossibleToAttackSystem());
        AddData(new AttackSystem<EnemyTag>());
    }

    protected override void InitSystems()
    {
        AddSystem(new BayonetTrapPossibleToAttackSystem());
        AddSystem(new AttackSystem<EnemyTag>());
    }
}

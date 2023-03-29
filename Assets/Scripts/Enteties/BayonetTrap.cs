public class BayonetTrap : TrapTag
{
    protected override void InitData()
    {
        AddDataFromSystem(new BayonetTrapPossibleToAttackSystem());
        AddDataFromSystem(new AttackSystem<EnemyTag>());
    }

    protected override void InitSystems()
    {
        AddSystem(new BayonetTrapPossibleToAttackSystem());
        AddSystem(new AttackSystem<EnemyTag>());
    }
}

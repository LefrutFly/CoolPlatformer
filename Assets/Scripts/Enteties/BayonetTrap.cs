public class BayonetTrap : TrapTag
{
    protected override void Initialize()
    {
        AddSystem(new BayonetTrapPossibleToAttackSystem());
        AddSystem(new AttackSystem<EnemyTag>());
    }
}

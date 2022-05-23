public class Player : Entity
{
    protected override void Initialize()
    {
        AddSystem(new PointCheckerSystem());
        AddSystem(new PlayerMoveSystem());
        AddSystem(new PlayerJumpSystem());
        AddSystem(new PlayerAttackSystem());
        AddSystem(new PlayerGunSystem());
        AddSystem(new ShiftAbilitySystem());
        AddSystem(new HighlightDamageSystem());
        AddSystem(new StuckInGroundSystem());

        AddSystem(new AnimaionDeathSystem());
        AddSystem(new DisableDeathSystem());
    }
}

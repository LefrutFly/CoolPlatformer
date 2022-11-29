public class Player : Entity
{
    public PlayerInputs inputs;

    protected override void Initialize()
    {
        inputs = new PlayerInputs();

        AddSystem(new PointCheckerSystem());
        AddSystem(new PlayerMoveSystem());
        AddSystem(new PlayerJumpSystem());
        AddSystem(new PlayerAttackSystem());
        AddSystem(new PlayerGunSystem());
        AddSystem(new ShiftAbilitySystem());
        AddSystem(new HighlightDamageSystem());
        AddSystem(new StuckInGroundSystem());

        AddSystem(new AnimationDeathSystem());
        AddSystem(new DisableDeathSystem());
    }

    protected override void OnEnable()
    {
        inputs.Enable();

        base.OnEnable();
    }

    protected override void OnDisable()
    {
        inputs.Disable();

        base.OnDisable();
    }
}

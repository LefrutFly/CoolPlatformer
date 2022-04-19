public class Player : Entity
{
    protected override void Initialize()
    {
        AddSystem(new PointCheckerSystem());
        AddSystem(new PlayerMoveSystem());
        AddSystem(new PlayerJumpSystem());
        AddSystem(new PlayerAttackSystem());
        AddSystem(new PlayerGunSystem());
        
        AddSystem(new DisableDeathSystem());
    }
}

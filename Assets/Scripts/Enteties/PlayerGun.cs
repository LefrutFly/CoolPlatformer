public class PlayerGun : Entity
{
    protected override void Initialize()
    {
        AddSystem(new GunDamageSystem());
    }
}
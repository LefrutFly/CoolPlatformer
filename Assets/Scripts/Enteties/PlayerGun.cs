using Lefrut.Framework;

public class PlayerGun : Facade
{
    protected override void InitData()
    {
        AddData(new GunDamageSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new GunDamageSystem());
    }
}
using Lefrut.Framework;

public class PlayerGun : Facade
{
    protected override void InitData()
    {
        AddDataFromSystem(new GunDamageSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new GunDamageSystem());
    }
}
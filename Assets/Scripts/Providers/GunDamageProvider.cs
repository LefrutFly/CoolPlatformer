using Lefrut.Framework;

public class GunDamageProvider : IProvider
{
    public GunDamageComponent component;

    public override IData Data => component;
}

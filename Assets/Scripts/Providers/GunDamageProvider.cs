using Lefrut.Framework;

public class GunDamageProvider : MonoProvider
{
    public GunDamageComponent component;

    public override IData Data => component;
}

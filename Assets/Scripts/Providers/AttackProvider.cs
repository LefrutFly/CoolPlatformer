using Lefrut.Framework;

public class AttackProvider : IProvider
{
    public AttackComponent component;

    public override IData Data => component;
}

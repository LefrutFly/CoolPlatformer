using Lefrut.Framework;

public class AttackReachProvider : IProvider
{
    public AttackReachComponent component = new AttackReachComponent();

    public override IData Data => component;
}

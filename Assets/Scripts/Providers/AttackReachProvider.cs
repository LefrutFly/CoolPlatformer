using Lefrut.Framework;

public class AttackReachProvider : MonoProvider
{
    public AttackReachComponent component = new AttackReachComponent();

    public override IData Data => component;
}

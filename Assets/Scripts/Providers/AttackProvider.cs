using Lefrut.Framework;

public class AttackProvider : MonoProvider
{
    public AttackComponent component;

    public override IData Data => component;
}

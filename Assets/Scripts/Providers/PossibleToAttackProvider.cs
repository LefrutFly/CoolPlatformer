using Lefrut.Framework;

public class PossibleToAttackProvider : MonoProvider
{
    public PossibleToAttackComponent component = new PossibleToAttackComponent();

    public override IData Data => component;
}

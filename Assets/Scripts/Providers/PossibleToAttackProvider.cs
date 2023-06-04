using Lefrut.Framework;

public class PossibleToAttackProvider : IProvider
{
    public PossibleToAttackComponent component = new PossibleToAttackComponent();

    public override IData Data => component;
}

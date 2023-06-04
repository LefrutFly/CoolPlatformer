using Lefrut.Framework;

public class ShiftAbilityProvider : IProvider
{
    public ShiftAbilityComponent component;

    public override IData Data => component;
}

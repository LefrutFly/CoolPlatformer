using Lefrut.Framework;

public class ShiftAbilityProvider : MonoProvider
{
    public ShiftAbilityComponent component;

    public override IData Data => component;
}

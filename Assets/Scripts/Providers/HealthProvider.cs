using Lefrut.Framework;

public class HealthProvider : MonoProvider 
{
    public HealthComponent component;

    public override IData Data => component;
}

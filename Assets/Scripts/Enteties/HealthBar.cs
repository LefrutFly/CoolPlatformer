using Lefrut.Framework;

public class HealthBar : Facade
{
    protected override void InitData()
    {
        AddData(new HealthBarSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new HealthBarSystem());
    }
}

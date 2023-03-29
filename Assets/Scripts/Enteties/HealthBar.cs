using Lefrut.Framework;

public class HealthBar : Facade
{
    protected override void InitData()
    {
        AddDataFromSystem(new HealthBarSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new HealthBarSystem());
    }
}

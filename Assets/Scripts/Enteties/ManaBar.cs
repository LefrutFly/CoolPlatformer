using Lefrut.Framework;

public class ManaBar : Facade
{
    protected override void InitData()
    {
        AddDataFromSystem(new ManaBarSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new ManaBarSystem());
    }
}

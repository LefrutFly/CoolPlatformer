using Lefrut.Framework;

public class ManaBar : Facade
{
    protected override void InitData()
    {
        AddData(new ManaBarSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new ManaBarSystem());
    }
}

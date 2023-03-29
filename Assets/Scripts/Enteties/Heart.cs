using Lefrut.Framework;

public class Heart : Facade
{
    protected override void InitData()
    {
        AddDataFromSystem(new PlusHealthSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new PlusHealthSystem());
    }
}

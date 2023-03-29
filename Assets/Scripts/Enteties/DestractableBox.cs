using Lefrut.Framework;

public class DestractableBox : Facade
{
    protected override void InitData()
    {
        AddDataFromSystem(new AnimationDeathSystem());
        AddDataFromSystem(new DisableDeathSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new AnimationDeathSystem());
        AddSystem(new DisableDeathSystem());
    }
}

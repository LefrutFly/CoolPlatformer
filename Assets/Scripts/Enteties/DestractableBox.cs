using Lefrut.Framework;

public class DestractableBox : Facade
{
    protected override void InitData()
    {
        AddData(new AnimationDeathSystem());
        AddData(new DisableDeathSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new AnimationDeathSystem());
        AddSystem(new DisableDeathSystem());
    }
}

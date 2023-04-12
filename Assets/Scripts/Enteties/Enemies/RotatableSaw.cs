using System.Collections;
using System.Collections.Generic;

public class RotatableSaw : TrapTag
{
    protected override void InitData()
    {
        AddDataFromSystem(new RotationAroundSystem());
        AddDataFromSystem(new PeriodicTriggerDamageSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new RotationAroundSystem());
        AddSystem(new PeriodicTriggerDamageSystem());
    }
}

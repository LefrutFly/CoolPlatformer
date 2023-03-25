using System.Collections;
using System.Collections.Generic;

public class RotatableSaw : TrapTag
{
    protected override void InitData()
    {
        AddData(new RotationAroundSystem());
        AddData(new PeriodicTriggerDamageSystem());
    }

    protected override void InitSystems()
    {
        AddSystem(new RotationAroundSystem());
        AddSystem(new PeriodicTriggerDamageSystem());
    }
}

using System.Collections;
using System.Collections.Generic;

public class RotatableSaw : TrapTag
{
    protected override void Initialize()
    {
        AddSystem(new RotationAroundSystem());
        AddSystem(new PeriodicTriggerDamageSystem());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestractableBox : Entity
{
    protected override void Initialize()
    {
        AddSystem(new AnimaionDeathSystem());
        AddSystem(new DisableDeathSystem());
    }
}

using System.Collections;
using System.Collections.Generic;

public class Heart : Entity
{
    protected override void Initialize()
    {
        AddSystem(new PlusHealthSystem());
    }
}

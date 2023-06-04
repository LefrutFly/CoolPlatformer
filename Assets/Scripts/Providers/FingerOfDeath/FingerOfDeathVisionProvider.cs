using Lefrut.Framework;
using UnityEngine;

public class FingerOfDeathVisionProvider : IProvider
{
    [SerializeField] private FingerOfDeathVisionData data;

    public override IData Data => data;
}

using Lefrut.Framework;
using UnityEngine;

public class FingerOfDeathVisionProvider : MonoProvider
{
    [SerializeField] private FingerOfDeathVisionData data;

    public override IData Data => data;
}

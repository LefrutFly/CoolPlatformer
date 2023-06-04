using Lefrut.Framework;
using UnityEngine;

public class FingerOfDeathAttackProvider : IProvider
{
    [SerializeField] protected FingerOfDeathAttackData data;

    public override IData Data => data;
}
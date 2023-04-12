using Lefrut.Framework;
using UnityEngine;

public class FingerOfDeathAttackProvider : MonoProvider
{
    [SerializeField] protected FingerOfDeathAttackData data;

    public override IData Data => data;
}
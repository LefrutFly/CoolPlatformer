using Lefrut.Framework;
using UnityEngine;

[System.Serializable]
public class FingerOfDeathAttackData : IData
{
    public Animator Animator;
    [Space]
    public string AttackTriggerAnimation_1;
    public float Damage_1;
    public float DelayBeforeAttack_1;
    public float DelayAfterAttack_1;
    [Space]
    public string AttackTriggerAnimation_2;
    public float Damage_2;
    public float DelayBeforeAttack_2;
    public float DelayAfterAttack_2;
}
using UnityEngine;

[System.Serializable]
public class AttackComponent
{
    public float damage;
    public float delayBeforeAttack;
    public float delayAfterAttack;
    public Animator animator;
    public string animationTrigger;
    public Collider2D collider;
}

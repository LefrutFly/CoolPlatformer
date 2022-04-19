using UnityEngine;

[System.Serializable]
public class PlayerAttackComponent
{
    public float damage;
    public float delayBeforeAttack;
    public float delayAfterAttack;
    public Animator animator;
    public string animationTrigger;
    public KeyCode keyCode;
    public Collider2D collider;
}

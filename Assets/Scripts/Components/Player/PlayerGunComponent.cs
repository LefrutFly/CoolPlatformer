using UnityEngine;

[System.Serializable]
public class PlayerGunComponent
{
    public PlayerGun gun;
    public Animator animator;
    public string attackAnimatorTrigger;
    public string closeGunAnimatorTrigger;
    public PlayerGun gunPrefab;
    public Transform gunPosition;
    public float cooldown;
    public float damage;
    public float manaCost;
}

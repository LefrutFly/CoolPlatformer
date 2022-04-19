using UnityEngine;

[System.Serializable]
public class PlayerSpawnerComponent
{
    public Player player;
    public Transform spawnPoint;
    public Animator animator;
    public string animatorTrigger;
    public KeyCode keyCode;
    public float delay;
}

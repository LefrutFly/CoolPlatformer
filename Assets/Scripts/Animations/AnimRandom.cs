using UnityEngine;

public class AnimRandom : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetFloat("Random", Random.Range(0f, 1f));
    }
}

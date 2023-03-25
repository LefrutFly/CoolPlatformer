using Lefrut.Framework;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ManaBarComponent : IData
{
    public TMP_Text text;
    public Animator animator;
    public string nameAnimationTrigger;
}
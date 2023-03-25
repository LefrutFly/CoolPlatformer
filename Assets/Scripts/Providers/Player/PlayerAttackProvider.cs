using Lefrut.Framework;
using UnityEngine;

public class PlayerAttackProvider : MonoProvider
{
    public override IData Data => component;

    [SerializeField] private PlayerAttackComponent component;
}

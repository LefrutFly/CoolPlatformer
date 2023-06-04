using Lefrut.Framework;
using UnityEngine;

public class PlayerAttackProvider : IProvider
{
    public override IData Data => component;

    [SerializeField] private PlayerAttackComponent component;
}

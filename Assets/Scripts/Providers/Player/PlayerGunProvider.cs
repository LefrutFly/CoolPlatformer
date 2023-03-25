using Lefrut.Framework;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerGunProvider : MonoProvider
{
    public PlayerGunComponent component;

    public override IData Data => component;
}
